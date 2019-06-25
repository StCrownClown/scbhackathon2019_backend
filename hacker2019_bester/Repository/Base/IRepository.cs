using System;
using System.Collections.Generic;

namespace hacker2019_bester.Repository
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : class;

        IEnumerable<T> Find<T>(Func<T, bool> predicate) where T : class;

        T FindOneByUnique<T>(Func<T, bool> predicate) where T : class;

        T Create<T>(T entity) where T : class;

        List<T> CreateAll<T>(List<T> entity) where T : class;

        T Update<T>(T entity) where T : class;

        void UpdateRange<T>(List<T> entity) where T : class;

        List<T> UpdateAll<T>(List<T> entity) where T : class;

        void Load<T>() where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteAll<T>(List<T> entity) where T : class;

        int Count<T>(Func<T, bool> predicate) where T : class;

        void Save<T>() where T : class;

        void NoTracking<T>() where T : class;
    }
}
