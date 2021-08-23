using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.DBSource;
namespace TakeAwalk
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gdvTicket.DataSource = TicketManager.GetTrainTicketsList_Default();
            this.gdvTicket.DataBind();
        }
    }
}