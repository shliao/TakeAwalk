using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;
using TakeAwalk.DBSource;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.SystemAdmin
{
    public partial class Manager_ChangeTicket : System.Web.UI.Page
    {
        public TrainTicket trainTicket;
        public UserInfoModel currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = AuthManager.GetCurrentUser();
            if (currentUser.UserLevel != 0)
            {
                Response.Redirect("/Login.aspx");
            }
            string ticketidtxt = this.Request.QueryString["ID"];
            int ticketid = int.Parse(ticketidtxt);

            trainTicket = TicketManager.GetTrainTicketsDetailbyID_AdminOnly(ticketid);

            if (!IsPostBack)
            {
                this.Name_tbx.Text = trainTicket.TicketName;
                this.Company_tbx.Text = trainTicket.TrainCompany;
                this.Start_tbx.Text = trainTicket.ActivityStartDate.ToString("yyyy-MM-dd");
                this.End_tbx.Text = trainTicket.ActivityEndDate.ToString("yyyy-MM-dd");
                this.Price_tbx.Text = trainTicket.Price.ToString();
                this.Stocks_tbx.Text = trainTicket.Stocks.ToString();
                this.Enabled_ddl.SelectedValue = trainTicket.IsEnabled.ToString();

                //this.Creator_ltl.Text = trainTicket.Creator.ToString();
                this.CreateDate_ltl.Text = trainTicket.CreateDate.ToString("yyyy-MM-dd");

                if (trainTicket.Modifier.HasValue)
                {
                    //this.Modifier_ltl.Text = trainTicket.Modifier.ToString();
                }
                else
                    this.Modifier_ltl.Text = string.Empty;

                if (trainTicket.ModifyDate.HasValue)
                {
                    this.ModifyDate_ltl.Text = trainTicket.ModifyDate.Value.ToString();
                }
                else
                    this.ModifyDate_ltl.Text = string.Empty;
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/Manager_TicketList.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltlMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");
            if (!rx.IsMatch(Name_tbx.Text))
            {
                this.ltlMsg.Text = "<span style='color:red'>票券名稱不能為特殊字元,請重新輸入</span>";
                return;
            }
            if (!rx.IsMatch(Company_tbx.Text))
            {
                this.ltlMsg.Text = "<span style='color:red'>主辦單位不能為特殊字元,請重新輸入</span>";
                return;
            }

            currentUser = AuthManager.GetCurrentUser();
            var customerid = currentUser.CustomerID;
            string ticketidtxt = this.Request.QueryString["ID"];
            int ticketid = int.Parse(ticketidtxt);

            DateTime start_d = DateTime.Parse(this.Start_tbx.Text);
            DateTime end_d = DateTime.Parse(this.End_tbx.Text);
            int price = int.Parse(this.Price_tbx.Text);
            int stocks = int.Parse(this.Stocks_tbx.Text);

            if (price < 0)
            {
                this.ltlMsg.Text = "<span style='color:red'>定價不能為0元,請重新輸入</span>";
                return;
            }
            if (stocks < 0)
            {
                this.ltlMsg.Text = "<span style='color:red'>庫存不能為0,請重新輸入</span>";
                return;
            }

            int enable_value = int.Parse(this.Enabled_ddl.SelectedValue);
            bool enablestatus;
            if (enable_value == 0)
            {
                enablestatus = true;
            }
            else
                enablestatus = false;

            TrainTicket trainticket = new TrainTicket()
            {
                TicketName = this.Name_tbx.Text,
                TrainCompany = this.Company_tbx.Text,
                ActivityStartDate = start_d,
                ActivityEndDate = end_d,
                Price = price,
                Stocks = stocks,
                Modifier = customerid,
                ModifyDate = DateTime.Now,
                IsEnabled = enablestatus
                
            };

            TicketManager.UpdateTickets(ticketid, trainticket);
            Response.Redirect("/SystemAdmin/Manager_TicketList.aspx");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();

            if (string.IsNullOrWhiteSpace(this.Name_tbx.Text) || string.IsNullOrEmpty(this.Name_tbx.Text))
                msglist.Add("<span style='color:red'>票券名稱為必填</span>");
            else if (string.IsNullOrWhiteSpace(this.Company_tbx.Text) || string.IsNullOrEmpty(this.Company_tbx.Text))
                msglist.Add("<span style='color:red'>主辦單位為必填</span>");
            else if (string.IsNullOrWhiteSpace(this.Start_tbx.Text) || string.IsNullOrEmpty(this.Start_tbx.Text))
                msglist.Add("<span style='color:red'>活動開始日期為必填</span>");
            else if (string.IsNullOrWhiteSpace(this.End_tbx.Text) || string.IsNullOrEmpty(this.End_tbx.Text))
                msglist.Add("<span style='color:red'>活動結束日期為必填</span>");
            else if (string.IsNullOrWhiteSpace(this.Price_tbx.Text) || string.IsNullOrEmpty(this.Price_tbx.Text))
                msglist.Add("<span style='color:red'>定價為必填</span>");
            else if (string.IsNullOrWhiteSpace(this.Stocks_tbx.Text) || string.IsNullOrEmpty(this.Stocks_tbx.Text))
                msglist.Add("<span style='color:red'>庫存為必填</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }

    }
}