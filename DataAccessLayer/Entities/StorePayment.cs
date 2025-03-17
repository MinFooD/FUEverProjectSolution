using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class StorePayment
    {
        public Guid StorePaymentID { get; set; }

        public Guid StoreID { get; set; }

        [StringLength(20)]
        public string BankName { get; set; }

        [StringLength(20)]
        public string AccountNumber { get; set; }

        [StringLength(20)]
        public string AccountHolder { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }

        public virtual ICollection<PayoutManagement> Payouts { get; set; }
    }
}