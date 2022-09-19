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
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetALl(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetALl(p => p.CategoryId == id),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(int min, int max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetALl(p => p.UnitPrice <= max && p.UnitPrice >= min), Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        
    }
}

