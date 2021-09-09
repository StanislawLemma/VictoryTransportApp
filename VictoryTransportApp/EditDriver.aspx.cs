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
    public partial class EditDriver : System.Web.UI.Page
    {
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
                return;
            }

            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "0")
            {
                id = Request.QueryString["id"].ToString();

                if (!IsPostBack)
                {
                    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Select * From driver Where Uid=@Uid", con);
                        cmd.Parameters.AddWithValue("@Uid", id);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "driver");

                        txtDName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        txtDEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                        txtDPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                        txtDSsn.Text = ds.Tables[0].Rows[0]["ssn"].ToString();
                        txtDAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                    }
                }
            }
        }

        protected void btUpdateDriver_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("Update driver Set name = @name, phone = @phone, email = @email, ssn = @ssn, " +
                    "address = @address Where Uid = @uid", con);

                cmd.Parameters.AddWithValue("@name", txtDName.Text);
                cmd.Parameters.AddWithValue("@phone", txtDPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtDEmail.Text);
                cmd.Parameters.AddWithValue("@ssn", txtDSsn.Text);
                cmd.Parameters.AddWithValue("@address", txtDAddress.Text);
                cmd.Parameters.AddWithValue("@uid", id);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Dispatcher updated.";

                string Message = "Do you want to go back to Drivers?";
                string str_alert_Msg = @"swal.fire({
                            title: 'Driver updated!',
                            icon: 'success',
                            showDenyButton: true,
                            confirmButtonText: 'Back to Drivers',
                            confirmButtonColor: '#3a634c',
                            denyButtonText: 'No',
                            text: '" + Message + @"'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = 'Drivers.aspx';
                            }
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);
            }
        }
    }
}