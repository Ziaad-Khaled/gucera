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
    public partial class submitAssign : System.Web.UI.Page
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
            string type;
            int assignnumber;
            if (courseId.Text == "" || AssignmentType.Text=="" || AssignmentNumber.Text== "")
            {
                Response.Write("There is an empty field!");
                return;
            }
            try
            {
                cid = Int16.Parse(courseId.Text);
                type = AssignmentType.Text;
                assignnumber = Int16.Parse(AssignmentNumber.Text);
            }
            catch (System.Exception)
            {
                Response.Write("Please Enter valid records!");
                return;
            }
           
            SqlCommand certificate = new SqlCommand("submitAssign", conn);
            int sid;
            certificate.CommandType = CommandType.StoredProcedure;
            try
            {
               sid = Int16.Parse(Session["user"].ToString());
            }
            catch (System.Exception)
            {
                Response.Write("You haven't been logged in!");
                return;
            }


            certificate.Parameters.Add(new SqlParameter("@sid", sid));
            certificate.Parameters.Add(new SqlParameter("@cid", cid));
            certificate.Parameters.Add(new SqlParameter("@assignType", type));
            certificate.Parameters.Add(new SqlParameter("@assignnumber", assignnumber));

            conn.Open();
            //Response.Write("submitted successfully");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM StudentTakeAssignment", conn);
            int count1 = (Int32)cmd.ExecuteScalar();
            try 
            {
                certificate.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
               if(ex.Number == 2627)
                    Response.Write("The assignment has been submitted before.");
               else
               {
                    Response.Write("Not enrolled in course");
                }
                    
                
                return;
            }
            
            int count2 = (Int32)cmd.ExecuteScalar();

            conn.Close();

            if (count1 == count2)
                Response.Write("Not enrolled in course");
            else
                Response.Write("Assignment submitted successfully");
        }
    }
}