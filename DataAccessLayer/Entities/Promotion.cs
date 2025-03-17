using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Promotion
    {
        public Guid PromotionID { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PromotionValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal MinPriceToApply { get; set; }

        public bool Type { get; set; }

        public Guid StoreID { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }
    }
}