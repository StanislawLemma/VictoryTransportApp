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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindUsersRptr();
                }
            }
        }

        private void BindUsersRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from site_users Where username<>'Admin' ", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtTruck = new DataTable();
                        sda.Fill(dtTruck);
                        rptrUsers.DataSource = dtTruck;
                        rptrUsers.DataBind();
                    }
                }
            }
        }

        protected void btSaveUser_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != "" & tbPassword.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into site_users values('" + tbUsername.Text + "', '" + tbPassword.Text + "', '" + tbEmail.Text + "', '" + tbName.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "User saved.";
                    BindUsersRptr();
                    tbUsername.Text = string.Empty;
                    tbPassword.Text = string.Empty;
                    tbEmail.Text = string.Empty;
                    tbName.Text = string.Empty;
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Username and Password are Mandatory.";
            }
        }

        protected void rptrUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    string id = e.CommandArgument.ToString();

                    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Delete From site_users Where Uid='" + id + "' ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        lblMsg.Text = "";
                        BindUsersRptr();
                    }
                    break;

                // Other commands here.

                default:
                    break;
            }
        }
    }
}