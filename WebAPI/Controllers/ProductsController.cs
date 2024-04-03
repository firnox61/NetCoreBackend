using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//nasıl istekte bulunacaklar
    [ApiController]//javadaki anotasyonlar gibi
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        //IProductService kim diyor
        //IOC container inversion of control bellekteki bir listenin içierisine new EfProductDal koyayım ve onu kim kullanmak isityorsa alsın
        public ProductsController(IProductService productService)//sen gevşek olarak IProductservcie bağlısın
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            Thread.Sleep(1000);
            //IProductService productService = new ProductManager(new EfProductDal());
            var result=_productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(string ProductName)
        {
            var result = _productService.Delete(ProductName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result=_productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
