using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABBASecureFileUpload
{
    public partial class _Default : Page
    {
        private static string selectedfilePath;
        private static string saveAsfilePath;
        private static string filePath;
        private static string rootdir;

        private static string[] dirNameArray;
        protected int dirsLengthOffset;
        private static string selectedRootdir;
        private static string[] files;
        private static string[] dirs;
        private static DateTime[] filesCreationTime;
        private static string[] gridViewMessage = new string[1];
        private static string[] fileNameArray;
        // private static int[] fileNameArraySize;


        protected void Page_Load(object sender, EventArgs e)
        {
            filePath = "~/UploadedFiles/";
            rootdir = MapPath(filePath);
            // get list of directories
            FormatAndDisplayCompanyDirectory();
            // get list of files in directory
            if (ddlCompanyDirectories.SelectedValue.ToString() != "Select Company Folder")
            { FormatAndDislayUploadedFiles(); }
                


            //filePath = "~/UploadedFiles/";
            //rootdir = MapPath(filePath);
            // get list of directories

            //dirs = Directory.GetDirectories(rootdir);
            //dirNameArray = new string[dirs.Length];
            //for (int i = 0; i < dirs.Length; i++)

            //{
            //    dirNameArray[i] = dirs[i].Split('\\').Last();
            //}

            ////Console.WriteLine(String.Join(Environment.NewLine, dirs));

            ////Display Company Directories in Dropdown List
            //ddlCompanyDirectories.DataSource = dirNameArray;
            //if (ddlCompanyDirectories.Items.Count <= 1)
            //{
            //    ddlCompanyDirectories.DataBind();
            //}
            ////List Directory Files

            //selectedfilePath = "/UploadedFiles/" + ddlCompanyDirectories.SelectedValue + "/";
            //selectedRootdir = MapPath(selectedfilePath);

            //// get list of files
            //files = Directory.GetFiles(selectedRootdir);

            //fileNameArray = new string[files.Length];
            //////filesCreationTime = DateTime[] = Directory.GetCreationTime(selectedRootdir);


            //if (files.Length > 0)
            //{
            //    for (int i = 0; i < files.Length; i++)

            //    {
            //        var info = Directory.GetFiles(selectedRootdir);
            //        fileNameArray[i] = files[i].Split('\\').Last();
            //    }

            //    GridView1.DataSource = fileNameArray;
            //    GridView1.DataBind();
            //}
            //else
            //{
            //    gridViewMessage[0] = ddlCompanyDirectories.SelectedValue + "Has no files at this time";
            //    GridView1.DataSource = gridViewMessage;
            //    GridView1.DataBind();
            //}

        }
        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            // Generate file path
            saveAsfilePath = selectedfilePath + e.FileName;

            // Save upload file to the file system
            AjaxFileUpload1.SaveAs(MapPath(saveAsfilePath));

        }
        protected void AjaxFileUpload1_OnUploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            //// Generate file path
            saveAsfilePath = selectedfilePath + e.FileName;

            //// Save upload file to the file system
            AjaxFileUpload1.SaveAs(MapPath(saveAsfilePath));

            

        }
        //
        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            //// Generate file path
            saveAsfilePath = selectedfilePath + e.FileName;

            //// Save upload file to the file system
            AjaxFileUpload1.SaveAs(MapPath(saveAsfilePath));

            
        }
        protected void AjaxFileUpload1_UploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            //// Generate file path
            saveAsfilePath = selectedfilePath + e.FileName;

            //// Save upload file to the file system
            AjaxFileUpload1.SaveAs(MapPath(saveAsfilePath));
            FormatAndDislayUploadedFiles();

        }
        protected void ddlCompanyDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormatAndDisplayCompanyDirectory();
            //selectedfilePath = "~/UploadedFiles/" + ddlCompanyDirectories.SelectedValue + "/";
            ////List Directory Files

            //selectedfilePath = "~/UploadedFiles/" + ddlCompanyDirectories.SelectedValue + "/";
            //selectedRootdir = MapPath(selectedfilePath);

            //// get list of files
            //files = Directory.GetFiles(selectedRootdir);
            //// Parse File names from files array
            //fileNameArray = new string[files.Length];


            //for (int i = 0; i < files.Length; i++)

            //{
            //    fileNameArray[i] = files[i].Split('\\').Last();
            //}


            //if (fileNameArray.Length > 0)
            //{
            //    GridView1.DataSource = fileNameArray;
            //    GridView1.DataBind();
            //}
            //else
            //{
            //    gridViewMessage[0] = ddlCompanyDirectories.SelectedValue + " has no files at this time!";
            //    GridView1.DataSource = gridViewMessage;
            //    GridView1.DataBind();
            //}

        }
        protected void CreateCompanyFolder_Click(object sender, EventArgs e)
        {
            
                string root = "~/UploadedFiles/";
                string subdir = MapPath(root + txtNewDirectoryName.Text.ToString() + "\\");
            // If directory does not exist, create it.  
            if (subdir != "")
            {
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                // Load Company Directory DDL
                filePath = "~/UploadedFiles/";
                rootdir = MapPath(filePath);
                // get list of directories

                files = Directory.GetDirectories(rootdir);
                dirNameArray = new string[files.Length];
                for (int i = 0; i < files.Length; i++)

                {
                    dirNameArray[i] = files[i].Split('\\').Last();
                }
                ddlCompanyDirectories.DataSource = dirNameArray;
                ddlCompanyDirectories.DataBind();
                ddlCompanyDirectories.SelectedValue = txtNewDirectoryName.Text.ToString();
                FormatAndDislayUploadedFiles();
                txtNewDirectoryName.Text = "";
            }
        }
        protected void FormatAndDisplayCompanyDirectory()
        {
            filePath = "~/UploadedFiles/";
            rootdir = MapPath(filePath);
            //get list of directories

            dirs = Directory.GetDirectories(rootdir);
            dirNameArray = new string[dirs.Length + 1];
            for (int i = 0; i < dirs.Length +1; i++)

            {
                if (i is 0) { dirNameArray[i] = "Select Company Folder"; }
                else
                { dirNameArray[i] = dirs[i-1].Split('\\').Last(); }
            }

            //Console.WriteLine(String.Join(Environment.NewLine, dirs));

            //Display Company Directories in Dropdown List
            ddlCompanyDirectories.DataSource = dirNameArray;
            if (ddlCompanyDirectories.Items.Count <= 1)
            {
                ddlCompanyDirectories.DataBind();
            }
        }
        protected void FormatAndDislayUploadedFiles()
        {
            // Load Company Files
            // set directory path to selected company folder
            selectedfilePath = "/UploadedFiles/" + ddlCompanyDirectories.SelectedValue + "/";
            selectedRootdir = MapPath(selectedfilePath);

            // get list of files
            files = Directory.GetFiles(selectedRootdir);
            // Parse File names from files array
            fileNameArray = new string[files.Length];


            for (int i = 0; i < files.Length; i++)

            {
                fileNameArray[i] = files[i].Split('\\').Last();
            }


            if (fileNameArray.Length > 0)
            {
                GridView1.DataSource = fileNameArray;
                GridView1.DataBind();
            }
            else
            {
                gridViewMessage[0] = ddlCompanyDirectories.SelectedValue + " has no files at this time!";
                GridView1.DataSource = gridViewMessage;
                GridView1.DataBind();
            }
        }
    }
}