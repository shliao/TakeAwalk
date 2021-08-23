using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;

namespace TakeAwalk
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txbAccount.Text;
            string inp_PWD = this.txbPassword.Text;

            string msg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.ltlMsg.Text = msg;
                return;
            }


            Response.Redirect("/SystemAdmin/Customer.aspx");
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}