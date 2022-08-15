﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T as Category class for now.
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
    }
}