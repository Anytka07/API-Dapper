using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.EntitiesRepositories.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {

    }
}
