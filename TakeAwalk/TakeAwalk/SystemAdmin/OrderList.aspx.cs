using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeAwalk.Auth;
using TakeAwalk.DBSource;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.SystemAdmin
{
    public partial class OrderList : System.Web.UI.Page
    {
        public UserInfoModel currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = AuthManager.GetCurrentUser();

            if (!IsPostBack)
            {
                this.gv_orderlist.DataSource = OrdersManager.GetOrdersListbyCustomerID(currentUser.CustomerID);
                this.gv_orderlist.DataBind();
            }

            if (currentUser.UserLevel == 0)
            {
                string guidtxt = this.Request.QueryString["CustomerID"];
                this.gv_orderlist.DataSource = OrdersManager.GetOrdersListbyCustomerID(currentUser.CustomerID);
                this.gv_orderlist.DataBind();

                if (guidtxt != null)
                {
                    Guid customerid = Guid.Parse(guidtxt);
                    this.gv_orderlist.DataSource = OrdersManager.GetOrdersListbyCustomerID(customerid);
                    this.gv_orderlist.DataBind();
                }
            }

            // 取得訂單資料
            var list = OrdersManager.GetOrdersListbyCustomerID(currentUser.CustomerID);

            if (list.Count > 0)  // 檢查有無資料
            {
                var pagedList = this.GetPagedDataTable(list);

                this.gv_orderlist.DataSource = pagedList;
                this.gv_orderlist.DataBind();

                this.ucPager.TotalSize = list.Count;
                this.ucPager.Bind();
            }
            else
            {
                this.gv_orderlist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;
            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private List<Manager_OrderList_View> GetPagedDataTable(List<Manager_OrderList_View> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }
    }
}