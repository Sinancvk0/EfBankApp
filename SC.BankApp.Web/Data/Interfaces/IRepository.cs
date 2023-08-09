using System.Collections.Generic;
using System.Linq;

namespace SC.BankApp.Web.Data.Interfaces
{
    public interface IRepository<T> where T : class,new()
    {
        void Create (T entity);
        void Update (T entity);
        void Remove(T entity);

        List<T> GetAll();

        T GetById(object id);

        IQueryable<T> GetQueryable();



    }
}
