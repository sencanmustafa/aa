﻿using System;
using System.Linq.Expressions;


namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        List<T> GetALl(Expression<Func<T,bool>>? filter =null);
        T Get(Expression<Func<T, bool>>? filter);
        
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

