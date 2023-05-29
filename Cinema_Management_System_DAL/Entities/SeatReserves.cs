using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class SeatReserves : BaseEntity
    {
        public Guid SeatID { get; set; }

        public Guid ScreeningID { get; set; }

        public Guid ReservationID { get; set; }
    }
}
