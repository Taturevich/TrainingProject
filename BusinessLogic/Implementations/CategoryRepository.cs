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
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> categories = new List<Category>();
        private string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data//Categories.xml";
        private XmlSerializer writers = new XmlSerializer(typeof(List<Category>));

        public CategoryRepository()
        {
            XmlReader reader = new XmlTextReader(path);
            List<Category> infoFromXml = (List<Category>)writers.Deserialize(reader);
            reader.Close();
            this.categories = infoFromXml;
        }
        public List<Category> GetCategories()
        {
            return categories;
        }

        public void AddCategory(Category category)
        {
            if (category!=null)
                categories.Add(category);
            SaveCategory();
        }

        public void SaveCategory()
        {
            TextWriter textWriter = new StreamWriter(path, false, Encoding.UTF8);
            writers.Serialize(textWriter, categories);
            textWriter.Close();
        }

        public void DeleteCategory(Category category)
        {
            if (category != null)
                categories.Remove(category);
            SaveCategory();
        }

    }
}
