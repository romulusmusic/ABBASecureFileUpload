<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ABBASecureFileUpload._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ABBA Customer Portal</h1>
        <p class="lead">Use this secure portal to transfer files to and from ABBA Management.</p>
    </div>

            <script type="text/javascript">  
                function uploadcomplete() {
                    alert("successfully uploaded!");
                }

                function uploadcompleteAll() {
                    alert("successfully uploaded All Files!");
                }
                function uploaderror() {
                    alert("some error occured while uploading file!");
                }
            </script> 

    <div class="row">
        <div class="col-md-4">
            <asp:DropDownList ID="ddlCompanyDirectories" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyDirectories_SelectedIndexChanged" >
                <asp:ListItem>Select Company Folder</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" OnClientUploadComplete="uploadcomplete" OnClientUploadCompleteAll="uploadcompleteAll" OnClientUploadError="uploaderror" OnUploadComplete="AjaxFileUpload1_OnUploadComplete"  Mode="Auto" runat="server" />
        </div>
        <div class="col-md-4">
            <asp:Label Text="If Company Folder does not exist, enter it here and click the Create Company Folder button" runat="server" />
            <asp:TextBox ID="txtNewDirectoryName"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtNewDirectoryName" ID="CreatFolderTxtValidator" runat="server" ErrorMessage="Company Folder Name required when creating a folder"></asp:RequiredFieldValidator>          
            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="CreatFolderTxtValidator" runat="server"></ajaxToolkit:ValidatorCalloutExtender>
            <asp:Button ID="CreateCompanyFolder" runat="server" Text="Create Company Folder" OnClick="CreateCompanyFolder_Click" />
        </div>
        <div class="col-md-4">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </div>

</asp:Content>
