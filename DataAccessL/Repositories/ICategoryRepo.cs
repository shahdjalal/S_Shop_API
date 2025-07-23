using Shahd_DataAccessL.Models;

namespace Shahd_DataAccessL.Repositories
{
    public interface ICategoryRepo
    {
        int Add(Category category);
        IEnumerable<Category> GetAll(bool withTracking = false);
        Category? GetById(int id);
        int Remove(Category category);
        int Update(Category category);
    }
}