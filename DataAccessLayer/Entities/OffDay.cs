using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class OffDay
    {
        public Guid OffDayID { get; set; }

        public Guid StoreID { get; set; }

        public DateTime StartOffDate { get; set; }

        public DateTime EndOffDate { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }
    }
}