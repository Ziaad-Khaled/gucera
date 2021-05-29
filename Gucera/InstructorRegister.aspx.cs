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
    public partial class InstructorRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register(object sender, EventArgs e)
        {

            
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand Instructorreg = new SqlCommand("InstructorRegister", conn);
            conn.Open();

            Instructorreg.CommandType = CommandType.StoredProcedure;

            if (String.IsNullOrWhiteSpace(first_name.Text)) {
                Instructorreg.Parameters.Add(new SqlParameter("@first_name", DBNull.Value));
            }
            else {
                String firstName = first_name.Text;
                Instructorreg.Parameters.Add(new SqlParameter("@first_name", firstName));

            }
            if (String.IsNullOrWhiteSpace(last_name.Text)) {
                Instructorreg.Parameters.Add(new SqlParameter("@last_name", DBNull.Value));
            }
            else
            {
                String lastName = last_name.Text;
                Instructorreg.Parameters.Add(new SqlParameter("@last_name", lastName));

            }
            if (String.IsNullOrWhiteSpace(email.Text)) {
                Instructorreg.Parameters.Add(new SqlParameter("@email", DBNull.Value));
            }
            else
            {
                String mail = email.Text;
                Instructorreg.Parameters.Add(new SqlParameter("@email", mail));

            }
            if (String.IsNullOrWhiteSpace(password.Text)) {
                Instructorreg.Parameters.Add(new SqlParameter("@password", DBNull.Value));
            }
            else
            {
                String pass = password.Text;
                Instructorreg.Parameters.Add(new SqlParameter("@password", pass));

            }
            if (String.IsNullOrWhiteSpace(address.Text)) {
                Instructorreg.Parameters.Add(new SqlParameter("@address", DBNull.Value));
            }
            else
            {
                String Address = address.Text;
                Instructorreg.Parameters.Add(new SqlParameter("@address", Address));

            }








            if (gender.SelectedItem == null)
                Instructorreg.Parameters.Add(new SqlParameter("@gender", DBNull.Value));
            else
            {
                int gend = Int32.Parse(gender.SelectedItem.Value);
                Instructorreg.Parameters.Add(new SqlParameter("@gender", gend));
            }



            try
            {
                Instructorreg.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Response.Write("This Email already exists ! <br/>");
                    Response.Write("please add another email !");

                }
                
                else
                {   
                    Response.Write("Failed to register please add valid values!"); 
                
                }
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
