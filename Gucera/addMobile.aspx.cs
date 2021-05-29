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
    public partial class addMobile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addMobileNumber(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("This Feature Is Only Available After Login!");
                return;
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            String number = mobileNumber.Text;
            try
            {
                UInt64 test = UInt64.Parse(number);
            }
            catch(Exception)
            {
                Response.Write("Invalid Mobile Number!");
                return;
            }

            int id = Int16.Parse(Session["user"].ToString());



            SqlCommand addMobile = new SqlCommand("addMobile", conn);
            addMobile.CommandType = CommandType.StoredProcedure;
            addMobile.Parameters.Add(new SqlParameter("@ID", id));
            addMobile.Parameters.Add(new SqlParameter("@mobile_number", number));

            conn.Open();
            try
            {
                addMobile.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                    Response.Write("This Number already exists!");
                else
                    Response.Write("Failed! Please enter a valid mobile number!");
                return;
            }
            conn.Close();

            Response.Write("Sucessfully Added!");

        }

    }
}