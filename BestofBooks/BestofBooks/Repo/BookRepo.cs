using BestofBooks.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace BestofBooks.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly IConfiguration _config;

        public BookRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<BookModel>> GetInventoryList()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<BookModel> books = (await dbConnection.QueryAsync<BookModel>("GetInventoryList", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return books;
        }
    }
}
