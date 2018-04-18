<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Logic.DAL.Vacancy>" %>


        
        <div class="display-label">Название организации</div>
        <div class="display-field"><%:ViewData["Company"]%></div>
        </br>
        <div class="display-label">Название вакансии</div>
        <div class="display-field"><%: Model.Name %></div>
        </br>
        <div class="display-label">Должность</div>
        <div class="display-field"><%:   ViewData["Post"]%></div>
        </br>
        <div class="display-label">Сфера деятельности</div>
        <div class="display-field"><%: ViewData["SphereActivityId"]%></div>
        </br>
        <div class="display-label">Дата выхода на работу</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.StartDate) %></div>
        </br>
        <div class="display-label">Дата окончания действия вакансии</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.EndDate) %></div>
        </br>
        <div class="display-label">Заработная плата от: <%:ViewData["WagesFrom"]%>  до <%: ViewData["WagesUntil"]%></div>
      
        </br>
        <div class="display-label">Описание</div>
        <div class="display-field"><%: Model.Description %></div>
        
      
  