using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;
using BusinessLogic.Interfaces;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class CategoriesInfoRepository : ICategoriesInfoRepository
    {
        private List<CategoryInfo> categoriesInfolList;
        private string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data//CategoriesInfo.xml";
        private XmlSerializer writers = new XmlSerializer(typeof(List<CategoryInfo>));
        public CategoriesInfoRepository()
        {
            XmlReader reader = new XmlTextReader(path);
            List<CategoryInfo> infoFromXml = (List<CategoryInfo>)writers.Deserialize(reader);
            reader.Close();
            this.categoriesInfolList = infoFromXml;
        }

        public List<CategoryInfo> GetCategoriesInfo()
        {
            return categoriesInfolList;
        }

        public CategoryInfo GetCategoryInfoByDateId(int id)
        {
            return categoriesInfolList.FirstOrDefault(x => x.Date.Id == id);
        }

        public CategoryInfo GetCategoryInfoByPlayName(string name)
        {
            return categoriesInfolList.FirstOrDefault(x => x.Play.Name == name);
        }

        public void AddCategoryInfo(CategoryInfo categoryInfo)
        {
            if (categoryInfo!=null)
                categoriesInfolList.Add(categoryInfo);
            SaveCategoryInfo();
        }

        public void SaveCategoryInfo()
        {
            TextWriter textWriter = new StreamWriter(path, false, Encoding.UTF8);
            writers.Serialize(textWriter, categoriesInfolList);
            textWriter.Close();
        }

        public void DeleteCategoryInfo(CategoryInfo categoryInfo)
        {
            if (categoryInfo != null)
                categoriesInfolList.Remove(categoryInfo);
            SaveCategoryInfo();
        }
    }
}
