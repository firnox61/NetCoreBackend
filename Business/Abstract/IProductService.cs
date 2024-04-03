using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();//hem işlem sonuncu hem mesajı hemde döndüreceği şeyi içeren yapı görevi yapacağız
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//fiyat aralığında
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);
        IResult Delete(string ProductName);
        IResult Update(Product product);
        IDataResult<Product> GetById(int ProductId);
        IResult AddTransactionalTest(Product product);
        

        IDataResult<List<Product>> GetByCategoryId(int categoryId);
        //RESTFUL -->HTTP--> 
        //BİR KAYNAĞA ERİŞMEK İÇİN İZLEDİĞİMİZ YOL
    }
}
