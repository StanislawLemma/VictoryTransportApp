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
    public partial class EditTruck : System.Web.UI.Page
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
                        SqlCommand cmd = new SqlCommand("Select * From truck Where Uid=@Uid", con);
                        cmd.Parameters.AddWithValue("@Uid", id);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "truck");

                        tbTNo.Text = ds.Tables[0].Rows[0]["no"].ToString();
                        tbTPlate.Text = ds.Tables[0].Rows[0]["plate"].ToString();
                        tbTModel.Text = ds.Tables[0].Rows[0]["model"].ToString();
                        tbTYear.Text = ds.Tables[0].Rows[0]["year"].ToString();
                    }
                }
            }
        }

        protected void btUpdateTruck_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("Update truck Set no = @no, plate = @plate, model = @model, year = @year " +
                    "Where Uid = @uid", con);

                cmd.Parameters.AddWithValue("@no", tbTNo.Text);
                cmd.Parameters.AddWithValue("@plate", tbTPlate.Text);
                cmd.Parameters.AddWithValue("@model", tbTModel.Text);
                cmd.Parameters.AddWithValue("@year", tbTYear.Text);
                cmd.Parameters.AddWithValue("@uid", id);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Dispatcher updated.";

                string Message = "Do you want to go back to Trucks?";
                string str_alert_Msg = @"swal.fire({
                            title: 'Truck updated!',
                            icon: 'success',
                            showDenyButton: true,
                            confirmButtonText: 'Back to Trucks',
                            confirmButtonColor: '#3a634c',
                            denyButtonText: 'No',
                            text: '" + Message + @"'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = 'Trucks.aspx';
                            }
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);
            }
        }
    }
}