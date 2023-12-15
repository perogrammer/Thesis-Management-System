using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ProjecFE
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve student ID from the session
                if (Session["StudentID"] != null)
                {
                    int studentID = Convert.ToInt32(Session["StudentID"]);

                    // Get thesis details based on student ID
                    ThesisDetails thesisDetails = GetThesisDetailsByStudentID(studentID);

                    // Check if thesisDetails is not null
                    if (thesisDetails != null)
                    {
                        // Populate the controls with existing data
                        txtTitle.Text = thesisDetails.Title;
                        txtThesisContents.Text = ReadThesisContents(thesisDetails.FilePath);
                    }
                    else
                    {
                        // No thesis found for the student
                        Response.Write("<script>alert('No thesis found for the student.');</script>");
                    }
                }
                else
                {
                    // Student ID not found in session
                    Response.Write("<script>alert('Student ID not found in session.');</script>");
                }
            }
        }
        
        // Method to get thesis details based on student ID
        private ThesisDetails GetThesisDetailsByStudentID(int studentID)
        {
            ThesisDetails thesisDetails = null;
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Title, FilePath FROM ThesisProposals WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            thesisDetails = new ThesisDetails
                            {
                                Title = reader["Title"].ToString(),
                                FilePath = reader["FilePath"].ToString()
                            };
                        }
                    }
                }
            }

            return thesisDetails;
        }

        // Method to read the contents of the thesis file
        private string ReadThesisContents(string filePath)
        {
            string fileContents = string.Empty;

            try
            {
                // Read the contents of the file
                fileContents = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // Handle the exception (file not found or other IO errors)
                Response.Write($"<script>alert('Error reading file: {ex.Message}');</script>");
            }

            return fileContents;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Update the database with the new title
            UpdateTitleInDatabase(txtTitle.Text);

            // Update the file with the new contents
            UpdateContentsInFile(txtThesisContents.Text);

            // Optionally, you can redirect to a confirmation page or perform other actions
            Response.Redirect("Edited.aspx");
        }

        // Method to update the title in the database
        private void UpdateTitleInDatabase(string newTitle)
        {
            int studentID = Convert.ToInt32(Session["StudentID"]);
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ThesisProposals SET Title = @Title WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", newTitle);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to update the contents in the file
        private void UpdateContentsInFile(string newContents)
        {
            int studentID = Convert.ToInt32(Session["StudentID"]);
            string filePath = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FilePath FROM ThesisProposals WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        filePath = result.ToString();
                    }
                }
            }
            try
            {
                // Write the new contents to the file
                File.WriteAllText(filePath, newContents);
            }
            catch (Exception ex)
            {
                // Handle the exception (file not found or other IO errors)
                Response.Write($"<script>alert('Error updating file contents: {ex.Message}');</script>");
            }
        }
    }

    // Class to store thesis details
    public class ThesisDetails
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
    }
}
