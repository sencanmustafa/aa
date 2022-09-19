using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetALl();

        IDataResult<List<Product>> GetAllByCategory(int id);

        IDataResult<List<Product>> GetByUnitPrice(int min, int max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult add(Product product);
    }
}

