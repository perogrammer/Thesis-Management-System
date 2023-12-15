using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace ProjecFE
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the username and password match in the database
                    string query = "SELECT UserID FROM Users WHERE UserName = @UserName AND Password = @Password;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Retrieve UserID if a matching user is found
                        int userId = Convert.ToInt32(command.ExecuteScalar());

                        if (userId > 0)
                        {
                            // Check if the user is a student
                            query = "SELECT COUNT(*) FROM Students WHERE UserID = @UserID;";
                            command.Parameters.Clear();
                            command.CommandText = query;
                            command.Parameters.AddWithValue("@UserID", userId);

                            int studentCount = (int)command.ExecuteScalar();

                            if (studentCount > 0)
                            {
                                query = "SELECT StudentID FROM Students WHERE UserID = @UserID;";
                                command.Parameters.Clear();
                                command.CommandText = query;
                                command.Parameters.AddWithValue("@UserID", userId);

                                Session["StudentID"] = (int)command.ExecuteScalar();
                                // Successful login for a student
                                Response.Write("<script>alert('Logged in as Student.');</script>");
                                // Redirect to the Student.aspx or another page after successful login
                                Response.Redirect("Student.aspx");
                            }
                            else
                            {
                                // unSuccessful login for a student user
                                Response.Write("<script>alert('Login unsuccessful.');</script>");
                                // Redirect to the appropriate page for non-student users
                                // For example: Response.Redirect("NonStudentPage.aspx");
                                return;
                            }
                        }
                        else
                        {
                            // Invalid login credentials
                            Response.Write("<script>alert('Invalid username or password.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the actual exception message
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

       
    }
}