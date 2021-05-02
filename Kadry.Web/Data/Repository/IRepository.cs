using Kadry.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kadry.Web.Data.Repository
{
    public interface IRepository<T> where T : MyEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        IList<T> Filter(Func<T, bool> predicate);
        int Save();
        DbSet<T> Table { get; set; }
        void InsertRange(IEnumerable<T> obj);
        IQueryable<T> GetQuerableTable();
    }
}
