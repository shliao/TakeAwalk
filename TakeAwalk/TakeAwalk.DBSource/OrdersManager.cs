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
        //public static List<Order> GetOrdersListbyCustomerID(Guid customerid)
        //{
        //    using (ContextModel context = new ContextModel())
        //    {
        //        try
        //        {
        //            var query = (from o in context.Orders
        //                         where o.CustomerID == customerid
        //                         select o);

        //            var list = query.ToList();
        //            return list;
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.WriteLog(ex);
        //            return null;
        //        }
        //    }
        //}
        public static List<JoinOrdersTable> GetOrdersListbyCustomerID(Guid customerid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    //TrainTicket t = new TrainTicket();
                    //OrderDetail od = new OrderDetail();

                    var query = (from od in context.OrderDetails
                                 join t in context.TrainTickets
                                 on od.TicketID equals t.TicketID
                                 join o in context.Orders
                                 on od.OrderID equals o.OrderID
                                 where o.CustomerID == customerid
                                 select new JoinOrdersTable
                                 {
                                     OrderID = o.OrderID,
                                     CreateDate = o.CreateDate,
                                     Total = od.Quantity * t.Price,
                                     TotalQuantity = (od.Quantity),
                                     OrderStatus = o.OrderStatus
                                 });

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

    public class JoinOrdersTable
    {
        internal object ordergroups;

        public int OrderID { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Total { get; set; }
        public int TotalQuantity { get; set; }
        public int OrderStatus { get; set; }
    }
}
