using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.DAL;

namespace Logic
{
   public  class CompanyManager
    {       
       /*
        public IEnumerable<Company> GetCompany()
        {
            using (var dc = new JobPortalDbDataContext())
            {
                return (from c in dc.Companies
                        select c).ToList();
            }
        }
       
      
        public Company GetCompany(int companyId)
        {
            using (var db = new JobPortalDbDataContext())
            {
                Company comp = db.Companies.Single(c => c.CompanyId == companyId);
                return comp;
            }
        }
      
       
       
       
       
       public void CreateCompany(Company company)
        {
            var db = new JobPortalDbDataContext();
            db.Companies.InsertOnSubmit(company);
            db.SubmitChanges();
         }
       */
        

        public void CreateVacancy(Vacancy vc)
        {

            vc.StartDate = DateTime.Now.ToLocalTime();
            var db = new JobPortalDbDataContext();
            db.Vacancies.InsertOnSubmit(vc);
            db.SubmitChanges();
            
         }

      /*

        public IEnumerable<Vacancy> GetVacancies(int companyID)
        {
            using (var db = new JobPortalDbDataContext())
            {
                IQueryable<Vacancy> vacancy =
                    from c in db.Vacancies
                    where c.CompanyId == companyID
                    select c;

                return vacancy.ToList();
            }
        }
       */
        public IEnumerable<Vacancy> GetVacancies()
        {
            using (var db = new JobPortalDbDataContext())
            {
               return (from c in db.Vacancies select c).ToList();
            }
        }

        public IEnumerable<Vacancy> GetVacancies(Guid UserID)
        {
            using (var db = new JobPortalDbDataContext())
            {
                return (from c in db.Vacancies 
                        where c.CompanyId==UserID
                        select c).ToList();
            }
        }

        public Vacancy GetVacancy(int VacancyId)
        {
            using (var db = new JobPortalDbDataContext())
            {
                return (from c in db.Vacancies where c.VacancyId==VacancyId select c).Single();
            }

        }
           
       
        public void SaveVacancy(Vacancy EditeVacansy)
        {
            var db = new JobPortalDbDataContext();
           // db.Vacancies.Attach(EditeVacansy);/*
            Vacancy vacancy = db.Vacancies.Where(c=> c.VacancyId==EditeVacansy.VacancyId).Single();
            vacancy.Name = EditeVacansy.Name;
            vacancy.SphereActivityId = EditeVacansy.SphereActivityId;
            vacancy.Description = EditeVacansy.Description;
            vacancy.EndDate = EditeVacansy.EndDate;
            //vacancy.IsActive = EditeVacansy.IsActive;
            vacancy.SphereActivityId = EditeVacansy.SphereActivityId;
            vacancy.WagesFrom = EditeVacansy.WagesFrom;
            vacancy.WagesUntil = EditeVacansy.WagesUntil;
            vacancy.PostId = EditeVacansy.PostId;
            vacancy.StartDate = EditeVacansy.StartDate;
            vacancy.EndDate = vacancy.EndDate;
            db.SubmitChanges();
         
        } 



        public void DeleteVacancy(int id)
        {

            var db = new JobPortalDbDataContext();
            db.Vacancies.DeleteOnSubmit(db.Vacancies.Single(c=>c.VacancyId==id));
            db.Requests.DeleteAllOnSubmit(db.Requests.Where(c => c.VacancyId == id));
            db.SubmitChanges();
        }






        public IEnumerable<Vacancy> Srch(Srch srch)
        {
            using (var db = new JobPortalDbDataContext())
            {
                
                
              //  where (!from.HasValue || salary.Zp >= from.Value)
             //     &&  (!to.HasValue || salary.Zp < to.Value)   
                
               /* return (from c in db.Vacancies
                        where  (c.Name == srch.Name) && (c.SphereActivityId==srch.SphereActivity) 
                        && (c.PostId==srch.Post)
                        && (c.WagesFrom >= srch.WagesFrom) && (c.WagesUntil <= srch.WagesUntil) 
                       select c).ToList();*/
             //   IEnumerable<Vacancy> srchVacancy = this.GetVacancies();
                IQueryable<Vacancy> srchVacancy = from c in db.Vacancies 
                                                  where c.EndDate >= DateTime.Now
                                                  select c;

               //srchVacancy = srchVacancy.Where(c=>c.EndDate >= DateTime.Now); 
               if(!string.IsNullOrEmpty(srch.Name)) srchVacancy = srchVacancy.Where(c=>c.Name.Contains(srch.Name));
               if (srch.SphereActivity != 0) srchVacancy = srchVacancy.Where(c => c.SphereActivityId == srch.SphereActivity);
               if (srch.Post != 0) srchVacancy = srchVacancy.Where(c => c.PostId == srch.Post);
               if (srch.WagesFrom != 0) srchVacancy = srchVacancy.Where(c => c.WagesFrom <= srch.WagesFrom);
               if (srch.WagesUntil != 0) srchVacancy = srchVacancy.Where(c => c.WagesUntil >= srch.WagesUntil);
               
               return srchVacancy.ToList();
            }
        }
       /*
        public object GetVacancy(int id, Guid UserID)
        {
            using (var db = new JobPortalDbDataContext())
            {
                return (from c in db.Vacancies where c.VacancyId == id select c).Where(c=>c.CompanyId==UserID).Single();
            }

            
        }*/
    }
}
