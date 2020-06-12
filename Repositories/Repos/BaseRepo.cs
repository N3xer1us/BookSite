using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
   public class BaseRepo<T> 
        where T : BaseEntity
    {

        internal BookSiteDBContext db;
        internal DbSet<T> Items;

        public BaseRepo(BookSiteDBContext db)
        {
            this.db = db;
            this.Items = db.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            IQueryable<T> query = Items;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public T GetById(int Id)
        {
            return Items.Where(u => u.Id == Id).FirstOrDefault();
        }

        public void Insert(T item)
        {
            Items.Add(item);
        }

        public void Update(T item)
        {
            Items.Attach(item);
            DbEntityEntry entry = db.Entry(item);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T item = Items.Find(id);
            Delete(item);
        }


        public virtual void Delete(T entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                Items.Attach(entityToDelete);
            }
            Items.Remove(entityToDelete);
        }

    }
}
