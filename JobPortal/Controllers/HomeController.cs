using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Logic.DAL;
using System.Web.Security;


namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        

   /*     private DataProvider _dataProvider;

        public HomeController(DataProvider dataProvider)
        {
            _dataProvider = new DataProvider();
        }

        */
       
        private Guid _UserID;
        Guid UserID
        {
            get
            {

              _UserID = new Guid(Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());
              return _UserID;
            }
        }
        [HttpGet]
        public ViewResult SrchCandidates()
        {
            DataProvider dp = new DataProvider();
            ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
            ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
            ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();    
            return View();
        }
        
        [HttpPost]
        public ActionResult SrchCandidates(Srch srch)
        {
            DataProvider dp = new DataProvider();
            //ViewData["Candidates"] = ;
            return View("ListCandidates",dp.candidatesManager.Srch(srch));
        }

      /*  [HttpGet]
        public ViewResult List()  // Вакансии 
        {
            DataProvider dataProvider = new DataProvider();
           // ViewData["UserID"] = UserID;
            ViewData["Vacancies"] = dataProvider.companyManager.GetVacancies();
            return View();
        }
        */
        [HttpGet, Authorize(Roles = "company")]
        public ViewResult Create()
        {
            DataProvider dp = new DataProvider();
            ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
            ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
            ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();    
            return View();
        }
        
        [HttpPost, Authorize(Roles = "company")]
        public ActionResult Create(/*[Bind(Include="VacancyId,Name,Description,EndDate,IsActive,CompanyId")]*/ Vacancy vacancy)
        {
            //StartDate
            DataProvider dp = new DataProvider();
            vacancy.CompanyId = UserID;
            
            if (string.IsNullOrEmpty(vacancy.Name))
                ModelState.AddModelError("Name", "Не должно быть пустым");
            if (string.IsNullOrEmpty(vacancy.Description))
                ModelState.AddModelError("Description", "Не должно быть пустым");
            DateTime validateDate;
            
            string s=vacancy.StartDate.ToString();
            if(DateTime.TryParse(s, out validateDate))
            {
                vacancy.StartDate=validateDate;
            }
            else
            {
                vacancy.StartDate = null;
                ModelState.AddModelError("StartDate", "Неверно введена дата!");
            };

            s = vacancy.EndDate.ToString();
            if (DateTime.TryParse(s, out validateDate))
            { vacancy.EndDate = validateDate;}
            else
                {
                    vacancy.EndDate = null;
                    ModelState.AddModelError("EndDate", "Неверно введена дата!");
                };

            if ((vacancy.WagesUntil - vacancy.WagesFrom) <= 0)
            {
                ModelState.AddModelError("WagesUntil", "Не верно выбран диапазон заработной платы!");
                ModelState.AddModelError("WagesFrom","");
            }

            if (ModelState.IsValid)
            {
                dp.companyManager.CreateVacancy(vacancy);
                return RedirectToAction("CompanyVacacyList");
            }
            else 
            {
                ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
                ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
                ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();
                return View(vacancy);
            }
        
        }
        
        [HttpGet, Authorize(Roles = "Company")]
        public ActionResult Delete(int id)
        {
            DataProvider dp = new DataProvider();

            dp.companyManager.DeleteVacancy(id);
            return RedirectToAction("CompanyVacacyList");

        }
        
        [HttpGet, Authorize]
        public ViewResult Edit(int id)
        {
            DataProvider dp = new DataProvider();
            ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
            ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
            ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();    
            return View(dp.companyManager.GetVacancy(id));
        }
        
        [HttpPost, Authorize(Roles = "Company")]
        public ActionResult Edit(/*[Bind(Include = "SphereActivityId,VacancyId,Name,Description,EndDate,IsActive,CompanyId")]*/ Vacancy vacancy, int id)
        {
            DataProvider dp = new DataProvider();

            if (string.IsNullOrEmpty(vacancy.Name))
                ModelState.AddModelError("Name", "Не должно быть пустым");
            if (string.IsNullOrEmpty(vacancy.Description))
                ModelState.AddModelError("Description", "Не должно быть пустым");
            DateTime validateDate;

            string s = vacancy.StartDate.ToString();
            if (DateTime.TryParse(s, out validateDate))
            {
                vacancy.StartDate = validateDate;
            }
            else
            {
                vacancy.StartDate = null;
                ModelState.AddModelError("StartDate", "Неверно введена дата!");
            };

            s = vacancy.EndDate.ToString();
            if (DateTime.TryParse(s, out validateDate))
            { vacancy.EndDate = validateDate; }
            else
            {
                vacancy.EndDate = null;
                ModelState.AddModelError("EndDate", "Неверно введена дата!");
            };

            if ((vacancy.WagesUntil - vacancy.WagesFrom) <= 0)
            {
                ModelState.AddModelError("WagesUntil", "Не верно выбран диапазон заработной платы!");
                ModelState.AddModelError("WagesFrom", "");
            }

            if (ModelState.IsValid)
            {

                vacancy.VacancyId = id;
                dp.companyManager.SaveVacancy(vacancy);
                return RedirectToAction("CompanyVacacyList");
            }
            else
            {
                ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
                ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
                ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();
                return View(vacancy);
            }
    





            
            
            
          
        
        
        
        
        
        }

        [HttpGet]
        public ViewResult SrchVacancies()
        {
            DataProvider dp = new DataProvider();
                    
            ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
            ViewData["SphereActivity"]=dp.OtherManager.GetSphereActivitySelectListItem();
            ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();            
            return View();
        }

        [HttpPost]
        public ActionResult SrchVacancies(Srch srch)
        {


            if (srch.WagesFrom == srch.WagesUntil) ModelState.AddModelError("WagesFrom", "Title should be longer than 3 characters.");


              DataProvider dp = new DataProvider();
                //ViewData["Vacancies"] = dp.companyManager.Srch(srch);         
                return View("ListForAll", dp.companyManager.Srch(srch));
             
         }

        [HttpGet, Authorize(Roles = "candidate")]
        public ViewResult EditCadidates()
        {
           
            DataProvider dp = new DataProvider();
            Candidate can = dp.candidatesManager.GetCandidate(UserID);
            ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
            ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
            ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();

            if (can != null)
            {
               
                ViewData["FileName"] = can.FileName;
                return View(can);
            }
            else
            {
                dp.candidatesManager.CreateCondidate(UserID);
                return View();

            }
        }

        [HttpPost, Authorize(Roles = "candidate")]
        public ActionResult EditCadidates(Candidate candidate, string uploadFile)
        {
            DataProvider dp = new DataProvider();
               

            if (string.IsNullOrEmpty(candidate.FirstName))
                ModelState.AddModelError("FirstName", "Не должно быть пустым!");
            if (string.IsNullOrEmpty(candidate.SecondName))
                ModelState.AddModelError("SecondName", "Не должно быть пустым!");
            if (string.IsNullOrEmpty(candidate.Age.ToString()))
                ModelState.AddModelError("Age", "Не должно быть пустым!");
            if((candidate.Age<12)||(candidate.Age>80))
                ModelState.AddModelError("Age", "Не может быть такого возраста!");
            if(candidate.WagesFromId>candidate.WagesUntilId)
                ModelState.AddModelError("WagesUntilId", "Не верно выбран диапазон!");



            if (ModelState.IsValid)
            {
                candidate.CandidateId = UserID;
                dp.candidatesManager.SaveCandidate(candidate);
            }
            else
            {
                ViewData["Salary"] = dp.OtherManager.GetSalarysSelectListItem();
                ViewData["SphereActivity"] = dp.OtherManager.GetSphereActivitySelectListItem();
                ViewData["Posts"] = dp.OtherManager.GetPostsSelectListItem();

                return View(candidate);

            }
            
            
            
            
            return RedirectToAction("SrchVacancies");
        }

