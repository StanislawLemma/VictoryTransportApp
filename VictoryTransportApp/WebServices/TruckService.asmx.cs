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
    /// Summary description for TruckService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TruckService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetTrucks()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            List<Truck> trucks = new List<Truck>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("TruckP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Truck truck = new Truck();
                    truck.Uid = Convert.ToInt32(rdr["Uid"]);
                    truck.No = rdr["No"].ToString();
                    truck.Plate = rdr["Plate"].ToString();
                    truck.Model = rdr["Model"].ToString();
                    truck.Year = rdr["Year"].ToString();

                    trucks.Add(truck);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(trucks));
        }
    }
}
