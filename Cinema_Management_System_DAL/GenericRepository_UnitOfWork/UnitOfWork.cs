using Dapper_Data_Access_Layer.EntitiesRepositories;
using Dapper_Data_Access_Layer.EntitiesRepositories.Interfaces;
using Dapper_Data_Access_Layer.GenericRepository_UnitOfWork.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.GenericRepository_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbTransaction _transaction;

        private readonly SqlConnection _connection;

        private readonly ILogger<IUnitOfWork> _logger;

        public IMovieRepository MovieRepository { get; set; }

        public UnitOfWork(IDbTransaction transaction, SqlConnection connection, ILogger<IUnitOfWork> logger)
        {
            _transaction = transaction;

            _connection = connection;

            _logger = logger;

            MovieRepository = new MovieRepository(_connection, _transaction);
        }

        public void Dispose() => _transaction.Dispose();

        public async void Complete()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception exception)
            {
                _transaction.Rollback(); 

                _logger.LogError($"Something went wrong in Unit of Work Pattern! {exception.Message}");
            }
        }
    }
}
