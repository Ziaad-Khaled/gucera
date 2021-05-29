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
    public partial class InstructorIssueCertificate : System.Web.UI.Page
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

        protected void addCertificate(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first to use your ID to issue certificate";
                return;
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);

            

                try
                {
                    SqlCommand issuecertific = new SqlCommand("InstructorIssueCertificateToStudent", conn);
                    issuecertific.CommandType = CommandType.StoredProcedure;
                  
                    
                    //Getting instructorId that instrructor already logged in with ,and putting it in procedure inputs
                    issuecertific.Parameters.Add(new SqlParameter("@insId", Session["user"]));
                int sId = 0;
                    int cId = 0;
                    //Begin handling every int value that it is not string
                    try
                    {
                         sId = Int32.Parse(sid.Text);
                        issuecertific.Parameters.Add(new SqlParameter("@sid", sId));

                    }
                    catch (System.FormatException)
                    { Response.Write("<h4>Invalid Input in Student Id,  Please Enter Valid Value for Student ID (Must be Integer value not string) </h4>"); }
                    try
                    {
                         cId = Int32.Parse(coId.Text);
                        issuecertific.Parameters.Add(new SqlParameter("@cid", cId));

                    }
                    catch (System.FormatException)
                    { Response.Write("<h4>Invalid Input in Course ID,  Please Enter Valid Value for Course ID (Must be Integer value not string) </h4>"); }

                if (String.IsNullOrWhiteSpace(issue.Text))
                {
                    issuecertific.Parameters.Add(new SqlParameter("@issueDate", DBNull.Value));
                }
                else
                {
                    string issuedate = issue.Text;
                    issuecertific.Parameters.Add(new SqlParameter("@issueDate", issuedate));
                }

                    conn.Open();
                    
                    //Here we get the number of certificates before and after adding so that if they increased we know the certificate is added successfully
                    SqlCommand cmd = new SqlCommand("select count(*) from StudentCertifyCourse", conn);

                    //count1 represents number of certificates before adding 
                    Int32 count1 = (Int32)cmd.ExecuteScalar();

                    //try to add the certificate
                    issuecertific.ExecuteNonQuery();

                    //getting the number of certificates after adding
                    Int32 count2 = (Int32)cmd.ExecuteScalar();
                    
                    if (count2 > count1)
                    {
                        Response.Write("<h1>Certificate Issued Successfully !! </h1>");
                        return;

                    }
                    else {
                        Response.Write("<h1>Cannot Issue That Certicate For that course to that student !! </h1>");

                    //check if the student take that course and knowing his grade 
                        SqlCommand checkgarde = new SqlCommand("select grade from StudentTakeCourse where sid="+sId+" and cid="+cId,conn);
                    
                        object grad = checkgarde.ExecuteScalar();
                    //student has no grade in that course(null value in the table)
                        if (grad is DBNull)
                        {
                            Response.Write("<h1>There is no grades for this student in that course </h1>");
                            return;
                        }
                        else if (grad != null)
                        { 
                            double grade = Convert.ToDouble(grad);
                            if (grade <= 2.0)
                            {
                                Response.Write("<h3>This student grade is less than 2 in that course,To issue certificate his grade must be greater than 2  !! </h3>");
                                return;

                            }
                        }
                        //there is no values for studentTakeCourse table for this student means he does not take that course
                        else
                        {
                            Response.Write("<h1>Please check if the student exists and that he takes that course !! </h1>");
                            return;
                        }
                    
                  
                }

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {//exception number of violation of primary keys that certificate alrady exists
                        Response.Write("<h1>This Student Has Alrady Been Certified For This Course !! </h1>");
                        Response.Write("<h2>Please Enter Another Values for Student Id or Course Id !! </h2>");
                        return;
                    }
                    else if (ex.Number == 8114)
                    { //violation of check constraint od datetime 
                        Response.Write("<h1>Can Not Issue Certificate !! </h1>");
                        Response.Write("<h1>Please check The value for Date !! </h1>");

                        return;
                    }
                    else {
                        Response.Write("<h1>Cannot Issue That Certificate !! </h1>");
                         Response.Write("<h2>Please check input values !! </h2>");

                    return;
                    }
                }
                catch (System.Exception){
                Response.Write("<h1>Invalid Input !! </h1>");
                Response.Write("<h2>Please Enter Valid Values -- Hint: Enter Correct Values For Student ID and Course ID!! </h2>");
                return;
                }

            conn.Close();

        }
    }
}