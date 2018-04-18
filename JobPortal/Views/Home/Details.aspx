<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.DAL.Vacancy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    
        <% Html.RenderPartial("Detail"); %>
  

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

        <% if (Roles.IsUserInRole("company")) 
         {%>
          <% 
              if (((IEnumerable<Logic.DAL.Candidate>)ViewData["Users"]).Count()>0)          
              { %> <h3>Users send requests: </h3>
            <%   foreach (Logic.DAL.Candidate item in (IEnumerable<Logic.DAL.Candidate>)ViewData["Users"])
            {
            %>   
            <%:Html.ActionLink(item.FirstName.ToString(),"DetailsCandidate", new { id = item.CandidateId})%>   
                   
          |        
       <%}}
              else {%><%: Html.Label("Users not send requests")%><% };
         } %>



   
</asp:Content>

