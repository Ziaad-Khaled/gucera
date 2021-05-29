using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gucera
{
    public partial class enrollInCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("Please Log in!");
                return;
            }
        }

        protected void courseInfo(object sender, EventArgs e)
        {
       
                try
                {
                    int courseId = Int16.Parse(courseIdBox.Text);
                    Session["course"] = courseId;   
                }
                catch(Exception)
                {
                    Response.Write("Please Enter a valid course ID!");
                    return;
                }

                Response.Redirect("courseInformation.aspx");
            }
           
        }
    }
