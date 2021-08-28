using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.DBSource;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.SystemAdmin
{
    public partial class Tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gv_ticket.DataSource = TicketManager.GetTrainTicketsList();
                this.gv_ticket.DataBind();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("TicketContent_Confirm"), new DataColumn("TrainCompany_Confirm"), new DataColumn("TicketPrice_Confirm"), new DataColumn("Quantity_Confirm") });
            foreach (GridViewRow row in gv_ticket.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[6].FindControl("cbox") as CheckBox);
                    if (cbox.Checked)
                    {
                        string ticketcontent = row.Cells[0].Text;
                        string traincompany = row.Cells[1].Text;
                        string ticketprice = row.Cells[4].Text;
                        DropDownList q = row.Cells[5].FindControl("ddl_quantity") as DropDownList;
                        string quantity = q.SelectedValue;

                        dt.Rows.Add(ticketcontent, traincompany, ticketprice, quantity);
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
            this.gv_ticket.DataSource = TicketManager.GetTrainTicketsList();
            this.gv_ticket.DataBind();
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            //this.gv_selected.Visible = true;
            //string ticketName = "";
            //for (int i = 0; i < gv_selected.Rows.Count; i++)
            //{
            //    ticketName += this.gv_selected.Rows[i].Cells[0].Text.Trim() + this.gv_selected.Rows[i].Cells[4].Text.Trim() + "張,";
            //};
            //string subject = "TakeAwalk火車訂票系統-訂票完成通知信";
            //string body = $"感謝您訂購本公司的{ticketName}祝您旅途平安.";
            //string elb = Session["Email"] as string;
            //UserInfoManager.SendAutomatedEmail(elb, body, subject);
            //Response.Redirect("/SystemAdmin/OrderList.aspx");
        }
    }
}