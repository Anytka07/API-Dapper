using Dapper_Data_Access_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Roles : BaseEntity
    {
        public RolesTypesEnum RoleTitle { get; set; }
    }
}
