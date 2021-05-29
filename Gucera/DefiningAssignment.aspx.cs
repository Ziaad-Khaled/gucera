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
    public partial class DefiningAssignment : System.Web.UI.Page
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

        protected void DefineAssignment(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first to use your ID to define assignment";
                return;
            }


            //opening the connection and geting the procedure from database
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand defAssig = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            defAssig.CommandType = CommandType.StoredProcedure;

     //Getting instructor Id that instructor already logged in with ,and putting it in procedure inputs
            defAssig.Parameters.Add(new SqlParameter("@instId", Session["user"]));
            conn.Open();
            
            
        
            try
            {    //here we check for every int value that it is not string
                try
                {
                    
                    if (String.IsNullOrWhiteSpace(couId.Text))
                    {
                        Response.Write("<h4> Please Enter valid value in course ID (Do not enter spaces) !! </h4>");
                        return;
                    }
                    else
                    {
                        int cId = Int32.Parse(couId.Text);
                        defAssig.Parameters.Add(new SqlParameter("@cid", cId));


                        //Here we check if this course is accepted by admin or not berfore defining assignment
                        try
                        {
                            SqlCommand acceptedByAdmin = new SqlCommand("select accepted from Course where id=" + cId, conn);
                            // val is the first column in first row in table outputed from acceptedByAdmin sqlcommand whic coresponds to course accepted or not
                            object val = acceptedByAdmin.ExecuteScalar();
                            if (val != null)
                            {
                                bool value = Convert.ToBoolean(val);
                                if (!value)
                                {  // if not accpeted
                                    Response.Write("<h4>course is not accepted yet </h4>");
                                    return;
                                }
                            }
                            else
                            {// this if val is null that means no entries in table or course might not exist at all
                                Response.Write("<h4>Please add valid value for course Id (This course might not exist) </h4>");
                                return;
                            }

                        }
                        catch (SqlException)
                        {
                            Response.Write("<h4>This course Does not exist </h4>");
                            return;
                        }
                        catch (System.Exception)
                        {
                            Response.Write("<h4>Course is not accepted Yet </h4>");
                            return;
                        }

                    }

                }
                catch (System.FormatException)
                { 
                    Response.Write("<h4>Invalid Input in Course Id,  Please Enter Valid Value for Course ID (Must be Integer value not string) </h4>"); }
                 
                try
                {
                    if (String.IsNullOrWhiteSpace(number.Text))
                    {
                        Response.Write("<h4> Please Enter valid value in Assignment number (Do not enter spaces) !! </h4>");
                        return;
                    }
                    else
                    {
                        int num = Int32.Parse(number.Text);
                        defAssig.Parameters.Add(new SqlParameter("@number", num));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Assignment Number ,  Please Enter Valid Value for Assignment Number (Must be Integer value not string) </h4>"); }


                try
                {
                     //checking if user entered no value in non required sections so we enter them as null values

                    if (String.IsNullOrWhiteSpace(fullGrade.Text))
                    {
                        defAssig.Parameters.Add(new SqlParameter("@fullGrade", DBNull.Value));

                    }
                    else
                    {
                        int fullGR = Int32.Parse(fullGrade.Text);
                        defAssig.Parameters.Add(new SqlParameter("@fullGrade", fullGR));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in full Grade ,  Please Enter Valid Value for Full Grade (Must be Integer value not string) </h4>"); }
                try
                {
                    if (String.IsNullOrWhiteSpace(weight.Text))
                    {
                        defAssig.Parameters.Add(new SqlParameter("@weight", DBNull.Value));
                    }
                    else
                    {
                        int weigh = Int32.Parse(weight.Text);
                        defAssig.Parameters.Add(new SqlParameter("@weight", weigh));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Weight,  Please Enter Valid Value for Assignment Weight (Must be Integer value not string) </h4>"); }

                String Type = type.Text;
                defAssig.Parameters.Add(new SqlParameter("@type", Type));

                //checking if user entered no value in non required sections so we enter them as null values
                if (String.IsNullOrWhiteSpace(dead.Text))
                {
                    defAssig.Parameters.Add(new SqlParameter("@deadline", DBNull.Value));

                }
                else {
                    string deadline = dead.Text;
                    defAssig.Parameters.Add(new SqlParameter("@deadline", deadline));

                }
                if (String.IsNullOrWhiteSpace(cont.Text))
                {
                    defAssig.Parameters.Add(new SqlParameter("@content", DBNull.Value));

                }
                else
                {
                    string content = cont.Text;
                    defAssig.Parameters.Add(new SqlParameter("@content", content));

                }
                
               
                try
                {
                    defAssig.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    { //exception number of violations ofprimary key
                        Response.Write("<h1>This assignment already exists !! </h1> ");
                        Response.Write("<h2>Please add another Assignment !! </h2>");
                        return;
                    }
                    else if (ex.Number == 547)

                    {
                        //exception number of violations of check constraint in table 
                        Response.Write("<h1>Can not add This Assignment !! </h1>");

                        Response.Write("<h2>Please enter valid type and grade ,Type can only be (quiz , project or exam) and grade can only be between (0-100) !! </h2>");

                        return;
                    }
                    else if (ex.Number == 201)
                    {

                        Response.Write("<h1>Can not add This Assignment !! </h1>");
                        Response.Write("<h1> Please check your input values in course id and number (Do not enter spaces) !! </h1>");
                        return;
                    }
                    else if (ex.Number == 8114)
                    {
                        Response.Write("<h1>Can not add This Assignment !! </h1>");
                        Response.Write("<h2> Please add valid weight , It can only be between (0-100) !! </h2>");
                        return;

                    }
                    else {
                        Response.Write("<h1>Can not add This Assignment !! </h1>");
                        Response.Write("<h2> Please check your input values !! </h2>");
                        return;
                    }

                }
                
            }
            catch (System.Exception) {
                
                            Response.Write("<h1> Invalid Input !! </h1>");
                            Response.Write("<h1> Please Enter Valid Input !! </h1>");
                return;

            }

            conn.Close();
            
            Response.Write("<h1>Assignment Added Successfully !! </h1>");
           




        }
    }
}

