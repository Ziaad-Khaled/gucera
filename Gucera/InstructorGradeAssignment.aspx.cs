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
    public partial class InstructorGradeAssignment : System.Web.UI.Page
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

        protected void grade(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first to use your ID to grade assignment";
                return;
            }
            //opening cnnection
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            int sId=0;
            int cId=0;
            int number=0;
            try
            {


                SqlCommand gradeAssignment = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
                gradeAssignment.CommandType = CommandType.StoredProcedure;
                String Type = type.Text;

                //Begin handling every int value that it is not string
                try
                { //begin handling for every value that is not white spaces only
                    if (String.IsNullOrWhiteSpace(studentId.Text))
                    {
                        Response.Write("<h4> Please Enter valid value in Student ID (Do not enter spaces) !! </h4>");
                        return;
                    }
                    else
                    {
                        sId = Int32.Parse(studentId.Text);
                        gradeAssignment.Parameters.Add(new SqlParameter("@sid", sId));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Student ID ,  Please Enter Valid Value for Student ID (Must be Integer value not string) </h4>"); }


                try
                {
                    if (String.IsNullOrWhiteSpace(coursId.Text))
                    {
                        Response.Write("<h4> Please Enter valid value in Course ID (Do not enter spaces) !! </h4>");
                        return;
                    }
                    else
                    {
                        cId = Int32.Parse(coursId.Text);
                        gradeAssignment.Parameters.Add(new SqlParameter("@cid", cId));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Course ID ,  Please Enter Valid Value for Course ID (Must be Integer value not string) </h4>"); }
                try
                {
                    if (String.IsNullOrWhiteSpace(num.Text))
                    {
                        Response.Write("<h4> Please Enter valid value in Assignment number (Do not enter spaces) !! </h4>");
                        return;
                    }
                    else
                    {
                        number = Int32.Parse(num.Text);
                        gradeAssignment.Parameters.Add(new SqlParameter("@assignmentNumber", number));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Assignment Number ,  Please Enter Valid Value for Assignment Number (Must be Integer value not string) </h4>"); }


                try
                {
                    if (String.IsNullOrWhiteSpace(Grade.Text))
                    {
                        Response.Write("<h4> Please Enter valid value in Assignment Grade (Do not enter spaces) !! </h4>");
                        return;
                    }
                    else
                    {
                        int grade = Int32.Parse(Grade.Text);
                        gradeAssignment.Parameters.Add(new SqlParameter("@grade", grade));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in  Grade ,  Please Enter Valid Value for  Grade (Must be Integer value not string) </h4>"); }

                //Getting instructor Id that instructor already logged in with ,and putting it in procedure inputs
                gradeAssignment.Parameters.Add(new SqlParameter("@instrId", Session["user"]));

                if (String.IsNullOrWhiteSpace(type.Text))
                {
                    Response.Write("<h4> Please Enter valid value in Assignment Type (Do not enter spaces) !! </h4>");
                    return;
                }
                else {
                    gradeAssignment.Parameters.Add(new SqlParameter("@type", Type));

                }


                conn.Open();
                gradeAssignment.ExecuteNonQuery();

                //check if student takes this assignment and this course belongs to that instructor
                SqlCommand AssignmentExist = new SqlCommand("select count(*) from StudentTakeAssignment S inner join Course C on C.id = S.cid where cid=" + cId + " and assignmentNumber=" + number + " and sid =" + sId + " and instructorId =" + Session["user"] + " and assignmenttype ='" + Type+"'", conn);
                Int32 count = (Int32)AssignmentExist.ExecuteScalar();
                if (count == 1)
                {//assignmtn is graded
                    Response.Write("<h1>Assignment Graded Successfully !! </h1>");
                    return;
                }
                else if (count == 0)
                {
                 //assignment doesnot belong to the course or student did not take the assignment or assignment type is incorrect  
                    Response.Write("<h1>Sorry this assignment cannot be graded  </h1>");
                    Response.Write("<h2>Please check if you Added that course and student take that assignment and the assignment type is correct(quiz , project or exam)   </h2>");
                    return;

                }

            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {  //violations of check constraint in sql ,if grade value is not between 0 and 100
                    Response.Write("<h1>Please Enter valid grade value , </h1>");
                    Response.Write("<h2>Grade can only be between (0 and 100) </h2>");

                    return;
                }
                else 
                {
                    Response.Write("<h1>Invalid input </h1>");
                    Response.Write("<h2>please enter valid values </h2>");

                    return;

                }
            }
            catch (System.Exception)
            {
                Response.Write("<h1>Invalid Input !! </h1>");
                Response.Write("<h2>Please Enter Valid Values !!</h2>");

                return;
            }
             conn.Close();

        }
    }
}