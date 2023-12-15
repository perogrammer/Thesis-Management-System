using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace ProjecFE
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string username = Request.Form["txtUsername"];
            string password = Request.Form["txtPassword"];


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
                            query = "SELECT COUNT(*) FROM Administrators WHERE UserID = @UserID;";
                            command.Parameters.Clear();
                            command.CommandText = query;
                            command.Parameters.AddWithValue("@UserID", userId);

                            int studentCount = (int)command.ExecuteScalar();

                            if (studentCount > 0)
                            {
                                // Successful login for a student
                                Response.Write("<script>alert('Logged in as Administrator.');</script>");
                                // Redirect to the Student.aspx or another page after successful login
                                Response.Redirect("Admin.aspx");
                            }
                            else
                            {
                                // Successful login for a non-student user
                                Response.Write("<script>alert('Login unsuccessful.');</script>");
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
              
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }


    }
}