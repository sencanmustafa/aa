using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
         
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetALl() 
        {
            return new DataResult<List<Product>>(_productDal.GetALl(), true, "product returned");
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new DataResult<List<Product>>(_productDal.GetALl(p => p.CategoryId == id),true,"Product");
        }

        public List<Product> GetByUnitPrice(int min, int max)
        {
            return _productDal.GetALl(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}

