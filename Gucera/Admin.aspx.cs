using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gucera
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("Warning! You are not logged in!");
                return;
            }
            Response.Write("Your id is: " + Session["user"]);

        }

        protected void viewAllCourses(object sender, EventArgs e)
        {
            Response.Redirect("viewAllCourses.aspx");
        }

        protected void viewPending(object sender, EventArgs e)
        {
            Response.Redirect("viewPending.aspx");
        }

        protected void acceptPending(object sender, EventArgs e)
        {
            Response.Redirect("acceptPending.aspx");
        }

        protected void createPromo(object sender, EventArgs e)
        {
            Response.Redirect("createPromo.aspx");
        }

        protected void issuePromo(object sender, EventArgs e)
        {
            Response.Redirect("issuePromo.aspx");
        }

        protected void addMobile(object sender, EventArgs e)
        {
            Response.Redirect("addMobile.aspx");
        }
    }
}