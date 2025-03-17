using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class FeedbackReply
    {
        public Guid FeedbackReplyID { get; set; }

        public Guid FeedbackID { get; set; }
        public Guid ReplierID { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("FeedbackID")]
        public virtual Feedback Feedback { get; set; }

        [ForeignKey("ReplierID")]
        public virtual ApplicationUser Replier { get; set; }
    }
}