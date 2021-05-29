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
    public partial class issuePromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void issueToStudent(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("This Feature Is Only Available After Login!");
                return;
            }
            bool success = false;
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand issuepromocode = new SqlCommand("AdminIssuePromocodeToStudent", conn);
            issuepromocode.CommandType = CommandType.StoredProcedure;
            try
            {
                String code = cd.Text;
                int StudentID = Int16.Parse(sid.Text);
                issuepromocode.Parameters.Add(new SqlParameter("@pid", code));
                issuepromocode.Parameters.Add(new SqlParameter("@sid", StudentID));
                conn.Open();
                try
                {
                    int rowsUpdated = issuepromocode.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        success = true;
                    }
                    if (success)
                        Response.Write("Promocode Issued successfully!");
                    else
                        Response.Write("Cannot Issue This Promocode To This ID!");
                }
                catch (SqlException ex)
                {

                    if (ex.Number == 2627)
                        Response.Write("This Student Already Has This Promocode");
                    else { 
                        if(ex.Number == 547)
                        Response.Write("Cannot Issue Promocode! Kindly check that the promocode exists and that this ID belongs to a student");
                        else
                        Response.Write("Cannot Issue Promocode To Student");
                    }


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
