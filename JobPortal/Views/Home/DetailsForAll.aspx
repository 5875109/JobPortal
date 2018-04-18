<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.DAL.Vacancy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <fieldset>
        <legend>Сведения о вакансии</legend>
      <% Html.RenderPartial("Detail"); %>
        
    </fieldset>
     <% if (Roles.IsUserInRole("candidate"))
      {
          if ((Boolean)ViewData["request"])
          { %>
   <%: Html.ActionLink("Deletet request", "DeleteRequest", new { id = Model.VacancyId })%>
   <% }
          else
          { %>
   <%: Html.ActionLink("Send reques", "SendRequest", new { id = Model.VacancyId })%>
   <%}
      }%>

</asp:Content>

