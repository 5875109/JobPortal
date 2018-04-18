<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Logic.DAL.Vacancy>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Список вакансий</h2>

    <table>
        <tr>
            <th></th>
          
            <th>
                Название
            </th>
            <th>
                Дата выхода на работу
            </th>
           
            <th>
                Дата окончания действия вакансии
            </th>
           
           
            <th>
               Описание
            </th>
           
          
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Подробно", "DetailsForAll", new { id=item.VacancyId })%>
                
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

    

</asp:Content>

