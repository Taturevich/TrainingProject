using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICourierInfoRepository
    {
        List<CourierInfo> GetCourierInfo();
        CourierInfo GetCourierInfoByDateId(int id);
        void AddCourierInfo(CourierInfo courierInfo);
        void SaveCourierInfo();
        void DeleteCourierInfo(CourierInfo courierInfo);
    }
}
