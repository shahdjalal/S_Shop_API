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


    public class CategoryRepo : GenericRepository<Category> , ICategoryRepo
    {

        private readonly ApplicationDbContext dbContext;

        public CategoryRepo(ApplicationDbContext context) :base(context)
        {
         
        }

       

      

    
      
        

      

    }
}
