using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
//SOLID
public class Program
{
    private static void Main(string[] args)
    {
        //ProductManager productManager=new ProductManager(new InMemoryProductDal());
        //CategoryTest();
        //ProductTest();

       // ProductDelete();
    }

    private static void ProductDelete()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
        var result = new Product { ProductId = 80 };
       // productManager.Delete(result);
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll().Data)
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
        var result = productManager.GetProductDetails();
        if(result.Success == true) 
        {
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine("PName={0}  \t    CName={1}", product.ProductName, product.CategoryName);
            }
            Console.WriteLine(result.Message);
        }
        else
        {
            Console.WriteLine(result.Message);
        }

        
    }
}