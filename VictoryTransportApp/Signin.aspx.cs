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
using System.Web.UI.HtmlControls;

namespace VictoryTransportApp
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null & Request.Cookies["PWD"] != null)
                {
                    UserName.Text = Request.Cookies["UNAME"].Value;
                    Password.Attributes["value"] = Request.Cookies["PWD"].Value;
                    CheckBox1.Checked = true;
                }

                var control = FindHtmlControlByIdInControl(this, "adminPanel");
                
                if (control != null)
                {
                    control.Style.Add("display", "none");
                }
            }
        }

        private HtmlControl FindHtmlControlByIdInControl(Control control, string id)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl.ID != null && childControl.ID.Equals(id, StringComparison.OrdinalIgnoreCase) && childControl is HtmlControl)
                {
                    return (HtmlControl)childControl;
                }

                if (childControl.HasControls())
                {
                    HtmlControl result = FindHtmlControlByIdInControl(childControl, id);
                    if (result != null) return result;
                }
            }

            return null;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" & Password.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select * From site_users Where username='" + UserName.Text + "' and password='" + Password.Text + "'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        if (CheckBox1.Checked)
                        {
                            Response.Cookies["UNAME"].Value = UserName.Text;
                            Response.Cookies["PWD"].Value = Password.Text;

                            Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["UNAME"].Value = UserName.Text;
                            Response.Cookies["PWD"].Value = Password.Text;

                            Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                        }

                        Session["USERNAME"] = UserName.Text;

                        if (UserName.Text == "Admin")
                        {
                            Response.Redirect("~/admin.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                    }
                    else
                    {
                        Label4.ForeColor = Color.Red;
                        Label4.Text = "User Not Found.";
                    }
                }
            }
            else
            {
                Label4.ForeColor = Color.Red;
                Label4.Text = "Username and Password are Mandatory.";
            }
        }
    }
}