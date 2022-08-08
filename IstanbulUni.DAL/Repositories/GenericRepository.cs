using IstanbulUni.DAL.Abstract;
using IstanbulUni.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        IstanbulUniContext db = new IstanbulUniContext();
        DbSet<T> obj;
        public GenericRepository()
        {
            obj=db.Set<T>();
        }
        public void Delete(T d)
        {
            var deleteEntity = db.Entry(d);
            deleteEntity.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public T get(Expression<Func<T, bool>> filter)
        {
           return obj.SingleOrDefault(filter);
        }

        public List<T> GetAll()
        {

            return obj.ToList();
        }

        public IQueryable<T> GetAllAsQueryble()
        {
            return obj.AsQueryable<T>();
        }

        public void Insert(T d)
        {
            
            var insertEntity = db.Entry(d);
            insertEntity.State = EntityState.Added;
            db.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filiter)
        {
            return obj.Where(filiter).ToList();
        }

        public void Update(T d)
        {
            var updateEntity = db.Entry(d);
            updateEntity.State = EntityState.Modified;
            db.SaveChanges();
        }

      
    }
}
