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
    public partial class addCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("Please Log in!");
                return;
            }
        }

        protected void addCC(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("You must be logged in to add a credit card!");
                return;
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            int sid = Int16.Parse(Session["user"].ToString());
            Int32 num = 0;
         
            try//to make sure that the entered value is a number
            {
                num = Int32.Parse(number.Text);
            }
            catch(Exception)
            {
                Response.Write("Please Enter a valid Credit Card Number!");
                return;
            }
            String cardHolder = cardHolderName.Text;
            String expiry = expiryDate.Text;
            String CVV = cvv.Text;
            try//to test whether the cvv is a number
            {
                int cvvTest;
                if(CVV.Length!=0)
                 cvvTest= Int32.Parse(CVV);
            }
            catch(Exception)
            {
                Response.Write("Please enter a valid (3-digit) cvv!");
                return;
            }



            SqlCommand addCard = new SqlCommand("addCreditCard", conn);
            addCard.CommandType = CommandType.StoredProcedure;
            
            addCard.Parameters.Add(new SqlParameter("@sid", sid));
            addCard.Parameters.Add(new SqlParameter("@number", num));
            if (String.IsNullOrWhiteSpace(cardHolder))
                addCard.Parameters.Add(new SqlParameter("@cardHolderName", DBNull.Value));
            else
                addCard.Parameters.Add(new SqlParameter("@cardHolderName", cardHolder));
            if (String.IsNullOrWhiteSpace(expiry))
                addCard.Parameters.Add(new SqlParameter("@expiryDate", DBNull.Value));
            else
              addCard.Parameters.Add(new SqlParameter("@expiryDate", expiry));
            if (String.IsNullOrWhiteSpace(CVV))
                addCard.Parameters.Add(new SqlParameter("@cvv", DBNull.Value));
            else
              addCard.Parameters.Add(new SqlParameter("@cvv", CVV));

            //the number of Added Creditd cards before executing the query
            Int32 count1 = 0;
            //the number of Added Creditd cards after executing the query
            Int32 count2 = 0;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM StudentAddCreditCard", conn);
            count1 = (Int32)cmd.ExecuteScalar();
            try
            {
                
                addCard.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                count2 = (Int32)cmd.ExecuteScalar();
                if (count1 == count2)//to check whether a new record was added
                {
                    Response.Write("This Credit Card Number already exists!");
                    return;
                }
                
            }
            conn.Close();

            Response.Write("Credit Card added successfully!");
        }
    }
}