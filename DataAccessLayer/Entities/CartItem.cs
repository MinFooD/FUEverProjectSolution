using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CartItem
    {
        public Guid CartID { get; set; }
        public Guid ProductID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("CartID")]
        public virtual Cart Cart { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}