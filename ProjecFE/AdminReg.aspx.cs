using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjecFE
{
    public partial class AdminReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "SELECT UserName FROM Users WHERE UserID IN (SELECT UserID FROM Students);";
                gvNestedSubquery1.DataSource = ExecuteQuery(query);
                gvNestedSubquery1.DataBind();
                //
                query = "SELECT UserName FROM Users WHERE UserID IN (SELECT UserID FROM Administrators WHERE UserID IN (SELECT UserID FROM ProposalReviews WHERE ApprovalStatus = 'Approved'));";
                gvNestedSubquery2.DataSource = ExecuteQuery(query);
                gvNestedSubquery2.DataBind();
                //
                query = "SELECT UserName FROM Users WHERE UserID IN (SELECT UserID FROM ThesisSupervisors WHERE UserID IN (SELECT UserID FROM Students WHERE StudentID IN (SELECT StudentID FROM ThesisProposals WHERE Status = 'Pending')));";
                gvNestedSubquery3.DataSource = ExecuteQuery(query);
                gvNestedSubquery3.DataBind();
                //
                query = "SELECT StudentID, COUNT(ProposalID) AS ProposalCount FROM ThesisProposals GROUP BY StudentID HAVING COUNT(ProposalID) > 2;";
                gvAggregateGroupBy1.DataSource = ExecuteQuery(query);
                gvAggregateGroupBy1.DataBind();
                //
                query = "SELECT PanelMemberID, AVG(CASE WHEN ApprovalStatus = 'Approved' THEN 1 ELSE 0 END) AS AvgApproval FROM ProposalReviews GROUP BY PanelMemberID;";
                gvAggregateGroupBy2.DataSource = ExecuteQuery(query);
                gvAggregateGroupBy2.DataBind();
                //
                query = "SELECT ThesisProposals.ProposalID, ThesisProposals.Title, Students.StudentID FROM ThesisProposals JOIN Students ON ThesisProposals.StudentID = Students.StudentID;";
                gvTwoTableJoin1.DataSource = ExecuteQuery(query);
                gvTwoTableJoin1.DataBind();

                query = "SELECT ProposalReviews.ReviewID, ProposalReviews.Comments, PanelMembers.PanelMemberID FROM ProposalReviews JOIN PanelMembers ON ProposalReviews.PanelMemberID = PanelMembers.PanelMemberID; ";
                gvTwoTableJoin2.DataSource = ExecuteQuery(query);
                gvTwoTableJoin2.DataBind();

                query = "SELECT ThesisProposals.ProposalID, ThesisProposals.Title, Students.StudentID, Users.UserName AS SupervisorName FROM ThesisProposals JOIN Students ON ThesisProposals.StudentID = Students.StudentID JOIN Users ON Students.UserID = Users.UserID; ";
                gvThreeTableJoin1.DataSource = ExecuteQuery(query);
                gvThreeTableJoin1.DataBind();

                query = "SELECT ThesisProposals.ProposalID, ThesisProposals.Title, Students.StudentID, Users.UserName AS SupervisorName FROM ThesisProposals JOIN Students ON ThesisProposals.StudentID = Students.StudentID JOIN Users ON Students.UserID = Users.UserID; ";
                gvThreeTableJoin2.DataSource = ExecuteQuery(query);
                gvThreeTableJoin2.DataBind();

                query = "SELECT ThesisProposals.ProposalID, ThesisProposals.Title, Students.StudentID, Users.UserName AS SupervisorName, Administrators.AdminID FROM ThesisProposals JOIN Students ON ThesisProposals.StudentID = Students.StudentID JOIN Users ON Students.UserID = Users.UserID JOIN Administrators ON Users.UserID = Administrators.UserID; ";
                gvFourTableJoin1.DataSource = ExecuteQuery(query);
                gvFourTableJoin1.DataBind();

                query = "SELECT ProposalReviews.ReviewID, ProposalReviews.Comments, PanelMembers.PanelMemberID, UserRoles.RoleID, Users.UserName AS SupervisorName FROM ProposalReviews JOIN PanelMembers ON ProposalReviews.PanelMemberID = PanelMembers.PanelMemberID JOIN Users ON PanelMembers.UserID = Users.UserID JOIN UserRoles ON Users.UserID = UserRoles.UserID;\r\n ";
                gvFourTableJoin2.DataSource = ExecuteQuery(query);
                gvFourTableJoin2.DataBind();

               
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }

                    // Check if the DataTable is empty
                    if (dataTable.Rows.Count == 0)
                    {
                        // If empty, add a dummy row with the same columns
                        dataTable.Rows.Add(dataTable.NewRow());
                    }

                    return dataTable;
                }
            }
        }
    }
}
