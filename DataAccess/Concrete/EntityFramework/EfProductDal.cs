using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{//ben bir IProduct Dal ım ve bende senin metotların var ben onları EfEntityRepositoryBase içerisinden alıyorum
    //EfEntityRepositoryBase<Product,NorthwindContext> entityframework
    //IProductDal saklamamızın sebebi producta özgü şeylerin kullanılması için busines işi gibi
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             { ProductId = p.ProductId, ProductName = p.ProductName
                             , CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
                       
            }
        }
    }
}
