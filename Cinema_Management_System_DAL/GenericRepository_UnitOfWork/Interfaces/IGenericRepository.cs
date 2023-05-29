using Dapper_Data_Access_Layer.Entities;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllEntityAsync();
        
        Task<TEntity> GetEntityByIdAsync(Guid ID);

        Task<IEnumerable<TEntity>> InsertEntityAsync(TEntity entity);
        
        Task<IEnumerable<TEntity>> UpdateEntityAsync(TEntity entity);

        Task<IEnumerable<TEntity>> DeleteEntityByIdAsync (Guid ID);
    }
}
