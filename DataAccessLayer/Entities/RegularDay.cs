using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class RegularDay
    {
        public Guid RegularDayID { get; set; }

        public Guid StoreID { get; set; }

        [StringLength(10)]
        public string DayOfWeek { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }
    }
}