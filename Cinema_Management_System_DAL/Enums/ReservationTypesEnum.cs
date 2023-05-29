using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReservationTypesEnum
    {
        None = 0,

        Mobile = 1,

        Email = 2, 

        Offline = 3,
    }
}
