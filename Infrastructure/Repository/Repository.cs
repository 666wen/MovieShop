using ApplicationCore.Contract.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        //to talk to database, when initiate the Repository need to passing in a db-context
        protected readonly MovieShopDbContext _dbContext;
        public Repository(MovieShopDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetById(int id)  //make it virtual, can be override 
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
