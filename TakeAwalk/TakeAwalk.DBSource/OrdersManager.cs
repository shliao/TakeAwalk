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
        public static List<OrderList_View> GetOrdersListbyCustomerID(Guid customerid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query =(from item in context.OrderList_View
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
}
