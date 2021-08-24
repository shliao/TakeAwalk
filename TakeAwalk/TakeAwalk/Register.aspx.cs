using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.ORM.DBModels;
using TakeAwalk.Support;

namespace TakeAwalk
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            Guid Cid = Guid.NewGuid();




            UserInfo userInfo = new UserInfo()
            {

                Name = txbName.Text,
                MobilePhone = txbMobilePhone.Text,
                Email = txbEmail.Text,
                Account = txbAccount.Text,
                Password = txbPassword.Text,
                ID = txbId.Text,
                CustomerID = Cid
            };

            dbSupport.CreateCustomer(userInfo);

            Response.Redirect("/Login.aspx");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txbAccount.Text) || string.IsNullOrEmpty(this.txbAccount.Text))
                msglist.Add("<span style='color:red'>帳號為必填(英數字元)</span>");
            else if (this.txbAccount.Text.Length < 3)
                msglist.Add("<span style='color:red'>帳號長度應為三到十八碼.</span>");

            else if (string.IsNullOrWhiteSpace(this.txbPassword.Text) || string.IsNullOrEmpty(this.txbPassword.Text))
                msglist.Add("<span style='color:red'>密碼為必填(英數字元)</span>");
            else if (this.txbPassword.Text.Length < 8)
                msglist.Add("<span style='color:red'>密碼長度應為八到十八碼.</span>");

            else if (string.IsNullOrWhiteSpace(this.txbName.Text) || string.IsNullOrEmpty(this.txbName.Text))
                msglist.Add("<span style='color:red'>姓名為必填</span>");

            else if (string.IsNullOrWhiteSpace(this.txbEmail.Text) || string.IsNullOrEmpty(this.txbEmail.Text))
                msglist.Add("<span style='color:red'>信箱為必填</span>");

            else if (string.IsNullOrWhiteSpace(this.txbMobilePhone.Text) || string.IsNullOrEmpty(this.txbMobilePhone.Text))
                msglist.Add("<span style='color:red'>電話為必填</span>");
            else if (this.txbMobilePhone.Text.Length != 10)
                msglist.Add("<span style='color:red'>電話長度應為十碼.</span>");

            else if (string.IsNullOrWhiteSpace(this.txbId.Text) || string.IsNullOrEmpty(this.txbId.Text))
                msglist.Add("<span style='color:red'>身分字號為必填</span>");
            else if (this.txbId.Text.Length != 10)
                msglist.Add("<span style='color:red'>身分證長度應為十碼.</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}