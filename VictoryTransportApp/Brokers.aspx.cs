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
    public partial class Brokers : System.Web.UI.Page
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
                    BindCustomers();
                }
            }
        }

        [WebMethod]
        public static string deleteBroker(string broker_id)
        {
            if (broker_id != null && broker_id != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Delete From broker Where Uid = @Uid", con);
                    cmd.Parameters.AddWithValue("@Uid", broker_id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "done";
                }

            }

            return "error";
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

        protected void btSaveBroker_Click(object sender, EventArgs e)
        {
            if (ddlCustomer.Text != "" & ddlCustomer.Text != "0")
            {

                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    
                    SqlCommand cmd = new SqlCommand("insert into broker(customer_id, name, phone, email) " +
                        "values(@customer_id, @name, @phone, @email)", con);

                    cmd.Parameters.AddWithValue("@customer_id", ddlCustomer.Text);
                    cmd.Parameters.AddWithValue("@name", txtBrokerName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtBrokerPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //lblMsg.ForeColor = Color.Green;
                    //lblMsg.Text = "Broker saved.";

                    string Message = "Broker saved.";
                    string str_alert_Msg = @"swal.fire({
                            title: 'Success!',
                            icon: 'success',
                            text: '" + Message + @"'
                        });";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);

                    ddlCustomer.ClearSelection();
                    ddlCustomer.Items.FindByValue("0").Selected = true;

                    txtBrokerName.Text = string.Empty;
                    txtBrokerPhone.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                }

            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Customer is Mandatory.";

                string Message = "Customer is Mandatory.";
                string str_alert_Msg = @"swal.fire({
                            title: 'Error!',
                            icon: 'error',
                            text: '" + Message + @"'
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", str_alert_Msg, true);
            }
        }
    }
}