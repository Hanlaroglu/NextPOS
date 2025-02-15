using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IBaseOperation<T> where T : class
    {
        bool Add(T item);
        Task AddAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        void Remove(T item);
        Task RemoveAsync(T item);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression = null);
    }
}