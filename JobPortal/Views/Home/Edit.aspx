<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.DAL.Vacancy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <script language="javascript" type="text/javascript">

      $(function () {
          //$.datepicker.formatDate('mm.dd.yy');
          // turn the birthdate input into a date selector
          $('#StartDate').datepicker({ dateFormat: 'dd.mm.yy' });
          $('#EndDate').datepicker({ dateFormat: 'dd.mm.yy' });
          $("#commentForm").validate();
      })		
    </script>


    <h2>Редактирование</h2>

    <% using (Html.BeginForm("Edit", "Home", FormMethod.Post, new { @id = "commentForm" }))
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
                       
            <div class="editor-label">
               Название вакансии:
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name, new { @class = "required" })%>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            </br>
            <div class="editor-label">
               Сфера деятельности:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.SphereActivityId, (List<SelectListItem>)ViewData["SphereActivity"])%>
                <%: Html.ValidationMessageFor(model => model.SphereActivityId) %>
            </div>
            </br>
            <div class="editor-label">
            Должность:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.PostId, (List<SelectListItem>)ViewData["Posts"]) %>
                <%: Html.ValidationMessageFor(model => model.PostId) %>
            </div>
            </br>
              <div>
                Дата выхода на работу:
            </div>
          <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StartDate, new { @class = "required" })%>
                <%: Html.ValidationMessageFor(model => model.StartDate) %>
            </div>
            </br>
            <div class="editor-label">
                Дата окончания действия вакансии:
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EndDate, String.Format("{0:g}", Model.EndDate, new { @class = "required" }))%>
                <%: Html.ValidationMessageFor(model => model.EndDate) %>
            </div>

            </br>
            <div class="editor-field">
               Заработная плата от
                <%: Html.DropDownListFor(model => model.WagesFrom, (List<SelectListItem>)ViewData["Salary"])%>
                <%: Html.ValidationMessageFor(model => model.WagesFrom) %>
                до
                <%: Html.DropDownListFor(model => model.WagesUntil, (List<SelectListItem>)ViewData["Salary"])%>
                <%: Html.ValidationMessageFor(model => model.WagesUntil) %>
            </div>
            </br>
             <div class="editor-label">
                Описание:
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description, new { @class = "required" })%>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            </br>
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

  

</asp:Content>

