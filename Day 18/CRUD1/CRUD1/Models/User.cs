using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD1.Models
{
    [Table("crud1")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public int Age { get; set; }
        public string City { get; set; }


        [Required]
        public string Gender { get; set; }   

        public bool IsAgree { get; set; }


        public string Profession { get; set; }  
        public string AboutMe { get; set; }
    }
}