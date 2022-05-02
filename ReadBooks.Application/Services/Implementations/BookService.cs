using ReadBooks.Application.InputModels;
using ReadBooks.Application.Services.Interfaces;
using ReadBooks.Application.ViewModels;
using ReadBooks.Core.Entities;
using ReadBooks.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ReadBooksDbContext _dbContext;
        public BookService(ReadBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewBookInputModel inputModel)
        {
            var book = new Book(inputModel.Title, inputModel.Description, inputModel.Author, inputModel.Publisher, inputModel.IdBookOwner, inputModel.TotalPages);
            
            _dbContext.Books.Add(book);

            return book.Id;
        }

        public void CreateNote(NewNoteInputModel inputModel)
        {
            var note = new BookNote(inputModel.Content, inputModel.IdBook, inputModel.IdUser);

            _dbContext.Notes.Add(note);
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            
            book.Cancel();
        }

        public void Finish(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            book.Finish();
        }

        public List<BookViewModel> GetAll(string query)
        {
            var books = _dbContext.Books;

            var booksViewModel = books.Select(b => new BookViewModel(b.Id, b.Title, b.CreatedAt)).ToList();

            return booksViewModel;
        }

        public BookDetailsViewModel GetById(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            var bookDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Description,
                book.TotalPages,
                book.StartedAt,
                book.FinishedAt
                );

            return bookDetailsViewModel;
        }

        public void Start(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            book.Start();
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == inputModel.Id);

            book.Update(inputModel.Title, inputModel.Description, inputModel.TotalPages);
        }
    }
}
