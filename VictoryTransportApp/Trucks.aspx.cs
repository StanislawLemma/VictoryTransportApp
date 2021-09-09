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
    public partial class Trucks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            //if (!IsPostBack)
            //{
            //    //BindTrucksRptr();

            //}
        }

        //private void BindTrucksRptr()
        //{
        //    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select * from truck", con))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dtTruck = new DataTable();
        //                sda.Fill(dtTruck);
        //                rptrTrucks.DataSource = dtTruck;
        //                rptrTrucks.DataBind();
        //            }
        //        }
        //    }
        //}

        [WebMethod]
        public static string deleteTruck(string truck_id)
        {
            if (truck_id != null && truck_id != "0")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Delete From truck Where Uid = @Uid", con);
                    cmd.Parameters.AddWithValue("@Uid", truck_id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "done";
                }

            }

            return "error";
        }

        protected void btSaveTruck_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into truck (no, plate, model, year) " +
                    "values(@no, @plate, @model, @year)", con);

                cmd.Parameters.AddWithValue("@no", tbTNo.Text);
                cmd.Parameters.AddWithValue("@plate", tbTPlate.Text);
                cmd.Parameters.AddWithValue("@model", tbTModel.Text);
                cmd.Parameters.AddWithValue("@year", tbTYear.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                //lblMsg.ForeColor = Color.Green;
                //lblMsg.Text = "Truck saved.";

                string Message = "Truck saved.";
                string str_alert_Msg = @"swal.fire({
                            title: 'Success!',
                            icon: 'success',
                            text: '" + Message + @"'
                        });";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", str_alert_Msg, true);
                //BindTrucksRptr();
                tbTNo.Text = string.Empty;
                tbTPlate.Text = string.Empty;
                tbTModel.Text = string.Empty;
                tbTYear.Text = string.Empty;
            }
        }
        
        protected void rptrTrucks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //Bu eski tablonun metodu.
            switch (e.CommandName)
            {
                case "delete":
                    string id = e.CommandArgument.ToString();

                    String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Delete From truck Where Uid='" + id + "' ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //BindTrucksRptr();
                    }
                    break;

                // Other commands here.

                default:
                    break;
            }
        }
    }
}