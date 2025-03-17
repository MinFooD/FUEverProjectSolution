using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Notification
    {
        public Guid NotificationID { get; set; }

        [StringLength(200)]
        public string NotificationText { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<NotificationToUser> NotificationToUsers { get; set; }
    }
}