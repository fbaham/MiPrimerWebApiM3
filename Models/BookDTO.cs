using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApiM3.Models
{
    public class BookDTO
    {
        public int Id {get; set;}
        [Required]
        public string Title {get; set;}
        [Required]
        public int AuthorId {get; set;}
    }
}