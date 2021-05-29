using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gucera
{
    public partial class InstructorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Your Id Is   " + Session["user"];

        }


        protected void addCoursess(object sender, EventArgs e)
        {
            Response.Redirect("InstructorAddingCourse.aspx");
        }

        protected void DEFINE(object sender, EventArgs e)
        {
            Response.Redirect("DefiningAssignment.aspx");
        }

        protected void VIEWA(object sender, EventArgs e)
        {
            Response.Redirect("InstructorViewAssigment.aspx");

        }

        protected void GRADE(object sender, EventArgs e)
        {
            Response.Redirect("InstructorGradeAssignment.aspx");

        }

        protected void VIEWF(object sender, EventArgs e)
        {
            Response.Redirect("InstructorViewFeedback.aspx");

        }

        protected void ISSUE(object sender, EventArgs e)
        {
            Response.Redirect("InstructorIssueCertificate.aspx");

        }

        protected void addM(object sender, EventArgs e)
        {
            Response.Redirect("addMobile.aspx");
        }
    }
}