using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;

namespace TakeAwalk.SystemAdmin
{
    public partial class CustomerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = AuthManager.GetCurrentUser();

            this.ltAccount.Text = currentUser.Account;
            this.txtName.Text = currentUser.Name;
            this.txtID.Text = currentUser.ID;
            this.txtMobilePhone.Text = currentUser.MobilePhone;
            this.txtEmail.Text = currentUser.Email;


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/Customer.aspx");
        }

        protected void btnPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/CustomerPasswordChange.aspx");
        }
    }
}