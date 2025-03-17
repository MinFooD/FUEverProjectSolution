using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Transaction
    {
        public Guid TransactionID { get; set; }
        public Guid? BookingID { get; set; }
        public Guid? OrderID { get; set; }
        public Guid PetOwnerID { get; set; }
        public Guid StoreID { get; set; }

        public decimal Amount { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public bool Type { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("BookingID")]
        public virtual Booking Booking { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("PetOwnerID")]
        public virtual ApplicationUser PetOwner { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }
    }
}