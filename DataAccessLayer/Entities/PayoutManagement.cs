using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PayoutManagement
    {
        public Guid PayoutManagementID { get; set; }

        public Guid StorePaymentID { get; set; }

        public decimal Amount { get; set; }

        public decimal FeeDeducted { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("StorePaymentID")]
        public virtual StorePayment StorePayment { get; set; }
    }
}