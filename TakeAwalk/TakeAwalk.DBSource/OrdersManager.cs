using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.DBSource
{
    public class OrdersManager
    {
        public static List<Manager_OrderList_View> GetOrdersListbyCustomerID(Guid customerid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Manager_OrderList_View
                                 join order in context.Orders on item.OrderID equals order.OrderID
                                 where order.CustomerID == customerid
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static List<Manager_OrderList_View> GetOrdersList_AdminOnly()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query =(from item in context.Manager_OrderList_View
                                select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static List<TicketComfirm_View> GetOrderDetailsbyOrderID(Guid customerid, int orderid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.TicketComfirm_View
                                 join order in context.Orders on item.OrderID equals order.OrderID
                                 where order.CustomerID == customerid && order.OrderID == orderid
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static List<TicketComfirm_View> GetOrderDetailsbyOrderID_AdminOnly(int orderid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.TicketComfirm_View
                                 where item.OrderID == orderid
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
    }
    public class newTicketComfirm_View
    {
        public decimal Total { get; set; }
        public int TQuantity { get; set; }
        public int OrderID { get; set; }
        public DateTime CreateDate { get; set; }
        public int OrderStatus { get; set; }
    }
}
