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
    public partial class Drivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
        }

        [WebMethod]
        public static string deleteDriver(string driver_id)
        {
            if (driver_id != null && driver_id != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Delete From driver Where Uid = @Uid", con);
                    cmd.Parameters.AddWithValue("@Uid", driver_id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "done";
                }

            }

            return "error";
        }

        protected void btSaveDriver_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("insert into driver(name, phone, email, ssn, address) " +
                    "values(@name, @phone, @email, @ssn, @address)", con);

                cmd.Parameters.AddWithValue("@name", txtDName.Text);
                cmd.Parameters.AddWithValue("@phone", txtDPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtDEmail.Text);
                cmd.Parameters.AddWithValue("@ssn", txtDSsn.Text);
                cmd.Parameters.AddWithValue("@address", txtDAddress.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Driver saved.";

                string Message = "Driver saved.";
                string str_alert_Msg = @"swal.fire({
                            title: 'Success!',
                            icon: 'success',
                            text: '" + Message + @"'
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);

                txtDName.Text = string.Empty;
                txtDPhone.Text = string.Empty;
                txtDEmail.Text = string.Empty;
                txtDSsn.Text = string.Empty;
                txtDAddress.Text = string.Empty;
            }
        }
    }
}