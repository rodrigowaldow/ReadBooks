using ReadBooks.Application.InputModels;
using ReadBooks.Application.ViewModels;

namespace ReadBooks.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        int Create(NewUserInputModel inputModel);
    }
}
