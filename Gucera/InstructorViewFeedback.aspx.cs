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
    public partial class InstructorViewFeedback : System.Web.UI.Page
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

        protected void viewFeedback(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first to use your ID to View feedbacks";
                return;
            }
            //opening connection 

            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);


            try {
                int courseID = Int32.Parse(coId.Text);

                SqlCommand viewFeed = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
                viewFeed.CommandType = CommandType.StoredProcedure;

                //Getting instructor Id that instructor already logged in with and putting it in procedure inputs
                viewFeed.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
                viewFeed.Parameters.Add(new SqlParameter("@cid", courseID));

                conn.Open();
                SqlDataReader rdr = viewFeed.ExecuteReader(CommandBehavior.CloseConnection);
                int i = 0;//number of feedbacks
                   
                    while (rdr.Read())
                {//if there exists feedbacks loop and show them all
                    i++;                   
                            int feednum = rdr.GetInt32(rdr.GetOrdinal("number"));
                            Label number = new Label();
                            number.Text = "Feedback number = " + feednum.ToString() + "---";
                            form1.Controls.Add(number);
                     
                    //comment might have null value so we have to check for it  
                    if (!rdr.IsDBNull(rdr.GetOrdinal("comment")))
                    {
                        string feedcomment = rdr.GetString(rdr.GetOrdinal("comment"));
                        Label comment = new Label();
                        comment.Text = "comment  is   " + feedcomment + "---";
                        form1.Controls.Add(comment);

                    }
                    else {
                        Label comment = new Label();
                        comment.Text = "comment  is   "+ " N/A " + "---";
                        form1.Controls.Add(comment);
                    }

                    
                           int numOfLikes = rdr.GetInt32(rdr.GetOrdinal("numberOfLikes"));
                           Label likes = new Label();
                            likes.Text = "Number of likes =" + numOfLikes + "</br>";
                            form1.Controls.Add(likes);

                        
                    }
                
                if(i==0)
                {
                    Response.Write("<h1>No Feedbackes Available for This course  </h1>");
                    return;
                }
            } catch (System.Exception) {
                //if course id value is string or wrong value
                Response.Write("<h1>Invalid Input  </h1>");
                Response.Write("<h1>Please Enter Valid Input In course ID  </h1>");
                
            }
            conn.Close();

        }
    }
}