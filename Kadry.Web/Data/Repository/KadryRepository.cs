using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Kadry.Db;
using Kadry.Web.Data.Context;
using System.Linq.Expressions;

namespace Kadry.Web.Data.Repository
{
    public static class EntityFrameworkExtensions
    {
        public static IList<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
        where T : class
        {
            return EntityFrameworkQueryableExtensions.Include(source, path).ToList();
        }
    }
    public class KadryRepository<T> : IRepository<T> where T : MyEntity
    {
        private readonly DbContext _context;
        private readonly AppUser _user = default;
        //private readonly AppUser _user = default;
        public DbSet<T> Table { get; set; }

        public IQueryable<T> GetQuerableTable()
        {
            return Table.AsQueryable<T>();
        }

        public KadryRepository(KadryDbContext context)
        {
            this._context = context;
            //this._userId = userId;
            Table = _context.Set<T>();
        }
        public void Delete(int id)
        {
            var dbObjectCurrnetRowguid = GetById(id);
            if (dbObjectCurrnetRowguid == null)
            {
                throw new ArgumentException(string.Format("Object {0} with id={1} doesn't exists in Database. Operation Canceled.", typeof(T).ToString(), id));
            }
            T existing = Table.Find(id);
            Table.Remove(existing);
        }

        public IList<T> Filter(Func<T, bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList<T>();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public void Insert(T obj)
        {
            obj.CreatedBy = _user;
            obj.CreatedOn = DateTime.Now;
            Table.Add(obj);
        }
        public void InsertRange(IEnumerable<T> obj)
        {
            foreach (var t in obj)
            {
                t.CreatedBy = _user;
                t.CreatedOn = DateTime.Now;
            }
            Table.AddRange(obj);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }



        public void Update(T obj)
        {
            var dbObjectCurrnetRowguid = GetById(obj.Id);
            if (obj.ObjectGuid != dbObjectCurrnetRowguid.ObjectGuid)
            {
                throw new DataMisalignedException("Data in Database has changes since you last time received it. Reload data to make sure what data you are updating. Operation Canceled.");
            }
            Table.Attach(obj);

            obj.ChangedOn = DateTime.Now;
            obj.ChengedBy = _user;
            _context.Entry(obj).State = EntityState.Modified;
        }

    
    }
}
