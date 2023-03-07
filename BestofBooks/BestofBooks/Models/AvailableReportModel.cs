using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BestofBooks.Models
{
    public class AvailableReportModel
    {
        public List<BookModel> listBooks { get; set; }
        public BookModel bookFilters { get; set; }
        public List<SelectListItem> bookAuthors { get; set; }
        public List<SelectListItem> bookGenres { get; set; }
    }
}
