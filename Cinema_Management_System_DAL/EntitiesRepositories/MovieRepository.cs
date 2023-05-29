using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.EntitiesRepositories.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.EntitiesRepositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(SqlConnection connection, IDbTransaction transaction) : base(connection, transaction, "Movie")
        {
        }
    }
}
