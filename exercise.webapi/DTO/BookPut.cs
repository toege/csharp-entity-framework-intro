﻿using exercise.webapi.Models;

namespace exercise.webapi.DTO
{
    public class BookPut
    {
        public string? Title { get; set; }
        public int? AuthorId { get; set; }
    }
}
