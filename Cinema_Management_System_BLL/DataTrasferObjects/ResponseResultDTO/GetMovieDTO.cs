using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.DataTrasferObjects.Response_Result_DTO
{
    public class GetMovieDTO
    {
        public Guid ID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Duration { get; set; }

        public string? Director { get; set; }

        public string? Cast { get; set; }
    }
}
