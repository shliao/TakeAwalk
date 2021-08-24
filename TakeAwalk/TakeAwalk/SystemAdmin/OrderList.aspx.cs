using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;
using TakeAwalk.DBSource;

namespace TakeAwalk.SystemAdmin
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = AuthManager.GetCurrentUser();

            this.gv_orderlist.DataSource = OrdersManager.GetOrdersListbyCustomerID(currentUser.CustomerID);
            this.gv_orderlist.DataBind();
        }
    }
}