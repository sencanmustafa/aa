using System;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorhwindContext context = new NorhwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorhwindContext context = new NorhwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>>? filter)
        {
            using (NorhwindContext context = new NorhwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetALl(Expression<Func<Product, bool>>? filter = null)
        {
            using (NorhwindContext context = new NorhwindContext())
            {
                //eger filtre null ise 1.kisim calisir , null degil ise 2, kisim calisir
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorhwindContext context = new NorhwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

