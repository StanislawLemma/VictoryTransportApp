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
    public partial class ReportLoadSummary : System.Web.UI.Page
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
                    BindLoadsRptr();
                }
            }
        }

        private void BindLoadsRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(@"select a.no, a.pick_loc, a.del_loc, truck_no=c.no, driver_name=(ISNULL(b.name,'') + ' ' 
                + ISNULL(b.surname,'')), 
                start_date=FORMAT(a.start_date, 'yyyy/MM/dd HH:mm'),
                end_date=FORMAT(a.end_date, 'yyyy/MM/dd HH:mm'), a.rate_no, b.phone
                From load a, driver b, truck c Where a.driver_id=b.Uid and a.truck_id=c.Uid and a.start_date <= getdate() and a.end_date >= getdate()", con))
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
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                String str = "select a.no, a.pick_loc, a.del_loc, truck_no=c.no, driver_name=(ISNULL(b.name,'') + ' ' + ISNULL(b.surname,'')), ";
                str = str + "start_date=FORMAT(a.start_date, 'yyyy/MM/dd HH:mm'), end_date=FORMAT(a.end_date, 'yyyy/MM/dd HH:mm'), ";
                str = str + "a.rate_no, b.phone From load a, driver b, truck c Where a.driver_id=b.Uid and a.truck_id=c.Uid ";
                if (txtLoadNo.Text != "")
                {
                    str = str + "and a.no = '" + txtLoadNo.Text + "'";
                }
                if (txtLRateNo.Text != "")
                {
                    str = str + "and a.rate_no like '%" + txtLRateNo.Text + "%'";
                }

                if (txtLPLoc.Text != "")
                {
                    str = str + "and a.pick_loc like '%" + txtLPLoc.Text + "%'";
                }
                if (txtLDLoc.Text != "")
                {
                    str = str + "and a.del_loc like '%" + txtLDLoc.Text + "%'";
                }
                if (ddlTruckNo.Text != "0")
                {
                    str = str + "and a.truck_id = '" + ddlTruckNo.Text + "'";
                }
                if (ddlDriverName.Text != "0")
                {
                    str = str + "and a.driver_id = '" + ddlDriverName.Text + "'";
                }
                if (txtLStartDate.Text != "")
                {
                    str = str + "and a.start_date >= '" + txtLStartDate.Text + "'";
                }
                if (txtLEndDate.Text != "")
                {
                    str = str + "and a.start_date <= '" + txtLEndDate.Text + "'";
                }

                midTitle.InnerHtml = "Search Results";

                using (SqlCommand cmd = new SqlCommand(str, con))
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

        protected void btClearLoad_Click(object sender, EventArgs e)
        {
            txtLoadNo.Text = string.Empty;
            txtLPLoc.Text = string.Empty;
            txtLDLoc.Text = string.Empty;
            txtLStartDate.Text = string.Empty;
            txtLEndDate.Text = string.Empty;
            txtLRateNo.Text = string.Empty;
            ddlTruckNo.ClearSelection();
            ddlTruckNo.Items.FindByValue("0").Selected = true;
            ddlDriverName.ClearSelection();
            ddlDriverName.Items.FindByValue("0").Selected = true;

            midTitle.InnerHtml = "Active Loads";
            BindLoadsRptr();
        }
    }
}