using System;
using System.ComponentModel.DataAnnotations;
using MiPrimerWebApiM3.Helpers;

namespace MiPrimerWebApiM3.Models
{
    public class AuthorCreateDTO
    {
        [Required]
        [FirstLetterUppercase]
        public string Name {get; set;}
        public DateTime BirthDate {get; set;}
    }
}