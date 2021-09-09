using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Data;

namespace VictoryTransportApp
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (NewPassword.Text != NewPassword2.Text)
            {
                Label3.ForeColor = Color.Red;
                Label3.Text = "New Passwords Does Not Match.";
                return;
            }


            if (OldPassword.Text != "" & NewPassword.Text != "" & NewPassword2.Text != "")
            {
                object kullanici = Session["USERNAME"];

                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select * From site_users Where username='" + kullanici.ToString() + "' and password='" + OldPassword.Text + "'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        SqlCommand cmd2 = new SqlCommand("Update site_users Set password= '" + NewPassword.Text + "' Where password= '" + OldPassword.Text + "'", con);
                        //con.Open();
                        cmd2.ExecuteNonQuery();
                        Label3.ForeColor = Color.Green;
                        Label3.Text = "Password Updated.";
                        OldPassword.Text = string.Empty;
                        NewPassword.Text = string.Empty;
                        NewPassword2.Text = string.Empty;
                    }
                    else
                    {
                        Label3.ForeColor = Color.Red;
                        Label3.Text = "Old Password is Wrong.";
                    }
                }
            }
            else
            {
                Label3.ForeColor = Color.Red;
                Label3.Text = "All Fields are Mandatory.";
            }
        }
    }
}