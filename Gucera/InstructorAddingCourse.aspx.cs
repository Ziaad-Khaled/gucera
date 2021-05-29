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
    public partial class InstructorAddingCourse : System.Web.UI.Page
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
        protected void addCourse(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Label1.Text = " Please log in first to use your ID to add course";
                return;
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            try {
                String Name = name.Text;

                SqlCommand insAdd = new SqlCommand("InstAddCourse", conn);
                insAdd.CommandType = CommandType.StoredProcedure;
                //begin handling for every value that is not white spaces only
                if (String.IsNullOrWhiteSpace(name.Text))
                {
                    Response.Write("please add name in course");
                    return;
                }
                else
                {
                    insAdd.Parameters.Add(new SqlParameter("@name", Name));
                }
                //Getting instructor Id that instructor already logged in with ,and putting it in procedure inputs
                insAdd.Parameters.Add(new SqlParameter("@instructorId", Session["user"]));

                //Begin handling every int and decimal value that it is not string 
                try
                {   
                    //checking if user entered no value in non required sections so we enter them as null values
                    if (String.IsNullOrWhiteSpace(price.Text))
                    {
                        insAdd.Parameters.Add(new SqlParameter("@price", DBNull.Value));

                    }
                    else { 
                    float Price = float.Parse(price.Text);
                    insAdd.Parameters.Add(new SqlParameter("@price", Price));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Course Price,  Please Enter Valid Value for Price (Must be Integer value not string) </h4>"); }
                try
                {
                    if (String.IsNullOrWhiteSpace(credit_hours.Text))
                    {
                        insAdd.Parameters.Add(new SqlParameter("@creditHours", DBNull.Value));

                    }
                    else {
                        int credit = Int32.Parse(credit_hours.Text);
                        insAdd.Parameters.Add(new SqlParameter("@creditHours", credit));
                    }
                }
                catch (System.FormatException)
                { Response.Write("<h4>Invalid Input in Credit Hours,  Please Enter Valid Value for Credit Hours (Must be Integer value not string) </h4>"); }

                try
                {
                    conn.Open();
                    insAdd.ExecuteNonQuery();
                    
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {//violation of primary keys by inputing values of course that already exists
                        Response.Write("<h1>This Course already exists !! </h1>");
                        Response.Write("<h2>Please add another course !! </h2>");

                    }
                    else if (ex.Number == 8114) {
                        //violation of price value it shoud have maximum four digits and 2 after decimal point 
                        Response.Write("<h1>Can not add this course !! </h1>");
                        Response.Write("<h2>Please Enter Valid Price !! </h2>");

                    }
                    else
                    {
                       
                        Response.Write("<h1>Can not add this course !! </h1>");
                        Response.Write("<h2>Please Enter Valid values !! </h2>");

                    }
                    return;
                }
            }
            catch (System.Exception)
            {
                Response.Write("<h1>Invalid Input !! </h1>");
                Response.Write("<h2>Please Ener valid values (check price and credit hours) !! </h2>");

                return;
            }
            conn.Close();
            Response.Write("<h1>Course Added Successfully !! !! </h1>");
   
           
        }
    }
}