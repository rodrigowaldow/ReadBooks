﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, DateTime createdAt)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}