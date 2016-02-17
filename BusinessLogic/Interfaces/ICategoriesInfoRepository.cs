using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICategoriesInfoRepository
    {
        List<CategoryInfo> GetCategoriesInfo();
        CategoryInfo GetCategoryInfoByDateId(int id);
        CategoryInfo GetCategoryInfoByPlayName(string name);
        void AddCategoryInfo(CategoryInfo categoryInfo);
        void SaveCategoryInfo();
        void DeleteCategoryInfo(CategoryInfo categoryInfo);
    }
}
