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
using System.Web.Services;

namespace VictoryTransportApp
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
        }

        [WebMethod]
        public static string deleteCustomer(string customer_id)
        {
            if (customer_id != null && customer_id != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Delete From customer Where Uid = @Uid", con);
                    cmd.Parameters.AddWithValue("@Uid", customer_id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "done";
                }

            }

            return "error";
        }

        protected void btSaveCustomer_Click(object sender, EventArgs e)
        {
            
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into customer(title, phone, email, address) " +
                "values(@title, @phone, @email, @address)", con);

                cmd.Parameters.AddWithValue("@title", txtCTitle.Text);
                cmd.Parameters.AddWithValue("@phone", txtCPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtCEmail.Text);
                cmd.Parameters.AddWithValue("@address", txtCAddress.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Customer saved.";

                string Message = "Customer saved.";
                string str_alert_Msg = @"swal.fire({
                        title: 'Success!',
                        icon: 'success',
                        text: '" + Message + @"'
                    });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);

                txtCTitle.Text = string.Empty;
                txtCPhone.Text = string.Empty;
                txtCEmail.Text = string.Empty;
                txtCAddress.Text = string.Empty;
            }
        }
    }
}