/*
        [HttpPost, Authorize(Roles = "candidate")]
        public ActionResult GiveRequest(int id)
        {
            DataProvider dp = new DataProvider();
            dp.candidatesManager.GiveRequest(UserID,id);
            return RedirectToAction("List");
        }
        */
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            DataProvider dp = new DataProvider();
            if (Roles.IsUserInRole("candidate")) ViewData["request"] = dp.candidatesManager.HaveRequest(UserID,id);
            ViewData["Users"] = dp.candidatesManager.Request(id);

            Vacancy vac = dp.companyManager.GetVacancy(id);
            if (vac.CompanyId.HasValue)
                ViewData["Company"] = dp.OtherManager.GetCompany(vac.CompanyId.Value);

            ViewData["WagesFrom"] = dp.OtherManager.GetSalary(vac.WagesFrom.Value);
            ViewData["WagesUntil"] = dp.OtherManager.GetSalary(vac.WagesUntil.Value);
            ViewData["Post"] = dp.OtherManager.GetPost(vac.PostId.Value);
            ViewData["SphereActivityId"] = dp.OtherManager.GetSphereActivity(vac.SphereActivityId.Value);
            return View(vac);
            // return View(dp.companyManager.GetVacancy(id));
        }

        [HttpGet, Authorize(Roles = "candidate")]
        public ActionResult DeleteRequest(int id)
        {
            DataProvider dp = new DataProvider();
            dp.candidatesManager.DeleteRequest(UserID, id);
            return RedirectToAction("DetailsForAll", new { id = id });
        }

        [HttpGet, Authorize(Roles = "candidate")]
        public ActionResult SendRequest(int id)
        {
            DataProvider dp = new DataProvider();
            dp.candidatesManager.GiveRequest(UserID, id);
            return RedirectToAction("DetailsForAll", new { id = id });
        }
        
        [HttpGet]
        public ViewResult ListCandidates()
         {
             DataProvider dp = new DataProvider();
            

             return View(dp.candidatesManager.GetCanDidates());
         }

        [HttpGet]
        public ViewResult DetailsCandidate(Guid id)
         {
             DataProvider dp = new DataProvider();
             Candidate can = dp.candidatesManager.GetCandidate(id);
             ViewData["CurrentSphereActivity"] = dp.OtherManager.GetSphereActivity(can.CurrentSphereActivityId.Value);
             ViewData["DesirableSphereActivity"] = dp.OtherManager.GetSphereActivity(can.DesirableSphereActivityId.Value);
             ViewData["CurrentPost"] = dp.OtherManager.GetPost(can.CurrentPost.Value);
             ViewData["DesirablePost"] = dp.OtherManager.GetPost(can.DesirablePost.Value);
             ViewData["WagesFrom"] = dp.OtherManager.GetSalary(can.WagesFromId.Value);
             ViewData["WagesUntil"] = dp.OtherManager.GetSalary(can.WagesUntilId.Value);
            
            
            return View(can);
         }

        public FilePathResult Download(Guid id, String file)
       {
           string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
           //string fileName = "test.txt";
           return File(path + id+file, "text/plain", file);
       }

        [HttpGet, Authorize(Roles = "Company")]
        public ViewResult CompanyVacacyList()
       {
           DataProvider dp = new DataProvider();
           ViewData["Vacancies"] = dp.companyManager.GetVacancies(UserID);
           return View("List");
       }

        [HttpGet]
        public ViewResult DetailsForAll(int id)
        {
            DataProvider dp = new DataProvider();
            Vacancy vac = dp.companyManager.GetVacancy(id);
            if (Roles.IsUserInRole("candidate")) ViewData["request"] = dp.candidatesManager.HaveRequest(UserID, id);
          //  ViewData["Users"] = dp.candidatesManager.Request(id);


            ViewData["Company"] = dp.OtherManager.GetCompany((Guid)vac.CompanyId);
            ViewData["WagesFrom"] = dp.OtherManager.GetSalary(vac.WagesFrom.Value);
            ViewData["WagesUntil"] = dp.OtherManager.GetSalary(vac.WagesUntil.Value);
            ViewData["Post"] = dp.OtherManager.GetPost(vac.PostId.Value);
            ViewData["SphereActivityId"] = dp.OtherManager.GetSphereActivity(vac.SphereActivityId.Value);                           
            return View(vac);
        }

        [HttpGet]
        public ViewResult ListForAll()
        {
            DataProvider dataProvider = new DataProvider();
            return View(dataProvider.companyManager.GetVacancies());
        }
    }
   


   
   // x => x.Gender, new SelectList(new [] {"M", "F"}
    //<%: Html.DropDownList("Salary", (List<SelectListItem>)ViewData["Salary"])%>
}//RedirectToAction("Task", new { id });

