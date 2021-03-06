﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W3D1_BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public string OriginalLanguage { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
