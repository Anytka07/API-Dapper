using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Screening : BaseEntity
    {
        public Guid MovieID { get; set; }

        public Guid AuditoriumID { get; set; }

        public DateTime ScreeningStart { get; set; }
    }
}
