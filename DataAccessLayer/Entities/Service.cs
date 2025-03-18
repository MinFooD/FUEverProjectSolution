using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Service
    {
        public Guid ServiceID { get; set; }

        [StringLength(50)]
        public string ServiceName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Type { get; set; }

        public TimeSpan? Duration { get; set; }

        public TimeSpan? MinDuration { get; set; }

        public Guid StoreID { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}