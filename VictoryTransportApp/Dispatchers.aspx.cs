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
    public partial class Dispatchers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
        }

        [WebMethod]
        public static string deleteDispatcher(string dispatcher_id)
        {
            if (dispatcher_id != null && dispatcher_id != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Delete From dispatcher Where Uid = @Uid", con);
                    cmd.Parameters.AddWithValue("@Uid", dispatcher_id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "done";
                }

            }

            return "error";
        }

        protected void btSaveDispatcher_Click(object sender, EventArgs e)
        {

            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                
                SqlCommand cmd = new SqlCommand("insert into dispatcher(name, phone, email, ssn) " +
                    "values(@name, @phone, @email, @ssn)", con);

                cmd.Parameters.AddWithValue("@name", txtDispatcherName.Text);
                cmd.Parameters.AddWithValue("@phone", txtDispatcherPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ssn", txtDispatcherSsn.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Dispatcher saved.";

                string Message = "Dispatcher saved.";
                string str_alert_Msg = @"swal.fire({
                            title: 'Success!',
                            icon: 'success',
                            text: '" + Message + @"'
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);

                txtDispatcherName.Text = string.Empty;
                txtDispatcherPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDispatcherSsn.Text = string.Empty;
            }
        }

        public static void Log(string value)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into Test(test_value) values(@test_value)", con);
                cmd.Parameters.AddWithValue("@test_value", value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}