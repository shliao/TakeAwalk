using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.DBSource
{
    public class TicketManager
    {
        public static List<TrainTicket> GetTrainTicketsList()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.TrainTickets
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
        public static List<TrainTicket> GetTrainTicketsList_OrderByInventory()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.TrainTickets
                                 orderby item.Stocks descending
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
        public static void CreateTicketOrders(OrderDetail order)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {

                    context.OrderDetails.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);

            }

        }
        public static bool UpdateStock(int ticketid, int quantity)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.TrainTickets.Where(o => o.TicketID == ticketid).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.Stocks += quantity;

                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        public static void DeleteTicketOrdersByOrderID_TicketID(int id, int ticketid)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.OrderDetails.Where(o => o.OrderID == id && o.TicketID == ticketid).FirstOrDefault();

                    if (obj != null)
                    {
                        context.OrderDetails.Remove(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
    }
}
