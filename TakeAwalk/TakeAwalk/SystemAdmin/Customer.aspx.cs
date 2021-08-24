using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;

namespace TakeAwalk.SystemAdmin
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)                           // 可能是按鈕跳回本頁，所以要判斷 postback
            //{
            //    if (!AuthManager.IsLogined())                // 如果尚未登入，導至登入頁
            //    {
            //        Response.Redirect("/Login.aspx");
            //        return;
            //    }

                var currentUser = AuthManager.GetCurrentUser();

                //if (currentUser == null)                             // 如果帳號不存在，導至登入頁
                //{
                //    Response.Redirect("/Login.aspx");
                //    return;
                //}

                this.ltAccount.Text = currentUser.Account;
                this.ltName.Text = currentUser.Name;
                this.ltID.Text = currentUser.ID;
                this.ltMobilePhone.Text = currentUser.MobilePhone;
                this.ltEmail.Text = currentUser.Email;
            }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var currentUser = AuthManager.GetCurrentUser();

            Response.Redirect("/SystemAdmin/CustomerDetail.aspx?CustomerID=" + currentUser.CustomerID);
        }
    }
    }