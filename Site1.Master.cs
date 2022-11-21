using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)

        {
           if (Session["userRole"].Equals("admin"))
            {
                Accounts.Visible = true;
                stock.Visible = true;
                sales.Visible = true;
                Reports.Visible = true;
                Graphs.Visible = true;
            }

            else if (Session["userRole"].Equals("user"))
            {
                sales.Visible = true;
                Graphs.Visible = true;
            }
        }
    }
}