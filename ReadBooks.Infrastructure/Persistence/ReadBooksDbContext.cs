using ReadBooks.Core.Entities;
using System;
using System.Collections.Generic;

namespace ReadBooks.Infrastructure.Persistence
{
    public class ReadBooksDbContext
    {
        public ReadBooksDbContext()
        {
            Books = new List<Book>
            {
                new Book("Biblia NAA", "Biblia versão NAA", "Almeida","SBB", 1, 600),
                new Book("Biblia NVT", "Biblia versão NVT", "","Mundo Cristão", 1, 600),
                new Book("Biblia NVI", "Biblia versão NVI", "","SBB", 1, 600)
            };

            Users = new List<User>
            {
                new User("Rodrigo Waldow", "waldowrodrigo@gmail.com", new DateTime(1984,8,5)),
                new User("Diego Waldow", "diegowaldow@gmail.com", new DateTime(1985,8,5)),
                new User("Carlos Waldow", "carloswaldow@gmail.com", new DateTime(1956,3,1)),
            };
        }
        public List<Book> Books { get; private set; }
        public List<User> Users { get; private set; }
        public List<BookNote> Notes { get; private set; }
    }
}
