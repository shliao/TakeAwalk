﻿using System;
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
        public static void CreateTicketOrders_OrdersTable(Order orders)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.Orders.Add(orders);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void CreateTicketOrders_OrderDetailsTable(Order orders)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.Orders.Add(orders);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static bool ReturnStock(int ticketid, int quantity)
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
        public static bool UpdateStock(int ticketid, int quantity)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.TrainTickets.Where(o => o.TicketID == ticketid).FirstOrDefault();

                    if (obj != null && (obj.Stocks >= quantity))
                    {
                        obj.Stocks -= quantity;

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
        public static void DeleteTicketOrders(int orderid)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.Orders.Where(o => o.OrderID == orderid).FirstOrDefault();
                    var obj2 = context.OrderDetails.Where(o => o.OrderID == orderid);

                    foreach (var item in obj2)
                    {
                        context.OrderDetails.Remove(item);
                    }

                    if (obj != null)
                    {
                        context.Orders.Remove(obj);
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
