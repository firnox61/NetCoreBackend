using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic kısıt
    //class: referans tip demek
    
    public interface IEntityRepository<T> where T : class,IEntity,new()
        //IEntity T ya IEntity yada ondan imlement edilmiş clasları içerenilsin
        //new() newlenebilir olmalı yani soyut da olamaz
    {
        //filtre uyapma işlemi için kullannıyoruz
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //expression ile mesela categoriye veya ürünün diyatına göre getir diye ayrı ayrı metotlar yazmamıza gerek olmaz
        T Get(Expression<Func<T, bool>> filter);
        //tek get ile tek getircez
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       // List<T> GetAllByCategory(int categoryId); buna ihtiyacımız yok
    }
}
