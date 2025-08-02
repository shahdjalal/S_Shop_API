using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Classes
{
  public  class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public int Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChanges(); 
        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return dbContext.Set<T>().ToList();

            return dbContext.Set<T>().AsNoTracking().ToList();
        }

        // goes to function لما يكمون عندي بس ريترن
        public T? GetById(int id) => dbContext.Set<T>().Find(id);

        public int Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);

            return dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
