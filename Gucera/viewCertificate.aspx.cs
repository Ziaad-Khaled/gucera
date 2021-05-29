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
    public partial class viewCertificate : System.Web.UI.Page
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
            int courseId;
            if (TextBox1.Text == "")
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
            SqlCommand certificate = new SqlCommand("viewCertificate", conn);
            certificate.CommandType = CommandType.StoredProcedure;
            int ssid = Int16.Parse(Session["user"].ToString());

            certificate.Parameters.Add(new SqlParameter("@sid", ssid));
            certificate.Parameters.Add(new SqlParameter("@cid", courseId));

            conn.Open();
            bool flag = false;
            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = certificate.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                //Get the value of the attribute name in the Company table
                int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                //Get the value of the attribute field in the Company table
                int sid = rdr.GetInt32(rdr.GetOrdinal("sid"));

                DateTime issueDate = rdr.GetDateTime(rdr.GetOrdinal("issueDate"));
                //Create a new label and add it to the HTML form
                Label lbl_sid = new Label();
                lbl_sid.Text = "Student Id: " + sid  + "|";
                form1.Controls.Add(lbl_sid);


                Label lbl_cid = new Label();
                lbl_cid.Text = "Course Id: " + cid + "|" ;
                form1.Controls.Add(lbl_cid);

                Label lbl_issueDate = new Label();
                lbl_issueDate.Text = "issueDate: " + issueDate + "  <br /> <br />";
                form1.Controls.Add(lbl_issueDate);

                flag = true;
            }
            //this is how you retrive data from session variable.
            string field1 = (string)(Session["field1"]);
            if (flag)
            {
                Response.Write(field1);
                TextBox1.Visible = false;
                Button1.Visible = false;
                Label1.Visible = false;
            }
            else
                Response.Write("student not enrolled in course or did not finish course");


            //certificate.ExecuteNonQuery();
            conn.Close();
        }
    }
}