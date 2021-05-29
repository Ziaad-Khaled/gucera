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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void login(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
           
            


            SqlCommand StudentReg = new SqlCommand("studentRegister", conn);
            StudentReg.CommandType = CommandType.StoredProcedure;
            if (String.IsNullOrWhiteSpace(first_name.Text))
                StudentReg.Parameters.Add(new SqlParameter("@first_name", DBNull.Value));
            else
                StudentReg.Parameters.Add(new SqlParameter("@first_name", first_name.Text));

            if (String.IsNullOrWhiteSpace(last_name.Text))
                StudentReg.Parameters.Add(new SqlParameter("@last_name", DBNull.Value));
            else
                StudentReg.Parameters.Add(new SqlParameter("@last_name", last_name.Text));

            if (String.IsNullOrWhiteSpace(email.Text))
                StudentReg.Parameters.Add(new SqlParameter("@email", DBNull.Value));
            else
                StudentReg.Parameters.Add(new SqlParameter("@email", email.Text));

            if (String.IsNullOrWhiteSpace(password.Text))
                StudentReg.Parameters.Add(new SqlParameter("@password", DBNull.Value));
            else
                StudentReg.Parameters.Add(new SqlParameter("@password", password.Text));

            if (String.IsNullOrWhiteSpace(address.Text))
                StudentReg.Parameters.Add(new SqlParameter("@address", DBNull.Value));
            else
                StudentReg.Parameters.Add(new SqlParameter("@address", address.Text));

         
            if(gender.SelectedItem==null)
                StudentReg.Parameters.Add(new SqlParameter("@gender", DBNull.Value));
            else
            {
                int gend = Int32.Parse(gender.SelectedItem.Value);
                StudentReg.Parameters.Add(new SqlParameter("@gender", gend));
            }
            
            conn.Open();
            try
            {
                StudentReg.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Response.Write("This Email already exists! ");
                    Response.Write("please add another email!");
                }
                else
                    Response.Write("Failed to register please add valid values!");
                return;
            }
            catch (Exception)
            {
                Response.Write("User cannot be added please check your input values");
                return;
            }
            conn.Close();

            Response.Redirect("Login.aspx");
        }

        protected void genderChoosen(object sender, EventArgs e)
        {

        }
    }
    }
