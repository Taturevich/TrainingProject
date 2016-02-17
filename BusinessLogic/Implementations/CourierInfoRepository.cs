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
    public class CourierInfoRepository : ICourierInfoRepository
    {
        private List<CourierInfo> courierInfoList; 
        private string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data//CourierInfoNew.xml";
        private XmlSerializer writers = new XmlSerializer(typeof(List<CourierInfo>));

        public CourierInfoRepository()
        {
            XmlReader reader = new XmlTextReader(path);
            List<CourierInfo> infoFromXml = (List<CourierInfo>)writers.Deserialize(reader);
            reader.Close();
            this.courierInfoList = infoFromXml;
            //this.courierInfoList = new List<CourierInfo>();
        }

        public List<CourierInfo> GetCourierInfo()
        {
            return courierInfoList;
        }

        public CourierInfo GetCourierInfoByDateId(int id)
        {
            return courierInfoList.FirstOrDefault(x => x.DateId == id);
        }

        public void AddCourierInfo(CourierInfo courierInfo)
        {
            if (courierInfo!=null)
                courierInfoList.Add(courierInfo);
            SaveCourierInfo();
        }

        public void SaveCourierInfo()
        {
            TextWriter textWriter = new StreamWriter(path, false, Encoding.UTF8);
            writers.Serialize(textWriter, courierInfoList);
            textWriter.Close();
        }

        public void DeleteCourierInfo(CourierInfo courierInfo)
        {
            if (courierInfo != null)
                courierInfoList.Remove(courierInfo);
            SaveCourierInfo();
        }
    }
}
