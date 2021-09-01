using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;
using TakeAwalk.DBSource;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.SystemAdmin
{
    public partial class Tickets : System.Web.UI.Page
    {
        public UserInfoModel currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = AuthManager.GetCurrentUser();
            HttpCookie cookie = Request.Cookies.Get(".ASPXAUTH");  //以Cookies驗證是否已登入
            if (cookie == null)
            {
                Response.Redirect("/Login.aspx");
            }

            if (!this.IsPostBack)
            {
                this.gv_ticket.DataSource = TicketManager.GetTrainTicketsList();
                this.gv_ticket.DataBind();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] 
                { new DataColumn("TicketID"), new DataColumn("TicketContent_Confirm"), new DataColumn("TrainCompany_Confirm"), new DataColumn("TicketPrice_Confirm"), new DataColumn("Quantity_Confirm"), new DataColumn("Stocks_Confirm") });
            foreach (GridViewRow row in gv_ticket.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[7].FindControl("cbox") as CheckBox);
                    if (cbox.Checked)
                    {
                        string ticketid = row.Cells[0].Text;
                        string ticketcontent = row.Cells[1].Text;
                        string traincompany = row.Cells[2].Text;
                        string ticketprice = row.Cells[5].Text;
                        DropDownList q = row.Cells[6].FindControl("ddl_quantity") as DropDownList;
                        string quantity = q.SelectedValue;
                        string stocks = row.Cells[8].Text;

                        dt.Rows.Add(ticketid, ticketcontent, traincompany, ticketprice, quantity, stocks);
                    }
                }
            }
            if (dt.Rows.Count == 0)
            {
                this.lbError.Visible = true;
                this.btnConfirm.Visible = false;
                this.btnBuy.Visible = true;
                this.btnBuy.Enabled = false;
            }
            else
            {
                this.gv_ticket.Visible = false;
                this.gv_selected.Visible = true;
                this.gv_selected.DataSource = dt;
                this.gv_selected.DataBind();
                this.btnConfirm.Visible = false;
                this.btnBuy.Visible = true;
                this.btnBuy.Enabled = true;

                int dr_cnt = dt.Rows.Count;
                decimal total = 0;
                int ticket_cnt = 0;
                for (int i = 0; i < dr_cnt; i++)
                {
                    decimal amount = decimal.Parse(dt.Rows[i]["TicketPrice_Confirm"].ToString()) * decimal.Parse(dt.Rows[i]["Quantity_Confirm"].ToString());
                    total += amount;
                    int ticket = int.Parse(dt.Rows[i]["Quantity_Confirm"].ToString());
                    ticket_cnt += ticket;
                }
                this.lbAmount.Visible = true;
                this.lbAmount.Text = $"小計: {total} 元 \t\t {ticket_cnt} 張";

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnConfirm.Visible = true;
            this.btnBuy.Visible = false;
            this.gv_ticket.Visible = true;
            this.gv_selected.Visible = false;
            this.lbError.Visible = false;
            this.lbAmount.Visible = false;
            this.ltlMsg.Visible = false;
            this.gv_ticket.DataSource = TicketManager.GetTrainTicketsList();
            this.gv_ticket.DataBind();
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            this.gv_selected.Visible = true;
            string TicketFullName = "";
            var currentUser = AuthManager.GetCurrentUser();

            Order order = new Order()
            {
                CustomerID = currentUser.CustomerID,
                OrderStatus = 0,
                CreateDate = DateTime.Now,
                Creator = currentUser.CustomerID
            };
            TicketManager.CreateTicketOrders_OrdersTable(order);

            for (int i = 0; i < gv_selected.Rows.Count; i++)
            {
                TicketFullName += this.gv_selected.Rows[i].Cells[0].Text.Trim() + this.gv_selected.Rows[i].Cells[4].Text.Trim() + "張,";

                string ticketnametxt = this.gv_selected.Rows[i].Cells[1].Text.Trim();
                string ticketidtxt = this.gv_selected.Rows[i].Cells[0].Text;
                int ticketid = int.Parse(ticketidtxt);
                string quantitytxt = this.gv_selected.Rows[i].Cells[5].Text;
                int quantity = int.Parse(quantitytxt);

                if (TicketManager.UpdateStock(ticketid, quantity) == false)
                {
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = $"購票失敗，票券: {ticketnametxt} 存庫不足。請按取消後重新操作";
                    return;
                }


                TakeAwalk.ORM.DBModels.OrderDetail orderdetail = new TakeAwalk.ORM.DBModels.OrderDetail()
                {
                    OrderID = order.OrderID,
                    TicketID = ticketid,
                    Quantity = quantity,
                    CreateDate = order.CreateDate,
                    Creator = order.Creator
                };
                TicketManager.CreateTicketOrders_OrdersTable(order);
            };

            string subject = "TakeAwalk火車訂票系統-訂票完成通知信";
            string body = $"感謝您訂購本公司的{TicketFullName}祝您旅途平安.";
            string elb = currentUser.Email;
            UserInfoManager.SendAutomatedEmail(elb, body, subject);
            Response.Redirect("/SystemAdmin/OrderList.aspx");
        }
    }
}