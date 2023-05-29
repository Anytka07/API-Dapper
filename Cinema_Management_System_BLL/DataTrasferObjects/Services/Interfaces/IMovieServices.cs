using Dapper_Example_Bussines_Logic.DataTrasferObjects.RequestResultDTO;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Response_Result_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Dapper_Example_Bussines_Logic.DataTrasferObjects.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<IEnumerable<GetMovieDTO>> GetAllEntityAsync();

        Task<GetMovieDTO> GetEntityByIdAsync(Guid ID);

        Task<IEnumerable<GetMovieDTO>> InsertEntityAsync(InsertMovieDTO entity);

        Task<IEnumerable<GetMovieDTO>> UpdateEntityAsync(UpdateMovieDTO entity);

        Task<IEnumerable<GetMovieDTO>> DeleteEntityByIdAsync(Guid ID);
    }
}
