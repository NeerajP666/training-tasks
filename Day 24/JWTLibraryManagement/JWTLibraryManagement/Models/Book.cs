using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.Models
{
    public class Book
    {
        public int BookId {  get; set; }
        [Required]
        public string BookName {  get; set; }
        [Required]
        public string Genre {  get; set; }
        public int AuthorId {  get; set; }
        public Author Author {  get; set; }
        public int? MemberId {  get; set; }
        public Member Member {  get; set; }
    }
}
