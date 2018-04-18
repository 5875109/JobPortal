using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.DAL;
namespace Logic
{
   public class CandidatesManager
    {

       public Candidate GetCandidate(Guid CandidateId)
        {
            using (var db = new JobPortalDbDataContext())
            {
                Candidate comp;
                try
                {
                    comp = db.Candidates.Single(c => c.CandidateId == CandidateId);
                }
                catch
                {
                comp = null;
                }
                    
                return comp;
            }      
       }

       public void CreateCondidate(Guid candidateId)
       {
           var db = new JobPortalDbDataContext();
           Candidate can = new Candidate { CandidateId = candidateId};
           db.Candidates.InsertOnSubmit(can);
           db.SubmitChanges();
       }

       public void SaveCandidate(Candidate candidate)
       {
           
           var db = new JobPortalDbDataContext();
           Candidate can = db.Candidates.Where(c => c.CandidateId == candidate.CandidateId).Single();
           can.FirstName = candidate.FirstName;
           can.SecondName = candidate.SecondName;
           can.Age = candidate.Age;
           can.CurrentSphereActivityId = candidate.CurrentSphereActivityId;
           can.DesirableSphereActivityId = candidate.DesirableSphereActivityId;
           can.CurrentPost = candidate.CurrentPost;
           can.DesirablePost = candidate.DesirablePost;
           can.WagesFromId = candidate.WagesFromId;
           can.WagesUntilId = candidate.WagesUntilId;
           db.SubmitChanges();
       }

       public void SaveFile(Guid UserID, String fileName)
       {
           var db = new JobPortalDbDataContext();
           Candidate can = db.Candidates.Where(c => c.CandidateId == UserID).Single();
           can.FileName = fileName;
           db.SubmitChanges();
       }

       /* public String Filename(Guid UserID)
       {
           var db = new JobPortalDbDataContext();
           String fileName = from 


           return fileName;
       }

        

        */

       public void GiveRequest(Guid UserID,int id)
       {
           var db = new JobPortalDbDataContext();
           Request vac = new Request {UserID = UserID, VacancyId = id  };
           db.Requests.InsertOnSubmit(vac);
           db.SubmitChanges();  
       }

       public void DeleteRequest(Guid UserID, int id)
       {
           var db = new JobPortalDbDataContext();
         Request req =  (from c in db.Requests
                         where c.UserID==UserID
                         select c).Where(c => c.VacancyId==id).Single();
           db.Requests.DeleteOnSubmit(req);
           db.SubmitChanges();
       }

       public Boolean HaveRequest(Guid UserID, int VacancyID)
       {
           try
           {
               var db = new JobPortalDbDataContext();
               var req = (from c in db.Requests
                          where c.UserID == UserID
                          select c).Where(c => c.VacancyId == VacancyID).Single();
               if (String.IsNullOrEmpty(req.VacancyId.ToString()))
               {
                   return false;
               }
               else
               {
                   return true;
               }
           }
           catch
           {
               return false;
           }
       }

       public IEnumerable<Candidate> GetCanDidates()
       {
           using (var db = new JobPortalDbDataContext())
           {
               return (from c in db.Candidates select c).ToList();
           }
       }

       public IEnumerable<Candidate> Srch(Srch srch)
       {
           using (var db = new JobPortalDbDataContext())
           {
               IEnumerable<Candidate> srchCandidate = this.GetCanDidates();

               if (srch.SphereActivity != 0) srchCandidate = srchCandidate.Where(c => c.CurrentSphereActivityId == srch.SphereActivity);
               if (srch.Post != 0) srchCandidate = srchCandidate.Where(c => c.CurrentPost == srch.Post);
               if (srch.DesirableSphereActivity != 0) srchCandidate = srchCandidate.Where(c => c.DesirableSphereActivityId == srch.DesirableSphereActivity);
               if (srch.DesirablePost != 0) srchCandidate = srchCandidate.Where(c => c.DesirablePost == srch.DesirablePost);
               if (srch.WagesFrom != 0) srchCandidate = srchCandidate.Where(c => c.WagesFromId <= srch.WagesFrom);
               if (srch.WagesUntil != 0) srchCandidate = srchCandidate.Where(c => c.WagesUntilId >= srch.WagesUntil);

               return srchCandidate;
           }
       }

       public IEnumerable<Candidate> Request(int id)
       {
           using (var db = new JobPortalDbDataContext())
           {
               IEnumerable<Guid> Users = (from c in db.Requests
                                          where c.VacancyId==id 
                                          select c.UserID).ToList();
            var can = new List<Candidate>();
            foreach(Guid UserID in Users)
            {
            
            can.Add(db.Candidates.Where(c => c.CandidateId == UserID).Single());
            
            };
            return can;        


           }
       }
    }
}
