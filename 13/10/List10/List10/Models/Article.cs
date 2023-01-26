using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace List10.Models
{
    public class Article
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "To short name")]
        [MaxLength(50, ErrorMessage = "To long name, do not exceed {0}")]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public double Price { get; set; }
        [NotMapped]
        [DisplayName("Photo")]
        public IFormFile FormFile { get; set; } = null;
        public string? FilePath { get; set; } = null;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } 

        public Article()
        {

        }
        public Article(int id, string name, double price, IFormFile formFile, int categoryId, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            FormFile = formFile;
            CategoryId = categoryId;
            Category = category;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
