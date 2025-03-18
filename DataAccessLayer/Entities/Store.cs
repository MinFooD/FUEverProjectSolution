using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Store
    {
        public Guid StoreID { get; set; }

        [StringLength(50)]
        public string StoreName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(10)]
        public string HotLine { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Policy { get; set; }

        [StringLength(100)]
        public string BusinessLicience { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid OwnerID { get; set; }

        [ForeignKey("OwnerID")]
        public virtual ApplicationUser Owner { get; set; }
		public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<RegularDay> RegularDays { get; set; }
        public virtual ICollection<OffDay> OffDays { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}