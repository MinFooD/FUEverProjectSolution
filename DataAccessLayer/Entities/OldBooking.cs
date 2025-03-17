using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class OldBooking
    {
        public Guid OldBookingID { get; set; }

        public Guid PetID { get; set; }
        public Guid StoreID { get; set; }
        public Guid ServiceID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal FinalPrice { get; set; }

        [StringLength(100)]
        public string OrderRequest { get; set; }

        [ForeignKey("PetID")]
        public virtual Pet Pet { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { get; set; }
    }
}