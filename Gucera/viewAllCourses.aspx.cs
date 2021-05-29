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
    public partial class viewAllCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isEmpty = true;
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand listCourses = new SqlCommand("AdminViewAllCourses", conn);
            listCourses.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = listCourses.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())//getting every course and showing its information
            {

                if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
                {
                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    Label lbl_name = new Label();
                    lbl_name.Text = "<br/>" + "Course Name: " + name + " || ";
                    form1.Controls.Add(lbl_name);

                }
                else
                {
                    Label lbl_name = new Label();
                    lbl_name.Text = "<br/>" + "Course Name: " + "N/A" + " || ";
                    form1.Controls.Add(lbl_name);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("creditHours")))
                {
                    int creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    Label lbl_credit_hours = new Label();
                    lbl_credit_hours.Text = "Course Credit Hours: " + creditHours + " || ";
                    form1.Controls.Add(lbl_credit_hours);
                }
                else
                {
                    Label lbl_credit_hours = new Label();
                    lbl_credit_hours.Text = "Course Credit Hours: " + "N/A" + " || ";
                    form1.Controls.Add(lbl_credit_hours);
                }


                if (!rdr.IsDBNull(rdr.GetOrdinal("price")))
                {
                    decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    Label lbl_price = new Label();
                    lbl_price.Text = "Course Price: " + price + " || ";
                    form1.Controls.Add(lbl_price);
                }
                else
                {
                    Label lbl_price = new Label();
                    lbl_price.Text = "Course Price: " + "N/A" + " || ";
                    form1.Controls.Add(lbl_price);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("content")))
                {
                    String content = rdr.GetString(rdr.GetOrdinal("content"));
                    Label lbl_content = new Label();
                    lbl_content.Text = "Course Content: " + content + " || ";
                    form1.Controls.Add(lbl_content);
                }
                else
                {
                    Label lbl_content = new Label();
                    lbl_content.Text = "Course Content: " + "N/A" + " || ";
                    form1.Controls.Add(lbl_content);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")))
                {
                    Boolean accepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                    Label lbl_accepted = new Label();

                    if (!accepted)
                        lbl_accepted.Text = "Course: " + "Not Accpeted" + "<br />";
                    else
                        lbl_accepted.Text = "Course: " + "Accepted" + "<br />";
                    form1.Controls.Add(lbl_accepted);
                }
                else
                {
                    Label lbl_accepted = new Label();
                    lbl_accepted.Text = "Course: " + "Not Accpeted" + "<br />";
                    form1.Controls.Add(lbl_accepted);
                }
                isEmpty = false;
            }
            if (isEmpty)
            {
                Header.Text = "There Are No Courses In The System";
            }


        }
    }
}