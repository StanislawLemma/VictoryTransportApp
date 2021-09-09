using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using VictoryTransportApp.Model;

namespace VictoryTransportApp.WebServices
{
    /// <summary>
    /// Summary description for LoadService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LoadService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetLoads()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            List<Load> loads = new List<Load>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("LoadP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Load load = new Load();
                    load.Uid = Convert.ToInt32(rdr["Uid"]);
                    load.Billed = rdr["Billed"].ToString();
                    load.LoadNo = rdr["LoadNo"].ToString();
                    load.Status = rdr["StatusName"].ToString();
                    load.TruckNo = rdr["TruckNo"].ToString();
                    load.DriverName = rdr["DriverName"].ToString();
                    load.BrokerName = rdr["BrokerName"].ToString();
                    load.DispatcherName = rdr["DispatcherName"].ToString();
                    load.CustomerTitle = rdr["CustomerTitle"].ToString();
                    load.RateNo = rdr["RateNo"].ToString();

                    load.PickCompany = rdr["PickCompany"].ToString();
                    load.PickAddressFirstLine = rdr["PickAddressFirstLine"].ToString();
                    load.PickAddressSecondLine = rdr["PickAddressSecondLine"].ToString();
                    load.PickDateStart = Convert.ToDateTime(rdr["PickDateStart"]);
                    load.PickDateEnd = Convert.ToDateTime(rdr["PickDateEnd"]);

                    load.DelCompany = rdr["DelCompany"].ToString();
                    load.DelAddressFirstLine = rdr["DelAddressFirstLine"].ToString();
                    load.DelAddressSecondLine = rdr["DelAddressSecondLine"].ToString();
                    load.DelDateStart = Convert.ToDateTime(rdr["DelDateStart"]);
                    load.DelDateEnd = Convert.ToDateTime(rdr["DelDateEnd"]);

                    load.Note = rdr["Note"].ToString();
                    load.LoadPrice = (double)rdr["LoadPrice"];
                    load.DriverFee = (double)rdr["DriverFee"];
                    load.TollCost = (double)rdr["TollCost"];
                    load.FuelCost = (double)rdr["FuelCost"];
                    load.TotalCost = (double)rdr["TotalCost"];
                    load.Mile = (double)rdr["Mile"];
                    load.MilePrice = (double)rdr["MilePrice"];

                    loads.Add(load);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(loads));
        }
    }
}
