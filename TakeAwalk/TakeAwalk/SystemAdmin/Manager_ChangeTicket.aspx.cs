using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.DBSource;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.SystemAdmin
{
    public partial class Manager_ChangeTicket : System.Web.UI.Page
    {
        public TrainTicket trainTicket;
        protected void Page_Load(object sender, EventArgs e)
        {
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

                //this.Creator_ltl.Text = trainTicket.Creator.ToString();
                this.CreateDate_ltl.Text = trainTicket.CreateDate.ToString("yyyy-MM-dd");
                //this.Modifier_ltl.Text = trainTicket.Modifier.ToString();
                //this.ModifyDate_ltl.Text = trainTicket.ModifyDate.ToString("yyyy/MM/dd");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/Manager_TicketList.aspx");
        }
        private bool CheckInput()
        {
            List<string> msglist = new List<string>();

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
    }
}