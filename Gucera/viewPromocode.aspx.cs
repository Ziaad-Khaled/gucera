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
    public partial class viewPromocode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("You must be logged in to show your issued Promocodes");
                return;
            }
            int sid = Int16.Parse(Session["user"].ToString());

            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand promocodes = new SqlCommand("viewPromocode", conn);

            promocodes.CommandType = CommandType.StoredProcedure;
            promocodes.Parameters.Add(new SqlParameter("@sid", sid));

            conn.Open();
            Boolean f = false;//a flag to check whether there is any promocodes
            SqlDataReader rdr = promocodes.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                if (!rdr.IsDBNull(rdr.GetOrdinal("code")))
                {
                    f = true;
                    String code = rdr.GetString(rdr.GetOrdinal("code"));
                    Label lbl_code = new Label();
                    lbl_code.Text = "Code: " + code + " || ";
                    form1.Controls.Add(lbl_code);
                }
                else
                {
                    Label lbl_code = new Label();
                    lbl_code.Text = "Code: " + "N/A " + " || ";
                    form1.Controls.Add(lbl_code);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("isuueDate")))
                { 
                    DateTime issueDate = rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                    Label lbl_issue_date = new Label();
                    lbl_issue_date.Text = "Issue Date: " + issueDate + " || ";
                    form1.Controls.Add(lbl_issue_date);
                }
                else
                {
                    Label lbl_issue_date = new Label();
                    lbl_issue_date.Text = "Issue Date: " + " N/A " + " || ";
                    form1.Controls.Add(lbl_issue_date);

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("expiryDate")))
                {
                    DateTime expiryDate = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                    Label lbl_expiry_date = new Label();
                    lbl_expiry_date.Text = "Expiry Date: " + expiryDate + " || ";
                    form1.Controls.Add(lbl_expiry_date);
                }
                else
                {
                    Label lbl_expiry_date = new Label();
                    lbl_expiry_date.Text = "Expiry Date: " + "N/A " + " || ";
                    form1.Controls.Add(lbl_expiry_date);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("discount")))
                {
                    decimal discount = rdr.GetDecimal(rdr.GetOrdinal("discount"));
                    Label lbl_discount = new Label();
                    lbl_discount.Text = "Discount: " + discount + " || ";
                    form1.Controls.Add(lbl_discount);
                }
                else
                {
                    Label lbl_discount = new Label();
                    lbl_discount.Text = "Discount: " + "N/A " + " || ";
                    form1.Controls.Add(lbl_discount);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("adminId")))
                {
                    int adminId = rdr.GetInt32(rdr.GetOrdinal("adminId"));
                    Label admin_id = new Label();
                    admin_id.Text = "Admin ID: " + adminId + "<br />";

                    form1.Controls.Add(admin_id);
                }
                else
                {
                    Label admin_id = new Label();
                    admin_id.Text = "Admin ID: " + "N/A " + "<br />";

                    form1.Controls.Add(admin_id);

                }

            }
            if(!f)//if there are no promocodes found
            {
                Label1.Style.Add("display", "none");//hide the label that says: "These are all the promocodes"
                Response.Write("No Promocodes are issued by the admin at the moment.");

            }
            conn.Close();
        }
    }
}