using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public Guid ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int StockQuantity { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public Guid StoreID { get; set; }
        public Guid CategoryID { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}