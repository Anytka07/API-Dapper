using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RolesTypesEnum
    {
        None = 0,

        Director = 1,

        CleanerManager = 2,

        Controller = 3,

        BaseEmployee = 4,
    }
}
