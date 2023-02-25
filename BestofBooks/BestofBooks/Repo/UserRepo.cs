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
    }

}

