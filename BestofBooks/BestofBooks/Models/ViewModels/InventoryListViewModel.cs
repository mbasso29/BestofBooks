﻿using System.Collections.Generic;

namespace BestofBooks.Models.ViewModels
{
    public class InventoryListViewModel : BaseViewModel
    {
        public List<BookModel> invListBooks { get; set; }
    }
}