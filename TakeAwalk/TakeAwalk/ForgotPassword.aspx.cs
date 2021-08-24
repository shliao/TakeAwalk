using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Support;

namespace TakeAwalk
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string atb = txbAccount.Text;
            string elb = txbEmail.Text;

            string errormsg;
            if (!dbSupport.trySearch(atb, elb, out errormsg))
            {
                this.ltlMsg.Text = $"<span style='color:red'>{errormsg}</span>";
                return;
            }

            Session["UserLoginInfo"] = txbAccount.Text;
            Response.Redirect("/SystemAdmin/ForgotPasswordChange.aspx");
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}