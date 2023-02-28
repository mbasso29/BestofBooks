using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using BestofBooks.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BestofBooks.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly IConfiguration _config;

        public UserRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<UserModel>> getUsers()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<UserModel> users = (await dbConnection.QueryAsync<UserModel>("GetUserList", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return users;
        }

        public async Task<List<UserModel>> getChangeHistory()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<UserModel> users = (await dbConnection.QueryAsync<UserModel>("GetChangeReport", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return users;
        }

        public async Task<UserModel> createUser(UserModel newUser)
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            object[] parameters = { new { user_last = newUser.user_last, user_first = newUser.user_first, user_email = newUser.user_email, username = newUser.username, password = newUser.password, user_type = newUser.user_type, adds_enabled = newUser.adds_enabled, edits_enabled = newUser.edits_enabled, deletes_enabled = newUser.deletes_enabled, is_admin = newUser.is_Admin, is_ViewOnly = newUser.is_ViewOnly } };
            await dbConnection.ExecuteAsync("CreateNewUser", param: parameters, commandType: CommandType.StoredProcedure);

            return newUser;
        }
    }

}

