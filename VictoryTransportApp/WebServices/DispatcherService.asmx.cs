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
    /// Summary description for DispatcherService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DispatcherService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetDispatchers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            List<Dispatcher> dispatchers = new List<Dispatcher>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DispatcherP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Dispatcher dispatcher = new Dispatcher();
                    
                    dispatcher.Uid = Convert.ToInt32(rdr["Uid"]);
                    dispatcher.Name = rdr["Name"].ToString();
                    dispatcher.Ssn = rdr["Ssn"].ToString();
                    dispatcher.Phone = rdr["Phone"].ToString();
                    dispatcher.Email = rdr["Email"].ToString();

                    dispatchers.Add(dispatcher);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(dispatchers));
        }
    }
}
