using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.DBSource;

namespace TakeAwalk
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");           //正則表達式排除特殊字元
            if (!rx.IsMatch(txbAccount.Text))
            {
                this.ltlMsg.Text = "<span style='color:red'>帳號不能為特殊字元,請重新輸入</span>";
                return;
            }
            
            string atb = txbAccount.Text;
            string elb = txbEmail.Text;

            string errormsg;
            if (!UserInfoManager.trySearch(atb, elb, out errormsg))
            {
                this.ltlMsg.Text = $"<span style='color:red'>{errormsg}</span>";
                return;
            }

            string body = "驗證碼 : 9267434351 ,請回到火車訂票系統完成驗證.";
            string subject = "TakeAwalk火車訂票系統-忘記密碼確認信";
            UserInfoManager.SendAutomatedEmail(elb, body, subject);

            Session["UserLoginInfo"] = txbAccount.Text;
            Response.Redirect("/SystemAdmin/ForgotPasswordChange.aspx");
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}