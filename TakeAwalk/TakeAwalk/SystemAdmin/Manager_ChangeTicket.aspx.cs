﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TakeAwalk.SystemAdmin
{
    public partial class Manager_ChangeTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ticketidtxt = this.Request.QueryString["ID"];
            int ticketid = int.Parse(ticketidtxt);
        }
    }
}