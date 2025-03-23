﻿using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class SalesDataManager : ISaleDataOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(SalesData item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(SalesData item)
        {
            throw new NotImplementedException();
        }

        public int InsertSaleData(SalesData item)
        {
            try
            {
                db.SalesDatas.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public SalesData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesData> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesData item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(SalesData item)
        {
            throw new NotImplementedException();
        }

        public void Update(SalesData item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SalesData item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SalesData> Where(Expression<Func<SalesData, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesData>> WhereAsync(Expression<Func<SalesData, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
