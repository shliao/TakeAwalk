namespace TakeAwalk.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainTicket")]
    public partial class TrainTicket
    {
        public Guid TrainTicketID { get; set; }

        [Required]
        [StringLength(50)]
        public string TicketContent { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainCompany { get; set; }

        public DateTime ActivityStartDate { get; set; }

        public DateTime ActivityEndDate { get; set; }

        public decimal TicketPrice { get; set; }

        public int Inventory { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? DeleteDate { get; set; }
    }
}
