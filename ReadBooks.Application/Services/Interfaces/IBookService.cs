using ReadBooks.Application.InputModels;
using ReadBooks.Application.ViewModels;
using System.Collections.Generic;

namespace ReadBooks.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll(string query);
        BookDetailsViewModel GetById(int id);

        int Create(NewBookInputModel inputModel);
        void Update(UpdateBookInputModel inputModel);
        void CreateNote(NewNoteInputModel inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
    }
}
