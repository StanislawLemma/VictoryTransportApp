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
    public partial class EditBroker : System.Web.UI.Page
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
                    BindCustomers();

                    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Select * From broker Where Uid=@Uid", con);
                        cmd.Parameters.AddWithValue("@Uid", id);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "dispatcher");

                        txtBrokerName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                        txtBrokerPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();

                        ddlCustomer.ClearSelection();
                        ddlCustomer.Items.FindByValue(ds.Tables[0].Rows[0]["customer_id"].ToString()).Selected = true;
                    }
                }
            }
        }

        private void BindCustomers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from customer", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlCustomer.DataSource = dt;
                    ddlCustomer.DataTextField = "title";
                    ddlCustomer.DataValueField = "Uid";
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }
        }

        protected void btUpdateBroker_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("Update broker Set name = @name, phone = @phone, email = @email, customer_id = @customer_id " +
                    "Where Uid = @uid", con);

                cmd.Parameters.AddWithValue("@name", txtBrokerName.Text);
                cmd.Parameters.AddWithValue("@phone", txtBrokerPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@customer_id", ddlCustomer.Text);
                cmd.Parameters.AddWithValue("@uid", id);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Broker updated.";

                string Message = "Do you want to go back to Brokers?";
                string str_alert_Msg = @"swal.fire({
                            title: 'Broker updated!',
                            icon: 'success',
                            showDenyButton: true,
                            confirmButtonText: 'Back to Brokers',
                            confirmButtonColor: '#3a634c',
                            denyButtonText: 'No',
                            text: '" + Message + @"'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = 'Brokers.aspx';
                            }
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);
            }
        }
    }
}