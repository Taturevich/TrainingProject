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
    public class EfGenresRepository : IGenresRepository 
    {
        private EfDataBaseContext context;

        public EfGenresRepository(EfDataBaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return context.Genres;
        }

        public Genre GetGenreById(int id)
        {
            return context.Genres.FirstOrDefault(x => x.Id == id);
        }

        public Genre GetGenreByName(string name)
        {
            return context.Genres.FirstOrDefault(x => x.Name == name);
        }

        public void AddGenre(Genre genre)
        {
            context.Genres.Add(genre);
            context.SaveChanges();
        }

        public void SaveGenre(Genre genre)
        {
            if (genre.Id == 0)
                context.Genres.Add(genre);
            else
                context.Entry(genre).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteGenre(Genre genre)
        {
            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }
}
