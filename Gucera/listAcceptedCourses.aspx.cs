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
    public partial class listAcceptedCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("Please Log in!");
                return;
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand courses = new SqlCommand("availableCourses", conn);
            courses.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataReader rdr = courses.ExecuteReader(CommandBehavior.CloseConnection);
            int i = 0;//number of courses
            while (rdr.Read())
            {
                i++;
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                Label lbl_name = new Label();
                lbl_name.Text = "Course" + i + ": " + name + "<br>";
               
                form1.Controls.Add(lbl_name);
            }
            if (i == 0)//if the number of courses=0
                Label1.Text = "There are no accepted courses at the moment.";
        }
    }
}