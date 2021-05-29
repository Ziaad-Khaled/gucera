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
    public partial class viewAssign : System.Web.UI.Page
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
            int courseId;
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            if (TextBox1.Text == "" )
            {
                Response.Write("There is an empty field!");
                return;
            }
            try
            {
                courseId = Int16.Parse(TextBox1.Text);
            }
            catch (System.Exception)
            {
                Response.Write("Please Enter a valid courseId!");
                return;
            }
            int sid = Int16.Parse(Session["user"].ToString());
            SqlCommand viewAssignment = new SqlCommand("viewAssign", conn);
            viewAssignment.CommandType = CommandType.StoredProcedure;
            viewAssignment.Parameters.Add(new SqlParameter("@sid", sid));
            viewAssignment.Parameters.Add(new SqlParameter("@courseid", courseId));

            conn.Open();
            bool flag = false;
            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = viewAssignment.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                //Get the value of the attribute field in the Company table
                int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                int number = rdr.GetInt32(rdr.GetOrdinal("number"));
                string type = rdr.GetString(rdr.GetOrdinal("type"));
                int fullgrade = rdr.GetInt32(rdr.GetOrdinal("fullgrade"));
                decimal weight = rdr.GetDecimal(rdr.GetOrdinal("weight"));
                DateTime deadline = rdr.GetDateTime(rdr.GetOrdinal("deadline"));
                string content = rdr.GetString(rdr.GetOrdinal("content"));
                //Create a new label and add it to the HTML form
                Label lbl_sid = new Label();
                lbl_sid.Text = "Course Id: " + cid + "|";
                form1.Controls.Add(lbl_sid);


                Label lbl_number = new Label();
                lbl_number.Text = "Number: " + number + "|";
                form1.Controls.Add(lbl_number);

                Label lbl_type= new Label();
                lbl_type.Text = "type: " + type + "|";
                form1.Controls.Add(lbl_type);

                Label lbl_fullgrade = new Label();
                lbl_fullgrade.Text = "fullgrade: " + fullgrade + "|";
                form1.Controls.Add(lbl_fullgrade);

                Label lbl_weight = new Label();
                lbl_weight.Text = "weight: " + weight + "|";
                form1.Controls.Add(lbl_weight);

                Label lbl_deadline = new Label();
                lbl_deadline.Text = "issueDate: " + deadline + "|" ;
                form1.Controls.Add(lbl_deadline);

                Label lbl_content = new Label();
                lbl_content.Text = "content: " + content + "  <br /> <br />";
                form1.Controls.Add(lbl_content);

                flag = true;
            }
            //this is how you retrive data from session variable.
            string field1 = (string)(Session["field1"]);
            if (flag)
            {
                Response.Write(field1);
                TextBox1.Visible = false;
                Label1.Visible = false;
                Button1.Visible = false;
            }
            else
                Response.Write("The student doesn't take the course");



            //certificate.ExecuteNonQuery();
            conn.Close();
        }
    }
}