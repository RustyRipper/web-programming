using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace List9.Models
{
    public enum Category
    {
        Meat, Dairy, Seafiid, Pharmacy, Beverage, Bakery
    }
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

        [DataType(DataType.DateTime)]
        [Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public Category Category { get; set; }

        public Article()
        {
        }

        public Article(int id, string name, double price, DateTime expirationDate, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
            Category = category;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
