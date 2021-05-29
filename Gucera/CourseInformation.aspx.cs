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
    public partial class CourseInformation : System.Web.UI.Page
    {

        public static Boolean acc = false;//to know whether the course is accepted
        protected void Page_Load(object sender, EventArgs e)
        {

            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            if (Session["course"] == null)
            {
                Response.Write("You must enter a course ID to show its info!");
                return;
            }
            int courseId = Int16.Parse(Session["course"].ToString());
            SqlCommand courseInfo = new SqlCommand("courseInformation", conn);
            courseInfo.CommandType = CommandType.StoredProcedure;
            courseInfo.Parameters.Add(new SqlParameter("@id", courseId));

            conn.Open();
            Boolean f = false;//A flag to know whether there is such a course or not
            SqlDataReader rdr = courseInfo.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("id")))
                {
                    f = true;//True because we found info for the course(The course ID exists)
                    int id = rdr.GetInt32(rdr.GetOrdinal("id"));
                    Label lbl_id = new Label();
                    lbl_id.Text = "Course ID: " + id + "<br>";
                    form1.Controls.Add(lbl_id);

                }
                else
                {
                    Label lbl_id = new Label();
                    lbl_id.Text = "Course ID: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_id);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("creditHours")))
                {
                    int creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    Label lbl_credit_hours = new Label();
                    lbl_credit_hours.Text = "Course Credit Hours: " + creditHours + "<br>";
                    form1.Controls.Add(lbl_credit_hours);
                }
                else
                {
                    Label lbl_credit_hours = new Label();
                    lbl_credit_hours.Text = "Course Credit Hours: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_credit_hours);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
                {
                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    Label lbl_name = new Label();
                    lbl_name.Text = "Course Name: " + name + "<br>";
                    form1.Controls.Add(lbl_name);

                }
                else
                {
                    Label lbl_credit_hours = new Label();
                    lbl_credit_hours.Text = "Course Credit Hours: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_credit_hours);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("courseDescription")))
                {
                    String courseDescription = rdr.GetString(rdr.GetOrdinal("courseDescription"));
                    Label lbl_course_description = new Label();
                    lbl_course_description.Text = "Course Description: " + courseDescription + "<br>";
                    form1.Controls.Add(lbl_course_description);

                }
                else
                {
                    Label lbl_course_description = new Label();
                    lbl_course_description.Text = "Course Description: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_course_description);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("price")))
                {
                    decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    Label lbl_price = new Label();
                    lbl_price.Text = "Course Price: " + price + "<br>";
                    form1.Controls.Add(lbl_price);

                }
                else
                {
                    Label lbl_price = new Label();
                    lbl_price.Text = "Course Price: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_price);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("content")))
                {
                    String content = rdr.GetString(rdr.GetOrdinal("content"));
                    Label lbl_content = new Label();
                    lbl_content.Text = "Course Content: " + content + "<br>";
                    form1.Controls.Add(lbl_content);

                }
                else
                {
                    Label lbl_content = new Label();
                    lbl_content.Text = "Course Content: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_content);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("adminId")))
                {
                    int adminId = rdr.GetInt32(rdr.GetOrdinal("adminId"));
                    Label lbl_admin_id = new Label();
                    lbl_admin_id.Text = "Admin ID (who accepted the course): " + adminId + "<br>";
                    form1.Controls.Add(lbl_admin_id);
                }
                else
                {
                    Label lbl_admin_id = new Label();
                    lbl_admin_id.Text = "Admin ID (who accepted the course): " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_admin_id);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("instructorId")))
                {
                    int instructorId = rdr.GetInt32(rdr.GetOrdinal("instructorId"));
                    Label lbl_instructor_id = new Label();
                    lbl_instructor_id.Text = "Instructor ID: " + instructorId + "<br>";
                    form1.Controls.Add(lbl_instructor_id);

                }
                else
                {
                    Label lbl_instructor_id = new Label();
                    lbl_instructor_id.Text = "Instructor ID: " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_instructor_id);
                }


                if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")))
                {
                    Boolean accepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                    acc = accepted;
                    Label lbl_accepted = new Label();

                    if (!accepted)
                        lbl_accepted.Text = "Course: " + "Not Accpeted" + "<br>";
                    else
                        lbl_accepted.Text = "Course: " + "Accepted" + "<br>";
                    form1.Controls.Add(lbl_accepted);

                }
                else
                {
                    Label lbl_accepted = new Label();
                    lbl_accepted.Text = "Course: " + "Not Accepted" + "<br>";
                    form1.Controls.Add(lbl_accepted);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("firstName")))
                {
                    String first_name = rdr.GetString(rdr.GetOrdinal("firstName"));
                    Label lbl_first_name = new Label();
                    lbl_first_name.Text = "Instructor's First Name (who added the course): " + first_name + "<br>";
                    form1.Controls.Add(lbl_first_name);

                }
                else
                {
                    Label lbl_first_name = new Label();
                    lbl_first_name.Text = "Instructor's First Name (who added the course): " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_first_name);

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("lastname")))
                {
                    String last_name = rdr.GetString(rdr.GetOrdinal("lastname"));
                    Label lbl_last_name = new Label();
                    lbl_last_name.Text = "Instructor's Last Name (Who added the course): " + last_name + "<br>";
                    form1.Controls.Add(lbl_last_name);

                }
                else
                {
                    Label lbl_last_name = new Label();
                    lbl_last_name.Text = "Instructor's Last Name (Who added the course): " + "N/A" + "<br>";
                    form1.Controls.Add(lbl_last_name);

                }




            }
            if(!f)//if no info was found for such a course ID
            {
                enrollButton.Style.Add("display","none");
                Label1.Style.Add("display", "none");
                Label2.Style.Add("display", "none");
                instid.Style.Add("display", "none");
                Response.Write("There is no course with such an ID!");


            }

        }

        protected void enroll(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("You must be logged in to enroll in a course!");
                return;
            }

            if (!acc)//if the course is not accepted, return a message.
            {
                Response.Write("Failed! This course is not accepted yet by the admin!");
                return; 
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            int sid = Int16.Parse(Session["user"].ToString());
            int cid = Int16.Parse(Session["course"].ToString());
            int insid = 0;
            try
            {
                insid = Int32.Parse(instid.Text);
            }
            catch(Exception)
            {
                Response.Write("This is not a valid form of an instructor ID!");
                return;
            }
            //check that the id belongs to an instructor
            SqlCommand checkInst = new SqlCommand("SELECT COUNT(*) FROM Instructor where id=" + insid, conn);
            //check whether the instructor teaches this course
            SqlCommand checkInstTeachCourse = new SqlCommand("SELECT COUNT(*) FROM InstructorTeachCourse where insid=" + insid + "and cid="+cid, conn);
            conn.Open();
            int check= (Int32)checkInst.ExecuteScalar();
            int checkInstTeach = (Int32)checkInstTeachCourse.ExecuteScalar(); ;
            conn.Close();
            if(check==0)//if the number of instructor with such id=0
            {
                Response.Write("This id does not belong to an instructor!");
                return;
            }
            if(checkInstTeach==0)//if this instructor does not teach this course
            {
                Response.Write("This instructor does not teach this course!");
                return;
            }

            //initialize the size of the table before executing the query
            Int32 count1 = 0;
            //initialize the size of the table after executing the query
            Int32 count2 = 0;
            try
            {
                SqlCommand enrollCourse = new SqlCommand("enrollInCourse", conn);
                enrollCourse.CommandType = CommandType.StoredProcedure;
                enrollCourse.Parameters.Add(new SqlParameter("@sid", sid));
                enrollCourse.Parameters.Add(new SqlParameter("@cid", cid));
                enrollCourse.Parameters.Add(new SqlParameter("@instr", insid));



                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM StudentTakeCourse",conn);
                count1 = (Int32)cmd.ExecuteScalar();
                enrollCourse.ExecuteNonQuery();
                count2 = (Int32)cmd.ExecuteScalar();

                conn.Close();


            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627) //if the student is already enrolled
                    Response.Write("Failed! You already take this course with this instructor!");
                else
                    Response.Write("Failed! Cannot enroll in this course");


                return;
            }


            if (count1 == count2)//if the enrollment did not happen
            {
                Response.Write("You did not take all the course prerequisites");
                return;
            }
            Response.Write("Course added successfully");
        }
    }
}