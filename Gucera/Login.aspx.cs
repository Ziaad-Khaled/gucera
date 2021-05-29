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

    public partial class Login : System.Web.UI.Page
    {
        public static int  id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void login(object sender, EventArgs e)
        {
             string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
              SqlConnection conn = new SqlConnection(connstr);
            try
            {
                id = Int16.Parse(username.Text);
            }
            catch(Exception)
            {
                Response.Write("This is not a valid form of an ID! Please enter a valid one!");
                return;
            }

            string pass = password.Text;
             SqlCommand loginproc = new SqlCommand("userLogin",conn);
              loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@id",id));
             loginproc.Parameters.Add(new SqlParameter("@password", pass));

             SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.Int);


            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;
            conn.Open();
            try
            {
                loginproc.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Invalid Input! Please try again!");
                return;
            }
             conn.Close();
             if (success.Value.ToString() == "1") 
             {
                Session["user"] = id;
                if (type.Value.ToString() == "2")
                {
                    Response.Redirect("Student.aspx");
                }
                if (type.Value.ToString() == "0")
                {
                    Response.Redirect("InstructorPage.aspx");
                }
                if (type.Value.ToString() == "1")
                {
                    Response.Redirect("Admin.aspx");
                }

            }
            else
            {
                Response.Write("Failed");
            }
         }

        protected void InstructorRegistration(object sender, EventArgs e)
        {

        }
    }
        
    }

