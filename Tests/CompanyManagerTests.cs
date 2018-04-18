using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Logic.DAL;
using System.Web.Security;

namespace Tests
{
    [TestClass]
    public class CompanyManagerTests
    {
        // 1. Добавление вакансии
        // 2. Редактирование вакансии
        // 3. Просмотр вакансий
        // 4. Удаление вакансии

// 1. 3.

        [TestMethod]
        public void CreateVacancyTest()
        {
            CompanyManager cm = new CompanyManager();

            Vacancy vacancy = new Vacancy();
            cm.CreateVacancy(vacancy);
           // Assert.IsNotNull(cm.GetVacanciesByCompanyID(vacancy.CompanyId));
         }

// 2.  
        [TestMethod]
        public void CreateVacancyEditTest()
        {
            CompanyManager cm = new CompanyManager();
            Vacancy vacancy = new Vacancy() { Name = "Programmers"};
            cm.SaveVacancy(vacancy);
            //Assert.IsNotNull(cm.GetVacanciesByConpaniID(vacancy.CompanyId));
        }
// 4.  
        [TestMethod] 
        public void DeleteVacancyTest(int id)
        {
            CompanyManager cm = new CompanyManager();
            //Vacancy vacancy = new Vacancy() {CompanyId = 0, Name = "Programmers" };
            cm.DeleteVacancy(0);
          //  Assert.IsNotNull(cm.GetCompanyVacanciesByCompany(company));
        }
        
        
        
        
        // Проверка подключения
        // Получение списка компаний
        // Создание компании и получение ID
        

        [TestMethod]
        public void CanCreateCompanyManagerTest()
        {
            CompanyManager cm = new CompanyManager();
            Assert.IsNotNull(cm);
        }
        /*
        [TestMethod]
        public void GetCompaniesTest()
        {
            CompanyManager cm = new CompanyManager();
            IEnumerable<Company> companies = cm.GetCompany();
            Assert.IsNotNull(companies);
            Assert.IsTrue(companies.Count() > 0);
        }

        [TestMethod]
        public void CreateCompanyTest()
        {
            Company company = new Company() {Description = "Some description", Name = "TestCompanyName" };
            CompanyManager cm = new CompanyManager();
            cm.CreateCompany(company);
            //Company createdCompany = cm.GetCompany();
            //Assert.IsNotNull(createdCompany);           
        }

        */
    
    }
}
