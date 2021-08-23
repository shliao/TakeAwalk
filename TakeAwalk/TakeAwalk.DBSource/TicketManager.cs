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
        public static List<TrainTicket> GetTrainTicketsList_Default()
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
    }
}
