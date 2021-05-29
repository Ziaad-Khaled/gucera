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

    public partial class createPromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createPromocode(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("This Feature Is Only Available After Login!");
                return;
            }
            bool success = false;
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand createpromocode = new SqlCommand("AdminCreatePromocode", conn);
            createpromocode.CommandType = CommandType.StoredProcedure;
            try
            {
                String code = cd.Text;
                double discount = Double.Parse(disc.Text);
                int adminID = Int16.Parse(Session["user"].ToString());
                var issueDate = Request["isDat"];
                var expireyDate = Request["expDat"];

                createpromocode.Parameters.Add(new SqlParameter("@code", code));
                createpromocode.Parameters.Add(new SqlParameter("@isuueDate", issueDate));
                createpromocode.Parameters.Add(new SqlParameter("@expiryDate", expireyDate));
                createpromocode.Parameters.Add(new SqlParameter("@discount", discount));
                createpromocode.Parameters.Add(new SqlParameter("@adminId", adminID));
                conn.Open();
                try
                {
                    int rowsUpdated = createpromocode.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        success = true;
                    }
                    if (success)
                        Response.Write("Promocode created successfully!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        Response.Write("Promocode Already Exists!");
                    else
                        Response.Write("Cannot Issue Promocode!");
                }
                conn.Close();

            }
            catch (Exception)
            {
                Response.Write("The values you have entered are invalid!");
            }






        }
    }
}
