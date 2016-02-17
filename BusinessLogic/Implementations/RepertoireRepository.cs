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
    public class RepertoireRepository : IRepertoireRepository
    {
        private List<TheaterRepertoire> repertoiresList;
        private string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data//Repert.xml";
        private XmlSerializer writers = new XmlSerializer(typeof(List<TheaterRepertoire>));
        public RepertoireRepository()
        {
            XmlReader reader = new XmlTextReader(path);
            List<TheaterRepertoire> filereprt = (List<TheaterRepertoire>)writers.Deserialize(reader);
            reader.Close();
            this.repertoiresList = filereprt;
        }

        public List<TheaterRepertoire> GetRepertoires()
        {
            return repertoiresList;
        }

        public TheaterRepertoire GetRepertoireByPlayName(string name)
        {
            return repertoiresList.FirstOrDefault(x => x.Author.Name == name);
        }

        public TheaterRepertoire GetRepertoireByAuthorName(string name)
        {
            return repertoiresList.FirstOrDefault(x => x.Play.Name == name);
        }

        public void AddRepertoire(TheaterRepertoire author)
        {
            if(author!=null)
                repertoiresList.Add(author);
            SaveRepertoire();
        }

        public void SaveRepertoire()
        {
            TextWriter textWriter = new StreamWriter(path, false, Encoding.UTF8);
            writers.Serialize(textWriter, repertoiresList);
            textWriter.Close();
        }

        public void DeleteRepertoire(TheaterRepertoire author)
        {
            if (author != null)
                repertoiresList.Remove(author);
            SaveRepertoire();
        }
    }
}
