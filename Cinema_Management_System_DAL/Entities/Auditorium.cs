using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Auditorium : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public int SeatsNo { get; set; }
    }
}
