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
    public partial class InstructorViewAssigment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first ";
            }
            else
            {
                Label1.Text = "Your Id Is   " + Session["user"];
            }
        }

        protected void viewAssignment(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first to use your ID to view assignment";
                return;
            }
            //opening connection
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);

            try
            {
                int coursId = Int32.Parse(coId.Text);

                SqlCommand viewAssig = new SqlCommand("InstructorViewAssignmentsStudents", conn);
                viewAssig.CommandType = CommandType.StoredProcedure;

                //Getting instructor Id that instructor already logged in with and putting it in procedure inputs
                viewAssig.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
                viewAssig.Parameters.Add(new SqlParameter("@cid", coursId));

                conn.Open();
                   SqlDataReader rdr = viewAssig.ExecuteReader(CommandBehavior.CloseConnection);


                    int i = 0; //number of assignments
                    while (rdr.Read())
                {    //if there exists Assignments loop on them to show them all

                    i++;
                      
                            int assignum = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                           Label number = new Label();
                            number.Text = "assignment number = " + assignum.ToString() + "----";
                            form1.Controls.Add(number);

                        
                       
                            string assigType = rdr.GetString(rdr.GetOrdinal("assignmentType"));
                            Label type = new Label();
                            type.Text = "assignment Type = " + assigType + "</br>";
                            form1.Controls.Add(type);

                        
                    }
                
                if(i==0)
                {
                    Response.Write("<h1>Sorry No assignments Available  </h1>");
                    return;
                }


            }
            catch (System.Exception) {
                  // if Course ID is string or wrong value 
                Response.Write("<h1>Invalid Input  </h1>");
                Response.Write("<h1>Please Enter Valid Input In course ID  </h1>");


            }
            conn.Close();

        }
    }
}