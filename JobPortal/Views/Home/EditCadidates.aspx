<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Logic.DAL.Candidate>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript" type="text/javascript">
    $(function () {
        $("#dialog").dialog({
            autoOpen: false
        });
        $("#commentForm").validate();
        
        $('#dialog_link').click(function () {
            $('#dialog').dialog('open');
         //   $("#upfill").validate();
           // $("#dialog").validate(); 
            return false;
        });
    });

    </script>

    <h2>Редактирование профиля</h2>
   

    <% using (Html.BeginForm("EditCadidates", "Home", FormMethod.Post, new { @id = "commentForm" }))
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
                      
            <div class="editor-label">
                Фамилия:
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FirstName, new { @class = "required" })%>
                <%: Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
           <br/>
            <div class="editor-label">
                Имя:
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SecondName, new { @class = "required" })%>
                <%: Html.ValidationMessageFor(model => model.SecondName) %>
            </div>
           <br/>
            <div class="editor-label">
                Возраст:
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Age, new { @class = "digits required" })%>
                <%: Html.ValidationMessageFor(model => model.Age) %>
            </div>
           <br/>
            <div class="editor-label">
               Текущая сфера деятельности:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.CurrentSphereActivityId, (List<SelectListItem>)ViewData["SphereActivity"], "All")%>
                <%: Html.ValidationMessageFor(model => model.CurrentSphereActivityId) %>
            </div>
           <br/>
             <div class="editor-label">
                Текущая должность:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.CurrentPost, (List<SelectListItem>)ViewData["Posts"], "All")%>
                <%: Html.ValidationMessageFor(model => model.CurrentPost) %>
            </div>
           <br/>
            
            <div class="editor-label">
                Желаемая сфера деятельности:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.DesirableSphereActivityId, (List<SelectListItem>)ViewData["SphereActivity"],"All") %>
                <%: Html.ValidationMessageFor(model => model.DesirableSphereActivityId) %>
            </div>
            
          <br/>
            
            <div class="editor-label">
                    Желаемая должность:
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.DesirablePost, (List<SelectListItem>)ViewData["Posts"], "All")%>
                <%: Html.ValidationMessageFor(model => model.DesirablePost) %>
            </div>
           <br/>
           
            <div class="editor-field">
                Желаемая заработая плата от
                <%: Html.DropDownListFor(model => model.WagesFromId, (List<SelectListItem>)ViewData["Salary"], "")%>
                <%: Html.ValidationMessageFor(model => model.WagesFromId) %>
            до 
             <%: Html.DropDownListFor(model => model.WagesUntilId, (List<SelectListItem>)ViewData["Salary"], "")%>
                <%: Html.ValidationMessageFor(model => model.WagesUntilId) %>
            </div>
            
          <br/>
            

            <p>
                <input type="submit" value="Сохранить." />
            </p>
        </fieldset>

    <% } %>
  
  
    <% var file = ViewData["FileName"];
        if (String.IsNullOrEmpty((String) file))
      { %>  


     <% using (Html.BeginForm("FileUpload", "Files", FormMethod.Post, new {enctype = "multipart/form-data" }))
        {%>
         <div class="editor-label">
             <%: Html.Label("File")%>
         </div>
   <div class="editor-field">         
        <input name="uploadFile" id="uploadFile" type="file" accept="Application/msword" />
        <br/>
        <input type="submit" value="Загрузить резюме." />
        <%: Html.ValidationMessage("uploadFile")%>       
   </div>
	<%}
      	}
      else
      {%>
      <%: Html.ActionLink("Удалить резюме", "Delete","Files")%>
      |
      <a href="#" id="dialog_link">Заменить резюме</a>     
      
     
    
     <% using (Html.BeginForm("FileReplace", "Files", FormMethod.Post, new { id = "dialog", enctype = "multipart/form-data" }))
        {%>
         <div class="editor-label">
             <%: Html.Label("File")%>
         </div>
   <div class="editor-field">         
        <input name="uploadFile" id="File1" type="file" class="required" accept="Application/msword" />
        <br/>
        <input type="submit" value="Upload File" />
        <%: Html.ValidationMessage("uploadFile")%>       
   </div>
	<%}
      } %>
    
   

</asp:Content>

