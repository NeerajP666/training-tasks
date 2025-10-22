using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.Models
{
    public class Author
    {
        public int AuthorId {  get; set; }
        [Required]
        public string AuthorName {  get; set; }
        public ICollection<Book> Books {  get; set; }= new List<Book>();
    }
}
