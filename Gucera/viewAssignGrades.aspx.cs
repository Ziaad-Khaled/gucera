using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Gucera
{
    public partial class viewAssignGrades : System.Web.UI.Page
    {
        // get error -1-
        private static string error;
        //
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
            if (courseId.Text == "" || AssignmentType.Text == "" || AssignmentNumber.Text == "")
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
            
            SqlCommand viewAssign = new SqlCommand("viewAssignGrades", conn);
            viewAssign.CommandType = CommandType.StoredProcedure;

            int sid = Int16.Parse(Session["user"].ToString());

            viewAssign.Parameters.Add(new SqlParameter("@sid", sid));
            viewAssign.Parameters.Add(new SqlParameter("@cid", cid));
            viewAssign.Parameters.Add(new SqlParameter("@assignType", type));
            viewAssign.Parameters.Add(new SqlParameter("@assignnumber", assignnumber));

            SqlParameter assignGrade = viewAssign.Parameters.Add("@assignGrade", SqlDbType.Int);

            assignGrade.Direction = ParameterDirection.Output;
            conn.Open();
            //get error -2-//
            conn.InfoMessage += conn_InfoMessage;
            var result = viewAssign.ExecuteNonQuery();
            //
            if(error != null)
            {
                Response.Write(error);
            }
            else
            {
                if ((assignGrade.Value).ToString().Equals("") )
                    Response.Write("Either the assignment is not graded yet or no such assignment with this info in this course.");
                else
                    Response.Write(assignGrade.Value);
            }

            //get error -3-//
            error = null;
            //
            conn.Close();
        }
        
        //get error -4-
        static void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // this gets the print statements (maybe the error statements?)
            var outputFromStoredProcedure = e.Message;
            error = outputFromStoredProcedure.ToString();
           // return e.Message;
        }
        //
    }
}