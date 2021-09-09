﻿using System;
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
    public partial class LoadsNew : System.Web.UI.Page
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
                    BindTrucks();
                    BindDrivers();
                    BindCustomers();
                    BindStatus();
                    BindDispatchers();
                }
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

        protected void btSaveLoad_Click(object sender, EventArgs e)
        {
            if (ddlTruckNo.Text != "" & ddlDriverName.Text != "" & ddlDriverName.Text != "0" & ddlTruckNo.Text != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(
                        "insert into load (no, truck_id, driver_id, load_price, driver_fee, explanation, " +
                        "rate_no, fuel_cost, toll_cost, customer_id, mile, mile_price, pick_company, pick_address_first_line, " +
                        "pick_address_second_line, pick_date_begin, pick_date_end, del_company, del_address_first_line, " +
                        "del_address_second_line, del_date_begin, del_date_end, status_id, billed, broker_id, dispatcher_id) " +

                        "values(@no, @truck_id, @driver_id, @load_price, @driver_fee, @explanation, " +
                        "@rate_no, @fuel_cost, @toll_cost, @customer_id, @mile, @mile_price, @pick_company, @pick_address_first_line, " +
                        "@pick_address_second_line, @pick_date_begin, @pick_date_end, @del_company, @del_address_first_line, " +
                        "@del_address_second_line, @del_date_begin, @del_date_end, @status_id, @billed, @broker_id, @dispatcher_id)", con);

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

                    con.Open();
                    cmd.ExecuteNonQuery();
                    //Label26.ForeColor = Color.Green;
                    //Label26.Text = "Load saved.";
                    //BindLoadsRptr();
                    txtLoadNo.Text = string.Empty;
                    txtPCompany.Text = string.Empty;
                    txtPAddress1.Text = string.Empty;
                    txtPZip.Text = string.Empty;
                    txtPStartDate.Text = string.Empty;
                    txtPEndDate.Text = string.Empty;
                    txtDCompany.Text = string.Empty;
                    txtDAddress1.Text = string.Empty;
                    txtDZip.Text = string.Empty;
                    txtDStartDate.Text = string.Empty;
                    txtDEndDate.Text = string.Empty;

                    txtLPrice.Text = string.Empty;
                    txtLDFee.Text = string.Empty;
                    txtLExp.Text = string.Empty;
                    txtLRateNo.Text = string.Empty;
                    txtLFuelCost.Text = string.Empty;
                    txtLTollCost.Text = string.Empty;
                    txtLMiles.Text = string.Empty;
                    txtLMilePrice.Text = string.Empty;

                    chkBilled.Checked = false;

                    ddlStatus.ClearSelection();
                    ddlStatus.Items.FindByValue("0").Selected = true;
                    ddlTruckNo.ClearSelection();
                    ddlTruckNo.Items.FindByValue("0").Selected = true;
                    ddlDriverName.ClearSelection();
                    ddlDriverName.Items.FindByValue("0").Selected = true;
                    ddlCustomer.ClearSelection();
                    ddlCustomer.Items.FindByValue("0").Selected = true;
                    ddlBroker.ClearSelection();
                    ddlBroker.Items.FindByValue("0").Selected = true;
                    ddlDispatcher.ClearSelection();
                    ddlDispatcher.Items.FindByValue("0").Selected = true;

                    string Message = "Load saved.";
                    string str_alert_Msg = @"swal.fire({
                            title: 'Success!',
                            icon: 'success',
                            text: '" + Message + @"'
                        });";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);
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

        protected void rptrLoads_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    string id = e.CommandArgument.ToString();
                    //Label15.Text = id;

                    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Delete From load Where Uid='" + id + "' ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //BindLoadsRptr();
                    }
                    break;

                // Other commands here.

                default:
                    break;
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

        protected void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBroker.Items.Clear();
            //ddlBroker.Items.Insert(0, new ListItem("-Select-", "0"));

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

        [WebMethod]
        public static string deleteLoad(string load_id)
        {
            if (load_id != null && load_id != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Delete From load Where Uid = @Uid", con);
                    cmd.Parameters.AddWithValue("@Uid", load_id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "done";
                }

            }

            return "error";
        }
    }
}