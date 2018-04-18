<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Logic.DAL.Vacancy>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ваши вакансии:</h2>

    <table>
        <tr>
            <th></th>
           
            <th>
                Название вакансии
            </th>
            <th>
                Начало действия
            </th>
            <th>
                Конец действия
            </th>
            <th>
                Описание
            </th>
           
          
        
        </tr>

    <% foreach (var item in (IEnumerable<Logic.DAL.Vacancy>)ViewData["Vacancies"]) { %>
    
        <tr>
            <td>
              <% if (Roles.IsUserInRole("company")) {%>
                   <%: Html.ActionLink("Редактировать", "Edit", new { id=item.VacancyId }) %> |
                <%} %>
                <%: Html.ActionLink("Подробно", "Details", new { id=item.VacancyId })%> |
              
              <% if (Roles.IsUserInRole("company")) {%>
                <%: Html.ActionLink("Удалить", "Delete", new { id=item.VacancyId })%>
            <%} %>
            </td>
           
            <td>
                <%: item.Name %>
            </td>
          
            <td>
                <%: String.Format("{0:g}", item.StartDate) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.EndDate) %>
            </td>
          

            <td>
                <%: item.Description %>
            </td>
            
        </tr>
    
    <% } %>

    </table>
    <% if (Roles.IsUserInRole("company")) {%>
    <p>
        <%: Html.ActionLink("Создать вакансию", "Create") %>
    </p>
    <%} %>
                
</asp:Content>

