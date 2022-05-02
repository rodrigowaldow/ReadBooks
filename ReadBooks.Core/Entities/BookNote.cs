using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Core.Entities
{
    public class BookNote
    {
        public BookNote(string content, int idBook, int idUser)
        {
            Content = content;
            IdBook = idBook;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
