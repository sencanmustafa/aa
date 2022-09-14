using System;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorhwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorhwindContext context = new NorhwindContext())
            {
                var result = from p in context.Products join c in context.Categories on p.CategoryId equals c.CategoryId select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName , CategoryName=c.CategoryName};
                return result.ToList();
            }
        }
    }
}

