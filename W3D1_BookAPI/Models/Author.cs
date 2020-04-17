﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W3D1_BookAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; }
    }
}