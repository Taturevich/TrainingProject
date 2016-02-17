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
    public class EfAuthorsRepository : IAuthorsRepository
    {
        private EfDataBaseContext context;

        public EfAuthorsRepository(EfDataBaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors;
        }

        public Author GetAuthorById(int id)
        {
            return context.Authors.FirstOrDefault(x => x.Id == id);
        }

        public Author GetAuthorByName(string name)
        {
            return context.Authors.FirstOrDefault(x => x.Name == name);
        }

        public void AddAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void SaveAuthor(Author author)
        {
            if (author.Id == 0)
                context.Authors.Add(author);
            else
                context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }
    }
}
