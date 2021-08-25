using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.DBSource;
using TakeAwalk.Support;

namespace TakeAwalk.SystemAdmin
{
    public partial class CustomerPasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlCheckInput.Text = string.Empty;
            this.ltlMsg.Text = string.Empty;
            this.ltlMsg2.Text = string.Empty;

            if (!IsPostBack)
            {
                if (this.Session["UserLoginInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                string account = this.Session["UserLoginInfo"] as string;
                var userInfo = UserInfoManager.GetUserInfoByAccount(account);

                if (userInfo == null)
                {
                    this.Session["UserLoginInfo"] = null;
                    Response.Redirect("/Login.aspx");
                    return;
                }

                this.ltlAccount.Text = userInfo.Account;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string account = this.Session["UserLoginInfo"] as string;
            var userInfo = UserInfoManager.GetUserInfoByAccount(account);

            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");
            if (!rx.IsMatch(txbPassword.Text))
            {
                this.ltlMsg.Text = "<span style='color:red'>原密碼不能為特殊字元,請重新輸入</span>";
                return;
            }
            if (!rx.IsMatch(txbNewPassword.Text))
            {
                this.ltlMsg2.Text = "<span style='color:red'>新密碼不能為特殊字元,請重新輸入</span>";
                return;
            }

            string dbPWD = userInfo.Password;
            string iptPWD = txbPassword.Text;
            string iptNewPWD = txbNewPassword.Text;
            string iptNewPWD_Check = txbNewPasswordCmf.Text;

            List<string> msgList = new List<string>();
            if (!CheckInput(out msgList))
            {
                this.ltlCheckInput.Text = string.Join("<br/>", msgList);
                return;
            }
            else
            {
                if (dbPWD == iptPWD)
                {
                    this.txbPassword.Text = userInfo.Password;
                }
                else
                {
                    this.ltlMsg.Text = "<span style='color:red'>原密碼輸入有錯誤,請重新輸入.</span>";
                    return;
                }

                if (iptNewPWD == iptNewPWD_Check)
                {
                    dbSupport.UpdatePWD(userInfo.CustomerID, iptNewPWD_Check);
                    //this.Session["UserLoginInfo"] = null;
                    Response.Redirect("/SystemAdmin/CustomerDetail.aspx");
                    return;
                }
                else
                {
                    this.ltlMsg2.Text = "<span style='color:red'>新密碼與確認密碼不一致,請重新輸入.</span>";
                    return;
                }
            }
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txbPassword.Text.Trim()) || string.IsNullOrEmpty(this.txbPassword.Text.Trim()))
            {
                msgList.Add("<span style='color:red'>請輸入原密碼.</span>");
            }
            if (string.IsNullOrWhiteSpace(this.txbNewPassword.Text.Trim()) || string.IsNullOrEmpty(this.txbNewPassword.Text.Trim()))
            {
                msgList.Add("<span style='color:red'>請輸入新密碼.</span>");
            }
            if (string.IsNullOrWhiteSpace(this.txbNewPasswordCmf.Text.Trim()) || string.IsNullOrEmpty(this.txbNewPasswordCmf.Text.Trim()))
            {
                msgList.Add("<span style='color:red'>請輸入確認密碼.</span>");
            }
            if (this.txbPassword.Text.Length < 8)
            {
                msgList.Add("<span style='color:red'>原密碼長度應為八到十八碼.</span>");
            }
            if (this.txbNewPassword.Text.Length < 8)
            {
                msgList.Add("<span style='color:red'>新密碼長度應為八到十八碼.</span>");
            }
            if (this.txbNewPasswordCmf.Text.Length < 8)
            {
                msgList.Add("<span style='color:red'>新密碼長度應為八到十八碼.</span>");
            }
            errorMsgList = msgList;

            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/CustomerDetail.aspx");
        }
    }
}