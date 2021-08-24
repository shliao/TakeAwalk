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
        public static List<OrderRecord> GetOrdersListbyCustomerID(Guid customerid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.OrderRecords
                                 where item.CustomerID == customerid
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
        public static List<OrderRecord> GetOrdersList_AdminOnly()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.OrderRecords
                                 join j in context.UserInfoes on item.CustomerID equals j.CustomerID
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
