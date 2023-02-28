using BestofBooks.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public interface IUserRepo
    {
        Task<UserModel> createUser(UserModel newUser);
        Task<List<UserModel>> getChangeHistory();
        Task<List<UserModel>> getUsers();
    }
}