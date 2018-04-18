<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.DAL.Candidate>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Сведения о кандидате</h2>

    <fieldset>
         
        <div class="display-label">Фамилия</div>
        <div class="display-field"><%: Model.FirstName %></div>
        </br>
        <div class="display-label">Имя</div>
        <div class="display-field"><%: Model.SecondName %></div>
        </br>
        <div class="display-label">Возраст</div>
        <div class="display-field"><%: Model.Age %></div>
        </br>
        <div class="display-label">Текущая сфера деятельности</div>
        <div class="display-field"><%:  ViewData["CurrentSphereActivity"]%></div>
        </br>
        <div class="display-label">Текущая должность</div>
        <div class="display-field"><%: ViewData["CurrentPost"]%></div>
        </br>
        <div class="display-label">Желаемая сфера деятельности</div>
        <div class="display-field"><%:ViewData["DesirableSphereActivity"]%></div>
        </br>
        <div class="display-label">Желаемая должность</div>
        <div class="display-field"><%: ViewData["DesirablePost"]%></div>
        </br>
        <div class="display-label">Заработная плата от: <%: ViewData["WagesFrom"]%> до <%: ViewData["WagesUntil"]%> </div>
       
         </br>
    <% if (Model.FileName != null)
       {%>
        <%: Html.ActionLink("Загрузить резюме", "Download", new { id = Model.CandidateId, file = Model.FileName })%>
        <%} %>
    </fieldset>
    
</asp:Content>

