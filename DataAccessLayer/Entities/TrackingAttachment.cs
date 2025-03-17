using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class TrackingAttachment
    {
        public Guid TrackingAttachmentID { get; set; }

        public Guid TrackingID { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        public bool Type { get; set; }

        [ForeignKey("TrackingID")]
        public virtual StepsTracking StepsTracking { get; set; }
    }
}