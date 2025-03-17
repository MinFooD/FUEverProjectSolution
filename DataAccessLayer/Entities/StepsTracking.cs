using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class StepsTracking
    {
        public Guid StepsTrackingID { get; set; }

        public Guid StepID { get; set; }
        public Guid EmployeeID { get; set; }
        public Guid BookingID { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime Time { get; set; }

        [ForeignKey("StepID")]
        public virtual Step Step { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual ApplicationUser Employee { get; set; }

        [ForeignKey("BookingID")]
        public virtual Booking Booking { get; set; }

        public virtual ICollection<TrackingAttachment> TrackingAttachments { get; set; }
    }
}