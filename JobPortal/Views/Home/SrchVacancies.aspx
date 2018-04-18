<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.Srch>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SrchVacancies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Поиск вакансии</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
           
            
            <div class="editor-label">
                Название вакансии
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            </br>
            <div class="editor-label">
               Сфера деятельности
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.SphereActivity, (List<SelectListItem>)ViewData["SphereActivity"],"Все")%>
                <%: Html.ValidationMessageFor(model => model.SphereActivity) %>
            </div>
            </br>
              <div class="editor-label">
              Должность
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Post, (List<SelectListItem>)ViewData["Posts"],"Все")%>
                <%: Html.ValidationMessageFor(model => model.Post) %>
            </div>
            </br>
            <div class="editor-label">
               Зарабатная плата от:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.WagesFrom, (List<SelectListItem>)ViewData["Salary"],"")%>
                <%: Html.ValidationMessageFor(model => model.WagesFrom) %>
            </div>
            
            <div class="editor-label">
               до
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.WagesUntil,(List<SelectListItem>)ViewData["Salary"],"") %>
                <%: Html.ValidationMessageFor(model => model.WagesUntil) %>
            </div>
            </br>
            <p>
                <input type="submit" value="Поиск вакансии" />
            </p>
        </fieldset>

    <% } %>

   

    

</asp:Content>

