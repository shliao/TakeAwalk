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
                                 orderby item.Inventory descending
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
