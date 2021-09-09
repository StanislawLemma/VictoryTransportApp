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
    public partial class EditCustomer : System.Web.UI.Page
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
                        SqlCommand cmd = new SqlCommand("Select * From customer Where Uid=@Uid", con);
                        cmd.Parameters.AddWithValue("@Uid", id);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "driver");

                        txtCTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                        txtCPhone.Text = ds.Tables[0].Rows[0]["email"].ToString();
                        txtCEmail.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                        txtCAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                    }
                }
            }
        }

        protected void btUpdateCustomer_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("Update customer Set title = @title, phone = @phone, email = @email, " +
                    "address = @address Where Uid = @uid", con);

                cmd.Parameters.AddWithValue("@title", txtCTitle.Text);
                cmd.Parameters.AddWithValue("@phone", txtCPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtCEmail.Text);
                cmd.Parameters.AddWithValue("@address", txtCAddress.Text);
                cmd.Parameters.AddWithValue("@uid", id);

                con.Open();
                cmd.ExecuteNonQuery();

                string Message = "Do you want to go back to Customers?";
                string str_alert_Msg = @"swal.fire({
                            title: 'Customer updated!',
                            icon: 'success',
                            showDenyButton: true,
                            confirmButtonText: 'Back to Customers',
                            confirmButtonColor: '#3a634c',
                            denyButtonText: 'No',
                            text: '" + Message + @"'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = 'Customers.aspx';
                            }
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);
            }
        }
    }
}