using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IBaseOperation<T> where T : class
    {
        Task<int> Add(T item);
        Task<bool> Add(List<T> items);
        Task<bool> Update(T item, params Expression<Func<T, object>>[] updateProperties);
        Task<bool> Update(List<T> items, params Expression<Func<T, object>>[] updateProperties);
        Task<bool> Remove(T item);
        Task<T> Get(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> expression = null);





        //Task AddAsync(T item);
        //void Update(T item);
        //Task RemoveAsync(T item);
        //T GetById(int id);
        //Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression = null);
    }
}