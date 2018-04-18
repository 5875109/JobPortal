using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.DAL;
using System.Web.Mvc;
namespace Logic
{
    public  class OtherManager
    {
        public IEnumerable<Salary> GetSalarys()
        {
            using (var dc = new JobPortalDbDataContext())
            {
                return (from c in dc.Salaries
                        select c).ToList();
            }
        }

        public List<SelectListItem> GetSalarysSelectListItem()
           {
       
             List<SelectListItem> sel = new List<SelectListItem>();
               sel.AddRange(this.GetSalarys().Select(x=> 
               {
                   return new SelectListItem() {  Text = x.Salary1, Value = x.Id.ToString()};
               }));     
          return sel;
          }
          
          
           
           

        public IEnumerable<SphereActivity> GetSphereActivity()
        {
            using (var dc = new JobPortalDbDataContext())
            {
                return (from c in dc.SphereActivities
                        select c).ToList();
            }
        }
        public List<SelectListItem> GetSphereActivitySelectListItem()
        {

            List<SelectListItem> sel = new List<SelectListItem>();
            sel.AddRange(this.GetSphereActivity().Select(x =>
            {
                return new SelectListItem() { Text = x.SphereActivity1, Value = x.Id.ToString() };
            }));
            return sel;
        }

     /*   public List<SelectListItem> GetSphereActivitySelectListItem(int SelectedId)
        {

            List<SelectListItem> sel = new List<SelectListItem>();
            sel.AddRange(this.GetSphereActivity().Select(x =>
            {

             /*   if (SelectedId == x.Id)
                    return new SelectListItem() {/*Selected=true, Text = x.SphereActivity1, Value = x.Id.ToString() };
                else
                    return new SelectListItem() { Text = x.SphereActivity1, Value = x.Id.ToString() };
            }));
            return sel;
        }
*/

        public IEnumerable<Post> GetPosts()
        {
            using (var dc = new JobPortalDbDataContext())
            {
                return (from c in dc.Posts
                        select c).ToList();
            }
        }

        public List<SelectListItem> GetPostsSelectListItem()
        {

            List<SelectListItem> sel = new List<SelectListItem>();
            sel.AddRange(this.GetPosts().Select(x =>
            {
                return new SelectListItem() { Text = x.Post1, Value = x.Id.ToString() };
            }));
            return sel;
        }


        public String GetPost(int id)
        {
            using (var dc = new JobPortalDbDataContext())
            {
                 Post post =(from c in dc.Posts
                             where c.Id==id
                             select c).Single();


                 return post.Post1.ToString();
            }
        
        }

        public String GetSphereActivity(int id)
        {
            using (var dc = new JobPortalDbDataContext())
            {
                SphereActivity  post = (from c in dc.SphereActivities
                                where c.Id == id
                                select c).Single();


                return post.SphereActivity1.ToString();
            }

        }

        public String GetSalary(int id)
        {
            using (var dc = new JobPortalDbDataContext())
            {
                Salary post = (from c in dc.Salaries
                             where c.Id == id
                             select c).Single();


                return post.Salary1.ToString();
            }

        }
        
        public String GetCompany(Guid id)
        {
            using (var dc = new JobPortalDbDataContext())
            {
                aspnet_User post = (from c in dc.aspnet_Users
                               where c.UserId == id
                               select c).Single();


                return post.UserName.ToString();
            }

        }

    }
}
