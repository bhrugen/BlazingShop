using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            Category obj = new Category();
            return _db.Categories.FirstOrDefault(u => u.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category objCategory)
        {
            _db.Categories.Add(objCategory);
            _db.SaveChanges();
            return true;
        }
        public bool UpdateCategory(Category objCategory)
        {
            var ExistingCategory = _db.Categories.FirstOrDefault(u => u.Id == objCategory.Id);
            if(ExistingCategory != null)
            {
                ExistingCategory.Name = objCategory.Name;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteCategory(Category objCategory)
        {
            var ExistingCategory = _db.Categories.FirstOrDefault(u => u.Id == objCategory.Id);
            if (ExistingCategory != null)
            {
                _db.Categories.Remove(ExistingCategory);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}
