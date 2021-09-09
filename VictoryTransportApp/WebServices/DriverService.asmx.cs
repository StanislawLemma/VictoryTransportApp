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
    /// Summary description for DriverService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DriverService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetDrivers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DriverP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Driver driver = new Driver();

                    driver.Uid = Convert.ToInt32(rdr["Uid"]);
                    driver.Name = rdr["Name"].ToString();
                    driver.Ssn = rdr["Ssn"].ToString();
                    driver.Phone = rdr["Phone"].ToString();
                    driver.Email = rdr["Email"].ToString();
                    driver.Address = rdr["Address"].ToString();

                    drivers.Add(driver);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(drivers));
        }
    }
}
