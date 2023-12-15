using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace ProjecFE
{
    public partial class SupervisorReg : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Retrieve input values
            string username = Request.Form["txtUsername"];
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];
            string confirmPassword = Request.Form["txtConfirmPassword"];

            int userId = 0;
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                DisplayError("Please fill in all fields.");
                return;
            }

            if (!IsValidEmail(email))
            {
                DisplayError("Invalid email format. Please use an email ending with @nu.edu.pk.");
                return;
            }

            if (!IsValidPassword(password))
            {
                DisplayError("Password should be more than 7 characters");
                return;
            }

            if (password != confirmPassword)
            {
                DisplayError("Password and Confirm Password do not match.");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert data into the Users table
                    string insertUserQuery = "INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(insertUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query and retrieve the identity value
                        userId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Insert data into the Students table
                    string insertStudentQuery = "INSERT INTO ThesisSupervisors (UserID) VALUES (@UserID);";

                    using (SqlCommand command = new SqlCommand(insertStudentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        // Execute the query to insert into Students table
                        command.ExecuteNonQuery();
                    }

                    // Determine RoleID for "Student" dynamically
                    string panelMemberRoleName = "Supervisor";
                    int roleIdForPanel = GetRoleIdForRoleName(connection, panelMemberRoleName);

                    // Insert data into the UserRoles table
                    string insertUserRoleQuery = "INSERT INTO UserRoles (UserID, RoleID) VALUES (@UserID, @RoleID);";

                    using (SqlCommand command = new SqlCommand(insertUserRoleQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@RoleID", roleIdForPanel);

                        // Execute the query to insert into UserRoles table
                        command.ExecuteNonQuery();
                    }

                    // Continue with other database operations as needed

                    // Display a success message with the userId
                    Response.Write($"<script>alert('User registration successful. UserID: {userId}');</script>");
                    //lblMessage.Text = $"User registration successful. UserID: {userId}";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    //lblMessage.Visible = true;
                    Response.Write("<script>window.location.href='Supervisor_login.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                // Log or display the actual exception message
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                //lblMessage.Text = $"Error: {ex.Message}";
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Visible = true;
            }
        }

        private int GetRoleIdForRoleName(SqlConnection connection, string roleName)
        {
            // Fetch the RoleID for the given roleName from the Roles table
            string selectRoleQuery = "SELECT RoleID FROM Roles WHERE RoleName = @RoleName;";

            using (SqlCommand command = new SqlCommand(selectRoleQuery, connection))
            {
                command.Parameters.AddWithValue("@RoleName", roleName);

                // Execute the query and retrieve the RoleID
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        private void DisplayError(string errorMessage)
        {
            //Response.Write($"<script>alert('{errorMessage}');</script>");
            
        }

        private bool IsValidEmail(string email)
        {
            // Add your email validation logic here
            // For example, check if it ends with "@nu.edu.pk"
            return email.EndsWith("@nu.edu.pk", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsValidPassword(string password)
        {
            // Add your password validation logic here
            // For example, check minimum length, uppercase, lowercase, digits, etc.
            return password.Length >= 8; // Minimum 8 characters for demonstration
        }
    }
}
