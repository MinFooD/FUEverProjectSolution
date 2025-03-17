using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Feedback
    {
        public Guid FeedbackID { get; set; }

        public Guid? BookingID { get; set; }
        public Guid? OrderID { get; set; }

        public bool Type { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Rating { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("BookingID")]
        public virtual Booking Booking { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        public virtual ICollection<FeedbackReply> FeedbackReplies { get; set; }
    }
}