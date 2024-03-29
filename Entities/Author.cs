using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MiPrimerWebApiM3.Helpers;

namespace MiPrimerWebApiM3.Entities
{
    public class Author
    {
        public int Id {get; set;}
        [Required]
        [FirstLetterUppercase]
        public string Name {get; set;}
        public string Identification {get; set;}
        public DateTime BirthDate {get; set;}
        public List<Book> Books {get; set;}
    }
}