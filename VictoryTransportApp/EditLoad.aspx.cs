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
    public partial class EditLoad : System.Web.UI.Page
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

                    BindTrucks();
                    BindDrivers();
                    BindCustomers();
                    BindStatus();
                    BindDispatchers();

                    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Select * From load Where Uid=@Uid", con);
                        cmd.Parameters.AddWithValue("@Uid", id);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "load");

                        txtLoadNo.Text = ds.Tables[0].Rows[0]["no"].ToString();
                        txtLRateNo.Text = ds.Tables[0].Rows[0]["rate_no"].ToString();

                        ddlStatus.ClearSelection();
                        ddlStatus.Items.FindByValue(ds.Tables[0].Rows[0]["status_id"].ToString()).Selected = true;

                        ddlTruckNo.ClearSelection();
                        ddlTruckNo.Items.FindByValue(ds.Tables[0].Rows[0]["truck_id"].ToString()).Selected = true;

                        ddlDriverName.ClearSelection();
                        ddlDriverName.Items.FindByValue(ds.Tables[0].Rows[0]["driver_id"].ToString()).Selected = true;
                        
                        ddlCustomer.ClearSelection();
                        ddlCustomer.Items.FindByValue(ds.Tables[0].Rows[0]["customer_id"].ToString()).Selected = true;

                        BindAndSelectBroker(ds.Tables[0].Rows[0]["broker_id"].ToString());

                        ddlDispatcher.ClearSelection();
                        ddlDispatcher.Items.FindByValue(ds.Tables[0].Rows[0]["dispatcher_id"].ToString()).Selected = true;

                        txtPCompany.Text = ds.Tables[0].Rows[0]["pick_company"].ToString();
                        txtDCompany.Text = ds.Tables[0].Rows[0]["del_company"].ToString();
                        txtPAddress1.Text = ds.Tables[0].Rows[0]["pick_address_first_line"].ToString();
                        txtDAddress1.Text = ds.Tables[0].Rows[0]["del_address_first_line"].ToString();
                        txtPZip.Text = ds.Tables[0].Rows[0]["pick_address_second_line"].ToString();
                        txtDZip.Text = ds.Tables[0].Rows[0]["del_address_second_line"].ToString();

                        DateTime pickStartDate = (DateTime)ds.Tables[0].Rows[0]["pick_date_begin"];
                        txtPStartDate.Text = pickStartDate.ToString("yyyy/MM/dd HH:mm");

                        DateTime pickEndDate = (DateTime)ds.Tables[0].Rows[0]["pick_date_end"];

                        if (pickEndDate.ToString("yyyy") == "1900")
                        {
                            txtPEndDate.Text = "";
                        }
                        else
                        {
                            txtPEndDate.Text = pickEndDate.ToString("yyyy/MM/dd HH:mm");
                        }

                        DateTime delStartDate = (DateTime)ds.Tables[0].Rows[0]["del_date_begin"];
                        txtDStartDate.Text = delStartDate.ToString("yyyy/MM/dd HH:mm");

                        DateTime delEndDate = (DateTime)ds.Tables[0].Rows[0]["del_date_end"];
                        if (delEndDate.ToString("yyyy") == "1900")
                        {
                            txtDEndDate.Text = "";
                        }
                        else
                        {
                            txtDEndDate.Text = delEndDate.ToString("yyyy/MM/dd HH:mm");
                        }

                        txtLPrice.Text = ds.Tables[0].Rows[0]["load_price"].ToString();
                        txtLDFee.Text = ds.Tables[0].Rows[0]["driver_fee"].ToString();
                        txtLFuelCost.Text = ds.Tables[0].Rows[0]["fuel_cost"].ToString();
                        txtLTollCost.Text = ds.Tables[0].Rows[0]["toll_cost"].ToString();
                        txtLMiles.Text = ds.Tables[0].Rows[0]["mile"].ToString();
                        txtLMilePrice.Text = ds.Tables[0].Rows[0]["mile_price"].ToString();
                        txtLExp.Text = ds.Tables[0].Rows[0]["explanation"].ToString();

                        var billed = ds.Tables[0].Rows[0]["billed"].ToString();

                        chkBilled.Checked = (billed == "1");
                        
                    }
                }
            }
        }

        protected void BindAndSelectBroker(string broker_id)
        {
            ddlBroker.Items.Clear();

            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from broker Where customer_id = @customer_id", con);
                cmd.Parameters.AddWithValue("@customer_id", ddlCustomer.SelectedItem.Value);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlBroker.DataSource = dt;
                    ddlBroker.DataTextField = "name";
                    ddlBroker.DataValueField = "Uid";
                    ddlBroker.DataBind();
                    ddlBroker.Items.Insert(0, new ListItem("-Select-", "0"));

                    ddlBroker.Items.FindByValue(broker_id).Selected = true;
                }
            }
        }

        protected void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBroker.Items.Clear();

            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from broker Where customer_id = @customer_id", con);
                cmd.Parameters.AddWithValue("@customer_id", ddlCustomer.SelectedItem.Value);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlBroker.DataSource = dt;
                    ddlBroker.DataTextField = "name";
                    ddlBroker.DataValueField = "Uid";
                    ddlBroker.DataBind();
                    ddlBroker.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        private void BindDispatchers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from dispatcher", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlDispatcher.DataSource = dt;
                    ddlDispatcher.DataTextField = "name";
                    ddlDispatcher.DataValueField = "Uid";
                    ddlDispatcher.DataBind();
                    ddlDispatcher.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }
        }

        private void BindDrivers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from driver", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlDriverName.DataSource = dt;
                    ddlDriverName.DataTextField = "name";
                    ddlDriverName.DataValueField = "Uid";
                    ddlDriverName.DataBind();
                    ddlDriverName.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }
        }

        private void BindStatus()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from load_status", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlStatus.DataSource = dt;
                    ddlStatus.DataTextField = "status_name";
                    ddlStatus.DataValueField = "Uid";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new ListItem("-Select-", "0"));
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

        private void BindTrucks()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from truck", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlTruckNo.DataSource = dt;
                    ddlTruckNo.DataTextField = "no";
                    ddlTruckNo.DataValueField = "Uid";
                    ddlTruckNo.DataBind();
                    ddlTruckNo.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void btUpdateLoad_Click(object sender, EventArgs e)
        {
            if (ddlTruckNo.Text != "" & ddlDriverName.Text != "" & ddlDriverName.Text != "0" & ddlTruckNo.Text != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(
                        "Update load Set no=@no, truck_id=@truck_id, driver_id=@driver_id, load_price=@load_price, driver_fee=@driver_fee, " +
                        "explanation=@explanation, rate_no=@rate_no, fuel_cost=@fuel_cost, toll_cost=@toll_cost, customer_id=@customer_id, " +
                        "mile=@mile, mile_price=@mile_price, pick_company=@pick_company, pick_address_first_line=@pick_address_first_line, " +
                        "pick_address_second_line=@pick_address_second_line, pick_date_begin=@pick_date_begin, pick_date_end=@pick_date_end, " +
                        "del_company=@del_company, del_address_first_line=@del_address_first_line, del_address_second_line=@del_address_second_line, " +
                        "del_date_begin=@del_date_begin, del_date_end=@del_date_end, status_id=@status_id, billed=@billed, broker_id=@broker_id,  " +
                        "dispatcher_id=@dispatcher_id Where Uid = @Uid", con); 

                    cmd.Parameters.AddWithValue("@no", txtLoadNo.Text);
                    cmd.Parameters.AddWithValue("@truck_id", ddlTruckNo.Text);
                    cmd.Parameters.AddWithValue("@driver_id", ddlDriverName.Text);
                    cmd.Parameters.AddWithValue("@load_price", txtLPrice.Text);
                    cmd.Parameters.AddWithValue("@driver_fee", txtLDFee.Text);
                    cmd.Parameters.AddWithValue("@explanation", txtLExp.Text);
                    cmd.Parameters.AddWithValue("@rate_no", txtLRateNo.Text);
                    cmd.Parameters.AddWithValue("@fuel_cost", txtLFuelCost.Text);
                    cmd.Parameters.AddWithValue("@toll_cost", txtLTollCost.Text);
                    cmd.Parameters.AddWithValue("@customer_id", ddlCustomer.Text);
                    cmd.Parameters.AddWithValue("@mile", txtLMiles.Text);
                    cmd.Parameters.AddWithValue("@mile_price", txtLMilePrice.Text);
                    cmd.Parameters.AddWithValue("@pick_company", txtPCompany.Text);
                    cmd.Parameters.AddWithValue("@pick_address_first_line", txtPAddress1.Text);
                    cmd.Parameters.AddWithValue("@pick_address_second_line", txtPZip.Text);
                    cmd.Parameters.AddWithValue("@pick_date_begin", txtPStartDate.Text);
                    cmd.Parameters.AddWithValue("@pick_date_end", txtPEndDate.Text);
                    cmd.Parameters.AddWithValue("@del_company", txtDCompany.Text);
                    cmd.Parameters.AddWithValue("@del_address_first_line", txtDAddress1.Text);
                    cmd.Parameters.AddWithValue("@del_address_second_line", txtDZip.Text);
                    cmd.Parameters.AddWithValue("@del_date_begin", txtDStartDate.Text);
                    cmd.Parameters.AddWithValue("@del_date_end", txtDEndDate.Text);
                    cmd.Parameters.AddWithValue("@status_id", ddlStatus.Text);
                    cmd.Parameters.AddWithValue("@billed", chkBilled.Checked);
                    cmd.Parameters.AddWithValue("@broker_id", ddlBroker.Text);
                    cmd.Parameters.AddWithValue("@dispatcher_id", ddlDispatcher.Text);
                    cmd.Parameters.AddWithValue("@Uid", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    //Label26.ForeColor = Color.Green;
                    //Label26.Text = "Load updated.";

                    string Message = "Do you want to go back to Loads?";
                    string str_alert_Msg = @"swal.fire({
                            title: 'Load updated!',
                            icon: 'success',
                            showDenyButton: true,
                            confirmButtonText: 'Back to Loads',
                            confirmButtonColor: '#3a634c',
                            denyButtonText: 'No',
                            text: '" + Message + @"'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = 'LoadsNew.aspx';
                            }
                        });";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "toastr", "toastr.success('Load updated')", true);
                }

            }
            else
            {
                //Label26.ForeColor = Color.Red;
                //Label26.Text = "Truck # and Driver are Mandatory.";

                string Message = "Truck # and Driver are Mandatory.";
                string str_alert_Msg = @"swal.fire({
                            title: 'Error!',
                            icon: 'error',
                            text: '" + Message + @"'
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", str_alert_Msg, true);
            }
        }

        protected void btDirections_Click(object sender, EventArgs e)
        {
            string link = "https://google.com/maps/dir/";
            string pickupZip = txtPZip.Text;
            string deliveryZip = txtDZip.Text;
            link = link + pickupZip + "/" + deliveryZip;

            //Response.Redirect(link);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", link, true);
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "openModal", "window.open(link ,'_blank');", true);
            Response.Write("<script>window.open ('" + link + "','_blank');</script>");
        }
    }
}