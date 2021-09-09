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
    /// Summary description for BrokerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BrokerService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetBrokers()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            List<Broker> brokers = new List<Broker>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("BrokerP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Broker broker = new Broker();
                    broker.Uid = Convert.ToInt32(rdr["Uid"]);
                    broker.Name = rdr["Name"].ToString();
                    broker.CustomerTitle = rdr["CustomerTitle"].ToString();
                    broker.Phone = rdr["Phone"].ToString();
                    broker.Email = rdr["Email"].ToString();

                    brokers.Add(broker);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(brokers));
        }

        [WebMethod]
        public void GetBrokersWithParams(string tmpid, string name)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            List<Broker> brokers = new List<Broker>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("BrokerPWithParams", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@tmpid", SqlDbType.VarChar).Value = tmpid;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Broker broker = new Broker();
                    broker.Uid = Convert.ToInt32(rdr["Uid"]);
                    broker.Name = rdr["Name"].ToString();
                    broker.CustomerTitle = rdr["CustomerTitle"].ToString();
                    broker.Phone = rdr["Phone"].ToString();
                    broker.Email = rdr["Email"].ToString();

                    brokers.Add(broker);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(brokers));
        }
    }
}
