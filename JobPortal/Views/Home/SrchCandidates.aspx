<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.Srch>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SrchVacancies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Поиск кандидата</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            
                    
            <div class="editor-label">
               Текущая сфера деятельности
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.SphereActivity, (List<SelectListItem>)ViewData["SphereActivity"],"Все")%>
                <%: Html.ValidationMessageFor(model => model.SphereActivity) %>
            </div>
            </br>
              <div class="editor-label">
                Текущая должность
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Post, (List<SelectListItem>)ViewData["Posts"],"Все")%>
                <%: Html.ValidationMessageFor(model => model.Post) %>
            </div>
            </br>
              <div class="editor-label">
              Желаемая сфера деятельности
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.DesirableSphereActivity, (List<SelectListItem>)ViewData["SphereActivity"],"Все")%>
                <%: Html.ValidationMessageFor(model => model.DesirableSphereActivity)%>
            </div>
             </br>
             <div class="editor-label">
               Желаемая должность
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.DesirablePost, (List<SelectListItem>)ViewData["Posts"],"Все")%>
                <%: Html.ValidationMessageFor(model => model.DesirablePost) %>
            </div>
            </br>
            <div class="editor-label">
               Заработная плата от:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.WagesFrom, (List<SelectListItem>)ViewData["Salary"],"")%>
                <%: Html.ValidationMessageFor(model => model.WagesFrom) %>
            </div>
            
            <div class="editor-label">
                до:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.WagesUntil,(List<SelectListItem>)ViewData["Salary"],"") %>
                <%: Html.ValidationMessageFor(model => model.WagesUntil) %>
            </div>
            </br>
            <p>
                <input type="submit" value="Поиск кандидата" />
            </p>
        </fieldset>

    <% } %>

   
    

</asp:Content>

