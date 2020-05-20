using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public class AuthorsService : IAuthorsService
    {

        public AuthorsService()
        {

        }

        public IList<Author> SearchAuthors(string searchTerm)
        {
            return new List<Author>
            {
                new Author { Id = 1, FirstName = "Ian", LastName = "Wallace" },
                new Author { Id = 2, FirstName = "Irving", LastName = "Wallace" }
            };
        }
    }
}
