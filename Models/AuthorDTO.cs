using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MiPrimerWebApiM3.Helpers;

namespace MiPrimerWebApiM3.Models
{
    public class AuthorDTO
    {
        public int Id {get; set;}
        [Required]
        [FirstLetterUppercase]
        public string Name {get; set;}
        public DateTime BirthDate {get; set;}
        public List<BookDTO> Books {get; set;}
    }
}