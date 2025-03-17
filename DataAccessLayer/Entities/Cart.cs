using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Cart
    {
        public Guid CartID { get; set; }

        public Guid UserID { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}