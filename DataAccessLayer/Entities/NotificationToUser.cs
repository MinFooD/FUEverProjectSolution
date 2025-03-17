using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class NotificationToUser
    {
        public Guid UserID { get; set; }
        public Guid NotificationID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("NotificationID")]
        public virtual Notification Notification { get; set; }
    }
}