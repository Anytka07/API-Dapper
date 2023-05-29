using Dapper_Data_Access_Layer.EntitiesRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.GenericRepository_UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public void Complete();

        public IMovieRepository MovieRepository { get; }    
    }
}
