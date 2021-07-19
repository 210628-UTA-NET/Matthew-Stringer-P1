using StoreClasslib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class ProductVM
    {
        public ProductVM ()
        { }

        public ProductVM (Product p_prod)
        {
            Id = p_prod.Id;
            Name = p_prod.Name;
            Price = p_prod.Price;
            Description = p_prod.Description;
            Category = p_prod.Category;
        }

        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public decimal Price { set; get; }

        [Required]
        public string Description { set; get; }

        [Required]
        public string Category { set; get; }

    }
}
