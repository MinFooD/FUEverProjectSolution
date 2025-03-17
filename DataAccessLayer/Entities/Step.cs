using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Step
    {
        public Guid StepID { get; set; }

        [StringLength(50)]
        public string StepName { get; set; }

        public int StepNumber { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public Guid ServiceID { get; set; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { get; set; }

        public virtual ICollection<StepsTracking> StepsTrackings { get; set; }
    }
}