using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Security;
using Logic;

namespace JobPortal.Controllers
{
    public class FilesController : Controller
    {
        private Guid _UserID;
        Guid UserID
        {
            get
            {
                _UserID = new Guid(Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());
                return _UserID;
            }
        }

        
        [HttpPost, Authorize(Roles = "candidate")]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {

            try
            {
                if (uploadFile.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                                                   Path.GetFileName(UserID.ToString() + uploadFile.FileName.ToString()));
                    uploadFile.SaveAs(filePath);
                    DataProvider dataProvider = new DataProvider();
                    dataProvider.candidatesManager.SaveFile(UserID, uploadFile.FileName.ToString());
                }
                return RedirectToAction("EditCadidates", "Home");

            }
            catch
            {
                ModelState.AddModelError("uploadFile", "Не верно выбран файл!");
                return RedirectToAction("EditCadidates", "Home");
            }
        }

        
        
        //
        // POST: /File/Delete/5

        [HttpGet, Authorize(Roles = "candidate")]
        public ActionResult Delete()
        {
            DataProvider dataProvider = new DataProvider();
            String Dellfile = dataProvider.candidatesManager.GetCandidate(UserID).FileName.ToString();
            System.IO.File.Delete(Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                                               Path.GetFileName(String.Concat(UserID.ToString(), Dellfile))));
            dataProvider.candidatesManager.SaveFile(UserID, null);
            return RedirectToAction("EditCadidates", "Home");
        }

        [HttpPost, Authorize(Roles = "candidate")]
        public ActionResult FileReplace(HttpPostedFileBase uploadFile)
        {
            try
            {
                if (uploadFile.ContentLength > 0)
                {
                    this.Delete();
                    this.FileUpload(uploadFile);
                }
                    return RedirectToAction("EditCadidates", "Home");
                
            }
            catch
            {
                ModelState.AddModelError("StartDate", "Неверно введена дата!");
                return RedirectToAction("EditCadidates", "Home");
            }
       }
    }
}
