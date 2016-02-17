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
    public class EfPlaysRepository : IPlaysRepository 
    {
        private EfDataBaseContext context;

        public EfPlaysRepository(EfDataBaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Play> GetPlays()
        {
            return context.Plays;
        }

        public Play GetPlayById(int id)
        {
            return context.Plays.FirstOrDefault(x => x.Id == id);
        }

        public Play GetPlayByAuthorId(int id)
        {
            return context.Plays.FirstOrDefault(x => x.AuthorId == id);
        }

        public Play GetPlayByGenreId(int id)
        {
            return context.Plays.FirstOrDefault(x => x.GenreId == id);
        }

        public Play GetPlayByName(string name)
        {
            return context.Plays.FirstOrDefault(x => x.Name == name);
        }

        public void AddPlay(Play play)
        {
            context.Plays.Add(play);
            context.SaveChanges();
        }

        public void SavePlay(Play play)
        {
            if (play.Id == 0)
                context.Plays.Add(play);
            else
                context.Entry(play).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePlay(Play play)
        {
            context.Plays.Remove(play);
            context.SaveChanges();
        }
    }
}
