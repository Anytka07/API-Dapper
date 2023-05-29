using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class HasRoles : BaseEntity
    {
        public Guid EmployeeID { get; set; }

        public Guid RolesID { get; set; }
    }
}
