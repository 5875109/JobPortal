<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Logic.DAL.Candidate>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListCandidates
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Список кандидатов</h2>

    <table>
        <tr>
            <th></th>
           
            <th>
               Фамилия
            </th>
            <th>
                Имя
            </th>
            <th>
                Возраст
            </th>
                      
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Подробно", "DetailsCandidate", new { id=item.CandidateId })%> 
                
            </td>
            
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: item.SecondName %>
            </td>
            <td>
                <%: item.Age %>
            </td>
           
            
        </tr>
    
    <% } %>

    </table>

   

</asp:Content>

