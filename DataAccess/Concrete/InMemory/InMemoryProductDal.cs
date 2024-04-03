using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //metotların dışıunda bir method böyle isimlendir
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=12, UnitsInStock=5},
                new Product{ProductId=2, CategoryId=2, ProductName="Klavye", UnitPrice=152, UnitsInStock=51},
                new Product{ProductId=3, CategoryId=1, ProductName="Telefon", UnitPrice=22, UnitsInStock=25},
                new Product{ProductId=4, CategoryId=1, ProductName="Laptop", UnitPrice=19, UnitsInStock=35}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
          /*  Product productToDelete = null;

            foreach (Product p in _products) {
            if(product.ProductId == p.ProductId)
                {
                    productDelete = p;
                }
            }
            _products.Remove(productToDelete);*/

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//single yalnız id aramalrda kullanılır
            _products.Remove(productToDelete);
            
        }

        public List<Product> GetAll()
        {
            return _products;
        }


        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();//yeni bir list haline getirip döndürür
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
