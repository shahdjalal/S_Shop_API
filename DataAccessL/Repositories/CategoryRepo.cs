using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories
{


    public class CategoryRepo : ICategoryRepo
    {

        private readonly ApplicationDbContext dbContext;

        public CategoryRepo(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public int Add(Category category)
        {
            dbContext.Categoties.Add(category);
            return dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll(bool withTracking = false)
        {
            if(withTracking)
            return dbContext.Categoties.ToList();

            return dbContext.Categoties.AsNoTracking().ToList();
        }

        // goes to function لما يكمون عندي بس ريترن
        public Category? GetById(int id) => dbContext.Categoties.Find(id);
        

        public int Remove(Category category)
        {
            dbContext.Categoties.Remove(category);

            return dbContext.SaveChanges();
        }

        public int Update(Category category)
        {
            dbContext.Categoties.Update(category);
            return dbContext.SaveChanges();
        }
    }
}
