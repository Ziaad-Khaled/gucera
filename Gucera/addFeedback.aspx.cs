using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gucera
{
    public partial class addFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("This Feature Is Only Available After Login!");
                return;
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            int cid;
            string comm;
            try
            {
                cid = Int16.Parse(courseId.Text);
                comm = comment.Value;
            }
            catch (System.Exception)
            {
                Response.Write("Please Enter a valid courseId!");
                return;
            }
            SqlCommand feedback = new SqlCommand("addFeedback", conn);
            feedback.CommandType = CommandType.StoredProcedure;
            int sid = Int16.Parse(Session["user"].ToString());
            feedback.Parameters.Add(new SqlParameter("@sid", sid));
            feedback.Parameters.Add(new SqlParameter("@cid", cid));
            feedback.Parameters.Add(new SqlParameter("@comment", comm));

            conn.Open();
            //feedback.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Feedback", conn);
            int count1 = (Int32)cmd.ExecuteScalar();
            feedback.ExecuteNonQuery();
            int count2 = (Int32)cmd.ExecuteScalar();

            conn.Close();
            
            if (count1 == count2)
                Response.Write("student not enrolled in course");
            else
                Response.Write("Feedback Added");
        }
    }
}