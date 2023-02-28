using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BestofBooks.Models
{
    public class AdminModel
    {
        public List<SelectListItem> Users { get; set; }
        public UserModel user { get; set; }
        public UserModel newUser { get; set; }
    }
}
