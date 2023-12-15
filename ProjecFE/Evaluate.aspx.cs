using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace ProjecFE
{
    public partial class Evaluate : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

       

        

       

        protected void btnReject_Click(object sender, EventArgs e)
        {
            // Implement logic to save draft
            SaveEvaluation("Rejected");
        }

        protected void btnSubmitEvaluation_Click(object sender, EventArgs e)
        {
            // Implement logic to submit evaluation
            SaveEvaluation("Approved");
        }
        private bool ProposalExists(int proposalID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ProposalReviews WHERE proposalID = @proposalID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@proposalID", proposalID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void SaveEvaluation(string status)
        {
            // Retrieve values from controls
            string comments = txtComments.Value;
            

            // Retrieve ProposalID and PanelMemberID from session variables
            int proposalID = Convert.ToInt32(Session["ProposalID"]);
            int panelMemberID = Convert.ToInt32(Session["PanelID"]);
            if (ProposalExists(proposalID))
            {
                // Display an alert or handle the error as needed
                Response.Write("<script> alert('Review already exists!');</script>");

                //Response.Redirect("PanelMember.aspx");
                return;
            }
            // Implement logic to save the evaluation in the database
            // For simplicity, just displaying an alert with the gathered information

            // Update the ProposalReviews table with the evaluation information
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProposalReviews (ProposalID, PanelMemberID, Comments, ApprovalStatus) " +
                               "VALUES (@ProposalID, @PanelMemberID, @Comments, @ApprovalStatus)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProposalID", proposalID);
                    command.Parameters.AddWithValue("@PanelMemberID", panelMemberID);
                    command.Parameters.AddWithValue("@Comments", comments);
                    command.Parameters.AddWithValue("@ApprovalStatus", status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Display an alert (you can replace this with your desired logic)
            string alertMessage = $"Evaluation saved. Status: {status}, ProposalID: {proposalID}, PanelMemberID: {panelMemberID}";
            ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('{alertMessage}');", true);
            if(status=="Approved")
                Response.Redirect("Approved.aspx");
            Response.Redirect("PanelMember.aspx");

        }
    }
}            
