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
    public partial class acceptPending : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CourseAccept(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("This Feature Is Only Available After Login!");
                return;
            }
            bool success = false; // flag to check if course exists 
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand adminacceptcourse = new SqlCommand("AdminAcceptRejectCourse", conn);
            adminacceptcourse.CommandType = CommandType.StoredProcedure;
            try
            {
                int cid = Int16.Parse(CourseID.Text);
                int adminID = Int16.Parse(Session["user"].ToString());
                adminacceptcourse.Parameters.Add(new SqlParameter("@courseId", cid));
                adminacceptcourse.Parameters.Add(new SqlParameter("@adminid", adminID));
                SqlCommand Checkacceptance = new SqlCommand("SELECT COUNT(*) FROM Course Where accepted = 1 and id =" + cid, conn);
                
                conn.Open();
                int check = (Int32)Checkacceptance.ExecuteScalar(); // to check if course was already accepted
                if (check == 1)
                {
                    Response.Write("Course " + cid + " Is Already Accepted!");
                    return; // if course was already accepeted we dont want it to be accpeted again
                }
                try
                {
                    int rowsUpdated = adminacceptcourse.ExecuteNonQuery(); //checks number of rows updated by the query
                    if (rowsUpdated > 0) 
                    {
                        success = true;
                    }
                    if (success)
                    {
         
                        Response.Write("Course " + cid + " Has Been Accepted Successfully!");
                       
                    }
                    else
                    {
                        Response.Write("This Course Does Not Exist!");
                    }
                }
                catch (SqlException)
                {
                    Response.Write("Cannot Accept This Course!");
                }
                conn.Close();

            }
            catch (Exception)
            {
                Response.Write("Invalid Input! Kindly Make Sure You Are Entering A Course ID");
            }




        }
    }
}