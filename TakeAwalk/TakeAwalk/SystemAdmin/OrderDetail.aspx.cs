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
    public partial class OrderDetail : System.Web.UI.Page
    {
        public UserInfoModel currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)                           // 可能是按鈕跳回本頁，所以要判斷 postback
            //{
            //    if (!AuthManager.IsLogined())                // 如果尚未登入，導至登入頁
            //    {
            //        Response.Redirect("/Login.aspx");
            //        return;
            //    }

            currentUser = AuthManager.GetCurrentUser();

            //if (currentUser == null)                             // 如果帳號不存在，導至登入頁
            //{
            //    Response.Redirect("/Login.aspx");
            //    return;
            //}

            string idtxt = this.Request.QueryString["ID"];
            int id = int.Parse(idtxt);

            if (currentUser.UserLevel != 0)
            {
                this.gv_orderdetails.DataSource = OrdersManager.GetOrderDetailsbyOrderID(currentUser.CustomerID, id);
                this.gv_orderdetails.DataBind();
            }
            else if (currentUser.UserLevel == 0)
            {
                this.gv_orderdetails.DataSource = OrdersManager.GetOrderDetailsbyOrderID_AdminOnly(id);
                this.gv_orderdetails.DataBind();
            }
        }

        protected void Imgbtn_delete_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}