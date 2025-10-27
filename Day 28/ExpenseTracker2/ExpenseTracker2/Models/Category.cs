using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker2.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
