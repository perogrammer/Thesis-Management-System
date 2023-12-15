using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace ProjecFE
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string title = txtThesisLink.Text;
            int studentId = Convert.ToInt32(Session["StudentID"]);
            //Response.Write($"<script>alert('Error Submitting thesis{title}');</script>");
            // Validate input
            if (string.IsNullOrEmpty(title))
            {
                DisplayError("Please enter the thesis title.");
                return;
            }

            // Check if a file is selected
            if (fileThesis.HasFile)
            {
                // Save the file to the server
                string fileName = Path.GetFileName(fileThesis.FileName);
                string filePath = Server.MapPath("~/Thesis Files/") + fileName;

                try
                {
                    fileThesis.SaveAs(filePath);

                    // Insert data into the ThesisProposals table
                    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO ThesisProposals (StudentID, Title, FilePath, Status) VALUES (@StudentID, @Title, @FilePath, @Status);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@FilePath", filePath);
                        command.Parameters.AddWithValue("@Status", "Pending"); // Set the initial status as needed

                        command.ExecuteNonQuery();
                    }


                        DisplaySuccess("Thesis submitted successfully!");
                        Response.Redirect("SubmitAdd.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}');</script>");
                }
            }
            else
            {
                DisplayError("Please select a thesis file.");
            }
        }

        private void DisplayError(string errorMessage)
        {
            // Display error message
            Response.Write($"<script>alert('{errorMessage}');</script>");
        }

        private void DisplaySuccess(string successMessage)
        {
            // Display success message
            Response.Write($"<script>alert('{successMessage}');</script>");
        }
    }
}