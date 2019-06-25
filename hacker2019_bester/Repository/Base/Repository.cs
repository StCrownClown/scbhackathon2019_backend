using hacker2019_bester.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hacker2019_bester.Repository
{
    public class Repository : IRepository
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public void Save<T>() where T : class => _context.SaveChanges();

        public int Count<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public T Create<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }


        public List<T> CreateAll<T>(List<T> entity) where T : class
        {
            _context.AddRange(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteAll<T>(List<T> entity) where T : class
        {
            _context.RemoveRange(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public T FindOneByUnique<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }
        
        public void Load<T>() where T : class
        {
            _context.Set<T>().Load<T>();
        }

        public T Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public void UpdateRange<T>(List<T> entity) where T : class
        {
            _context.UpdateRange(entity);
            _context.SaveChanges();
        }

        public List<T> UpdateAll<T>(List<T> entity) where T : class
        {
            _context.UpdateRange(entity);
            _context.SaveChanges();
            return entity;
        }

        public void NoTracking<T>() where T : class
        {
            _context.Set<T>().AsNoTracking();
        }
    }
}
