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
    public partial class viewMyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand profile = new SqlCommand("viewMyProfile", conn);
            profile.CommandType = CommandType.StoredProcedure;
            if(Session["user"]==null)
            {
                Response.Write("You must be logged in! No info will be shown!");
                return;
            }
            int sid = Int16.Parse(Session["user"].ToString());//getting the student ID from the session
            profile.Parameters.Add(new SqlParameter("@id",sid));

            conn.Open();

            SqlDataReader rdr = profile.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())//checking the output of the procedure and displaying them on the labels
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("id")))
                {
                    int id = rdr.GetInt32(rdr.GetOrdinal("id"));
                    Label1.Text = "Student ID: " + id;
                }
                else
                {
                    Label1.Text = "Student ID: " + "N/A";
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("gpa")))//if any of the outputs is null, do not show them
                {
                    decimal gpa = rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                    Label2.Text = "Student GPA: " + gpa;
                }
                else
                {
                    Label2.Text = "Student GPA: " + "N/A";
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("firstName")))
                {
                    String first_name = rdr.GetString(rdr.GetOrdinal("firstName"));
                    Label3.Text = "Student First Name: " + first_name;
                  
                }
                else
                {
                    Label3.Text = "Student First Name: " + "N/A";
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("lastname")))
                {
                    String last_name = rdr.GetString(rdr.GetOrdinal("lastname"));
                    Label4.Text = "Student Last Name: " + last_name;
                }
                else
                {
                    Label4.Text = "Student Last Name: " + "N/A";
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("password")))
                {
                    String password = rdr.GetString(rdr.GetOrdinal("password"));
                    Label5.Text = "Student Password:" + password;
                }
                else
                {
                    Label5.Text = "Student Password:" + "N/A";
                }


                if (!rdr.IsDBNull(rdr.GetOrdinal("gender")))
                {
                    Byte[] gender =(Byte[])  rdr.GetSqlBinary(rdr.GetOrdinal("gender"));

                    if (gender[0]==0)
                        Label6.Text = "Student Gender: " + "Male";
                    else
                        Label6.Text = "Student Gender: " + "Female";
                }
                else
                {
                    Label6.Text = "Student Gender: " + "N/A";
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("email")))
                {
                    String email = rdr.GetString(rdr.GetOrdinal("email"));
                    Label7.Text = "Student Email: " + email ;
                }
                else
                {
                    Label7.Text = "Student Email: " + "N/A";
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("address")))
                {
                    String address = rdr.GetString(rdr.GetOrdinal("address"));
                    Label8.Text = "Student Address: " + address;
                }
                else
                {
                    Label8.Text = "Student Address: " + "N/A";
                }
            }
            conn.Close();

        }
    }
}