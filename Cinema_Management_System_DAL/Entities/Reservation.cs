﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Reservation : BaseEntity
    {
        public Guid EmployeeID { get; set; }

        public Guid ScreeningID { get; set; }

        public Guid ReservationTypeID { get; set; }

        public bool Reserved { get; set; }

        public bool Paid { get; set; }
    }
}
