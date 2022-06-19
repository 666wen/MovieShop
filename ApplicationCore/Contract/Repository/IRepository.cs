using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repository
{
    public interface IRepository<T> where T : class  //only takes different entity obj
    {
        //common methods that other repository interface need inherite
        //interface methods default : public abstruct
        T GetById(int id); //return type T entity

        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);





    }
}
