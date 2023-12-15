using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ProjecFE
{
    public partial class WithDraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve student ID from the session
                if (Session["StudentID"] != null)
                {
                    int studentID = Convert.ToInt32(Session["StudentID"]);

                    // Get thesis file path based on student ID
                    string filePath = GetThesisFilePathByStudentID(studentID);

                    // Check if filePath is not empty
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        // Display the contents of the file
                        DisplayFileContents(filePath);
                    }
                    else
                    {
                        // No thesis found for the student
                        lblFileContents.Text = "No Thesis found.";
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

        // Method to display the contents of the file
        private void DisplayFileContents(string filePath)
        {
            try
            {
                // Read the contents of the file
                string fileContents = File.ReadAllText(filePath);

                // Display the contents (you may adjust this based on your requirements)
                lblFileContents.Text = fileContents;
            }
            catch (Exception ex)
            {
                // Handle the exception (file not found or other IO errors)
                Response.Write($"<script>alert('Error reading file: {ex.Message}');</script>");
            }
        }
        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            // Retrieve student ID from the session
            if (Session["StudentID"] != null)
            {
                int studentID = Convert.ToInt32(Session["StudentID"]);

                // Get thesis file path based on student ID
                string filePath = GetThesisFilePathByStudentID(studentID);

                // Check if filePath is not empty
                if (!string.IsNullOrEmpty(filePath))
                {
                    // Delete the thesis record from the database
                    if (WithdrawThesis(studentID))
                    {
                        // Display success message
                        Response.Write("<script>alert('Thesis withdrawn successfully.');</script>");
                        lblFileContents.Text = "Thesis withdrawn successfully.";
                        Response.Redirect("Withdrawn.aspx");
                    }
                    else
                    {
                        // Display error message
                        Response.Write("<script>alert('Error withdrawing thesis.');</script>");
                        lblFileContents.Text = "Error withdrawing thesis.";
                        Response.Redirect("Student.aspx");
                    }
                }
                else
                {
                    // No thesis found for the student
                    lblFileContents.Text = "No Thesis found.";
                    
                    Response.Redirect("Student.aspx");
                }
            }
            else
            {
                // Student ID not found in session
                Response.Write("<script>alert('Student ID not found in session.');</script>");
            }
        }

        // Method to withdraw the thesis from the database
        private bool WithdrawThesis(int studentID)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ThesisProposals WHERE StudentID = @StudentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Response.Write($"<script>alert('Error withdrawing thesis: {ex.Message}');</script>");
                return false;
            }
        }
        private string GetThesisFilePathByStudentID(int studentID)
        {
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

            return filePath;
        }
    }
}