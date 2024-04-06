using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidaton;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        
        public ProductManager(IProductDal productDal,ICategoryService categoryService)//başka bir dal eklleyuemeyiz
        {
            _productDal = productDal;
            _categoryService = categoryService;
        
        }

        //[LogAspect]//bu metodu logla AOP
        [SecuredOperation("product.add,admin")]// .aproductdd veya admin olmalı
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//oradaki tüm getleri siler
        public IResult Add(Product product)
        {
         IResult result= BusinessRules.Run(CheckIfCategoryProductCountOfCategoryCorrect(product.CategoryId)
             , NoEqualProductName(product.ProductName), CheckIfCategoryLimitExceded());
            if(result!=null)//kurala uymayan bir durum oluşmuşsa
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//oradaki tüm getleri siler
        public IResult Update(Product product)
        {
            if(product.ProductName==null)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
             _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);

        }

        public IResult Delete(string ProductName)
        {
            var result=_productDal.Get(p => p.ProductName== ProductName);
            if(result == null)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _productDal.Delete(result);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [CacheAspect]//key,vakue
        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour==12)
            {
                return  new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //iş kodları
            //yetkisi varmı
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }
        //SuccessDataResult
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }
        [CacheAspect]//key,vakue
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==ProductId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List< Product >>( _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails(),Messages.ProductAdded);
        }

        private IResult CheckIfCategoryProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 30)
            {
                return new ErrorResult(Messages.ProductCountCategoryIdLimit);
            }
            return new SuccessResult();
        }
        private IResult NoEqualProductName(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//any varmı demek ve bool döndürür
            if (result == true)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
          
            var result = _categoryService.GetAll();
            if(result.Data.Count > 15) 
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

      //  [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            if(product.UnitPrice<10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }

        public IDataResult<List<Product>> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
   
}
