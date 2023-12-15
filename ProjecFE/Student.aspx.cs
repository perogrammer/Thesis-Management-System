using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjecFE
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentID"] != null)
            {
                // Retrieve the value of the session variable
                int studentID = Convert.ToInt32(Session["StudentID"]);
                Response.Write($"<script>alert('{studentID}') </script>");
                // Now you can use the studentID in your logic
                // For example, you can display it or use it in database queries
            }
        }
    }
}