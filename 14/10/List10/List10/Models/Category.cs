using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace List10.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "To short name")]
        [MaxLength(50, ErrorMessage = "To long name, do not exceed {0}")]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }

        public Category()
        {
            Articles = new List<Article>();
        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Articles = new List<Article>();
        }
    }
}
