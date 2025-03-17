using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class OldChatMessage
    {
        public Guid OldChatMessageID { get; set; }

        public Guid FromUserID { get; set; }
        public Guid ToUserID { get; set; }
        public Guid BookingID { get; set; }

        [StringLength(200)]
        public string ChatText { get; set; }

        [StringLength(100)]
        public string AttachmentUrl { get; set; }

        public DateTime Time { get; set; }

        public bool Status { get; set; }

        [ForeignKey("FromUserID")]
        public virtual ApplicationUser FromUser { get; set; }

        [ForeignKey("ToUserID")]
        public virtual ApplicationUser ToUser { get; set; }

        [ForeignKey("BookingID")]
        public virtual Booking Booking { get; set; }
    }
}