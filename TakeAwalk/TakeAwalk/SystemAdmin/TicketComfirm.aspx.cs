using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.DBSource;

namespace TakeAwalk.SystemAdmin
{
    public partial class TicketComfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gv_ticket.DataSource = TicketManager.GetTrainTicketsList();
            this.gv_ticket.DataBind();
        }
    }
}