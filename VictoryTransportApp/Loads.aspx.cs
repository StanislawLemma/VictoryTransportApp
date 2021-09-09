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
    public partial class Loads : System.Web.UI.Page
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
                    BindLoadsRptr();
                }
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
                        BindLoadsRptr();
                    }
                    break;

                // Other commands here.

                default:
                    break;
            }
        }

        private void BindLoadsRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(@"Select a.Uid, a.no, a.pick_loc, a.del_loc, truck_no=c.no, driver_name=(ISNULL(b.name,'') + ' ' 
                + ISNULL(b.surname,'')), a.load_price, a.driver_fee, d.title,
                start_date=FORMAT(a.start_date, 'yyyy/MM/dd HH:mm'),
                end_date=FORMAT(a.end_date, 'yyyy/MM/dd HH:mm'),
                a.explanation, a.toll_cost, a.fuel_cost, a.rate_no, a.total_cost, a.mile, a.mile_price
                From load a left join customer d ON a.customer_id=d.uid, driver b, truck c Where a.driver_id=b.Uid and a.truck_id=c.Uid", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtLoad = new DataTable();
                        sda.Fill(dtLoad);
                        rptrLoads.DataSource = dtLoad;
                        rptrLoads.DataBind();
                    }
                }
            }
        }

        private void BindDrivers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select name_surname=(ISNULL(name,'') + ' ' + ISNULL(surname,'')), * from driver", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlDriverName.DataSource = dt;
                    ddlDriverName.DataTextField = "name_surname";
                    ddlDriverName.DataValueField = "Uid";
                    ddlDriverName.DataBind();
                    ddlDriverName.Items.Insert(0, new ListItem("-Select-", "0"));
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

        protected void btSaveLoad_Click(object sender, EventArgs e)
        {
            if (txtLoadNo.Text != "" & ddlTruckNo.Text != "" & ddlDriverName.Text != "")
            {

                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into load values('" + txtLoadNo.Text + "', '" + txtLPLoc.Text + "', '" + txtLDLoc.Text + "', '" + ddlTruckNo.Text + "', '"
                        + ddlDriverName.Text + "', '" + txtLPrice.Text + "', '" + txtLDFee.Text + "', '" + txtLStartDate.Text + "', '"
                        + txtLEndDate.Text + "', 0, '" + txtLExp.Text + "', '" + txtLRateNo.Text + "', '" + txtLFuelCost.Text + "', '"
                        + txtLTollCost.Text + "', null, '" + ddlCustomer.Text + "', '" + txtLMiles.Text + "', '" + txtLMilePrice.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Label15.ForeColor = Color.Green;
                    Label15.Text = "Load saved.";
                    BindLoadsRptr();
                    txtLoadNo.Text = string.Empty;
                    txtLPLoc.Text = string.Empty;
                    txtLDLoc.Text = string.Empty;
                    txtLPrice.Text = string.Empty;
                    txtLDFee.Text = string.Empty;
                    txtLStartDate.Text = string.Empty;
                    txtLEndDate.Text = string.Empty;
                    txtLExp.Text = string.Empty;
                    txtLRateNo.Text = string.Empty;
                    txtLFuelCost.Text = string.Empty;
                    txtLTollCost.Text = string.Empty;
                    txtLMiles.Text = string.Empty;
                    txtLMilePrice.Text = string.Empty;

                    ddlTruckNo.ClearSelection();
                    ddlTruckNo.Items.FindByValue("0").Selected = true;
                    ddlDriverName.ClearSelection();
                    ddlDriverName.Items.FindByValue("0").Selected = true;
                    ddlCustomer.ClearSelection();
                    ddlCustomer.Items.FindByValue("0").Selected = true;
                }

            }
            else
            {
                Label15.ForeColor = Color.Red;
                Label15.Text = "Load #, Truck # and Driver are Mandatory.";
            }
        }
    }
}