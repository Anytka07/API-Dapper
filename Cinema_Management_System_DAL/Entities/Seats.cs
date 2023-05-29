using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Seats : BaseEntity
    {
        public Guid AuditoriumID { get; set; }  

        public int Row { get; set; }

        public int Number { get; set; }
    }
}
