using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContex> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContex :DbContext, new()
    {
        public void Add(TEntity entity)
        {//C# özel bir yapı bir clası newlwdiğimizde bellekdten atmak için using bitince
            using (TContex context = new TContex())
            {
                var addedEntity = context.Entry(entity);//referansı yakala
                addedEntity.State = EntityState.Added;//o eklenecek bir nesne
                context.SaveChanges();//gerçekleştir
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContex context = new TContex())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala
                deletedEntity.State = EntityState.Deleted;//o silinecek bir nesne
                context.SaveChanges();//gerçekleştir
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContex context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContex context = new TContex())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
                //filtre null ise Product listesini döndür
                //değilse filtreleyip ver
            }
        }

        public void Update(TEntity entity)
        {
            using (TContex context = new TContex())
            {
                var updatedEntity = context.Entry(entity);//referansı yakala
                updatedEntity.State = EntityState.Modified;//o güncellenecek bir nesne
                context.SaveChanges();//gerçekleştir
            }
        }
    }
}
