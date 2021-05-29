using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gucera
{
    public partial class Student : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("Please Log in!");
                return;
            }
            Response.Write("Your id is: " + Session["user"]);
        }

        protected void viewMyAssignments(object sender, EventArgs e)
        {
            Response.Redirect("viewAssign.aspx");
        }


        protected void listCertificates(object sender, EventArgs e)
        {
            Response.Redirect("viewCertificate.aspx");
        }

        protected void submitMyAssignment(object sender, EventArgs e)
        {
            Response.Redirect("submitAssign.aspx");
        }

        protected void viewMyAssignmentGrades(object sender, EventArgs e)
        {
            Response.Redirect("viewAssignGrades.aspx");
        }

        protected void addFeedback(object sender, EventArgs e)
        {
            Response.Redirect("addFeedback.aspx");
        }
        protected void viewMyProfile(object sender, EventArgs e)
        {
            Response.Redirect("viewMyProfile.aspx");
        }
        protected void listAcceptedCourses(object sender, EventArgs e)
        {
            Response.Redirect("listAcceptedCourses.aspx");
        }
        protected void enrollInCourse(object sender, EventArgs e)
        {
            Response.Redirect("enrollInCourse.aspx");
        }
        protected void addCreditCard(object sender, EventArgs e)
        {
            Response.Redirect("addCreditCard.aspx");
        }
        protected void viewPromocode(object sender, EventArgs e)
        {
            Response.Redirect("viewPromocode.aspx");
        }

        protected void addMobile(object sender, EventArgs e)
        {
            Response.Redirect("addMobile.aspx");
        }
    }
}