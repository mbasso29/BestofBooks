using BestofBooks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public interface IBookRepo
    {
        Task<List<BookModel>> GetAllBooks();
    }
}