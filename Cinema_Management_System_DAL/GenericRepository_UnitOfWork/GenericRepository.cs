using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using Dapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {
        protected readonly SqlConnection _connection;

        protected readonly IDbTransaction _transaction;

        protected readonly string _table;

        public GenericRepository(SqlConnection connection, IDbTransaction transaction, string table)
        {
            _connection = connection;

            _transaction = transaction;

            _table = table;
        }

        public async Task<IEnumerable<TEntity>> GetAllEntityAsync()
        {
            string response = $"Select * From {_table}";

            return await _connection.QueryAsync<TEntity>(response, transaction: _transaction);
        }

        public async Task<TEntity> GetEntityByIdAsync(Guid ID)
        {
            string response = $"Select * From {_table} Where ID = @ID";
            
            var result =
                await _connection.QuerySingleOrDefaultAsync<TEntity>(response, param: 
                new { ID = ID }, 
                transaction: _transaction);

            if (result is null)
            {
                throw new Exception($"Entity with ID {ID} could not be found!");
            }

            return result;
        }

        public async Task<IEnumerable<TEntity>> InsertEntityAsync(TEntity entity)
        {
            entity.CreatedDateTime = DateTime.Now;

            string response = this.GenerateInsertQuery();

            await _connection.ExecuteAsync(response, param: entity, transaction: _transaction);

            _transaction.Commit();

            return await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);
        }

        public async Task<IEnumerable<TEntity>> UpdateEntityAsync(TEntity entity)
        {
            entity.CreatedDateTime = DateTime.Now;

            entity.UpdatedDateTime = DateTime.Now;

            try
            {
                string response = this.GenerateUpdateQuery();

                await _connection.ExecuteAsync(response, param: entity, transaction: _transaction);

                _transaction.Commit();
            }
            catch (Exception exceptions)
            {
                throw new Exception($"Something went wrong in {this.UpdateEntityAsync(entity).GetType().Name} method! {exceptions.Message}");
            }

            return await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);
        }

        public async Task<IEnumerable<TEntity>> DeleteEntityByIdAsync(Guid ID)
        {
            string response = $"Delete from {_table} where ID = @ID";

            await _connection.ExecuteAsync(response, new { ID = ID }, transaction: _transaction);

            _transaction.Commit();

            return await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();

        private static List<string> ListProperties(IEnumerable<PropertyInfo> list_Properties)
        {
            return (from property in list_Properties let attributes = 
                property.GetCustomAttributes(typeof(DescriptionAttribute), false) where attributes.Length <= 0 ||
                (attributes[0] as DescriptionAttribute)?.Description != "ingore" select property.Name).ToList();
        }

        private string GenerateInsertQuery()
        {
            var builder = new StringBuilder($"Insert into {_table}");
            builder.Append(" (");

            var properties = ListProperties(GetProperties);
            properties.ForEach(property => { builder.Append($"[{property}],");});

            builder.Remove(builder.Length - 1, 1).Append(") Values (");

            properties.ForEach(property => { builder.Append($"@{property},");});

            builder.Remove(builder.Length - 1, 1).Append(")");

            return builder.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var builder = new StringBuilder($"Update {_table} set ");
            var properties = ListProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    builder.Append($"{property} = @{property},");
                }
            });

            builder.Remove(builder.Length - 1, 1).Append(" Where Id = @Id");

            return builder.ToString();
        }
    }
}
