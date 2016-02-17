using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class EfDateRepository : IDateRepository
    {
        private EfDataBaseContext context;

        public EfDateRepository(EfDataBaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Date> GetDates()
        {
            return context.Dates;
        }

        public Date GetDateById(int id)
        {
            return context.Dates.FirstOrDefault(x => x.Id == id);
        }

        public void AddDate(Date date)
        {
            context.Dates.Add(date);
            context.SaveChanges();
        }

        public void SaveDate(Date date)
        {
            if (date.Id == 0)
                context.Dates.Add(date);
            else
                context.Entry(date).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDate(Date date)
        {
            context.Dates.Remove(date);
            context.SaveChanges();
        }
    }
}
