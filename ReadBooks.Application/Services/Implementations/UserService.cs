using ReadBooks.Application.InputModels;
using ReadBooks.Application.Services.Interfaces;
using ReadBooks.Application.ViewModels;
using ReadBooks.Core.Entities;
using ReadBooks.Infrastructure.Persistence;
using System;
using System.Linq;

namespace ReadBooks.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ReadBooksDbContext _dbContext;
        public UserService(ReadBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if(user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
