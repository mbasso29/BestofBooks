using BestofBooks.Models;
using Microsoft.AspNetCore.Http;
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
        Task<bool> loginUser(string userName, string password, HttpContext context);
        Task updateUserRights(int BoBuser_id, string updateField, int newValue);
    }
}