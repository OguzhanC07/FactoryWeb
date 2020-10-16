using FactoryWebAPI.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T : class, ITable, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
