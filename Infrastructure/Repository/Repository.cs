using ApplicationCore.Contract.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity); //Set<> is DbSet<> is virsal Table
            await _dbContext.SaveChangesAsync(); //save the database. commit the transaction.
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            // get all the records from the table
            // we can use this method for getting all the list of genres
            return await _dbContext.Set<T>().ToListAsync(); //set()??
        }

        public virtual Task<T> GetById(int id)  //make it virtual, can be override 
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
