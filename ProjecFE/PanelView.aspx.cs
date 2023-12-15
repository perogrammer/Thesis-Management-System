using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjecFE
{
    public partial class PanelView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the DropDownList with file names from the "Thesis Files" folder
                PopulateThesisFilesDropDown();
            }
        }

        protected void ddlThesisFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected file name
            string selectedFileName = ddlThesisFiles.SelectedValue;

            // Get the file path
            string filePath = Server.MapPath("~/Thesis Files/" + selectedFileName);

            // Read and display the contents of the file
            DisplayFileContents(filePath);

            // Retrieve ProposalID based on the selected file path and store it in a session variable
            string proposalID = GetProposalIDByFilePath(filePath);

            if (!string.IsNullOrEmpty(proposalID))
            {
                Session["ProposalID"] = proposalID;
            }
            else
            {
                // Handle the case where ProposalID is not found
                Response.Write("<script>alert('ProposalID not found for the selected file.');</script>");
            }
        }

        private string GetProposalIDByFilePath(string filePath)
        {
            string proposalID = string.Empty;

            // Replace the connection string with your actual connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Query to retrieve ProposalID based on file path
            string query = "SELECT ProposalID FROM ThesisProposals WHERE FilePath = @FilePath";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilePath", filePath);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        proposalID = result.ToString();
                    }
                }
            }

            return proposalID;
        }


        private void PopulateThesisFilesDropDown()
        {
            // Get the physical path of the "Thesis Files" folder
            string folderPath = Server.MapPath("~/Thesis Files/");

            // Get all file names in the folder
            string[] fileNames = Directory.GetFiles(folderPath);
    
            // Create a list to store ListItem objects
            var listItems = new List<ListItem>();

            // Iterate through each file name and add it to the list
            foreach (string fileName in fileNames)
            {
                // Get only the file name without the path
                string shortFileName = Path.GetFileName(fileName);

                // Add a new ListItem to the list
                listItems.Add(new ListItem(shortFileName, shortFileName));
            }

            // Bind the list of ListItem objects to the DropDownList
            ddlThesisFiles.Items.AddRange(listItems.ToArray());

            // Add a default item
            ddlThesisFiles.Items.Insert(0, new ListItem("Select a Thesis File", string.Empty));
        }

        private void DisplayFileContents(string filePath)
        {
            try
            {
                // Read the contents of the file
                string fileContents = File.ReadAllText(filePath);

                // Display the contents (you may adjust this based on your requirements)
                // For now, we'll use a Label control to display the contents
                lblFileContents.Text = fileContents;
            }
            catch (Exception ex)
            {
                // Handle the exception (file not found or other IO errors)
                lblFileContents.Text = "Error reading file: " + ex.Message;
            }
        }
    }
}
