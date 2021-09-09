using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoryTransportApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Cookies["UNAME"].Value != "Admin")
            //{
            //    adminPanel.Style.Add("display", "none");
            //}
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["USERNAME"] = null;
            adminPanel.Style.Add("display", "none");
            Response.Redirect("~/signin.aspx");
        }
    }
}