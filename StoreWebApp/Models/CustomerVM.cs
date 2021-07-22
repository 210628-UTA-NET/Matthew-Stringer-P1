using StoreClasslib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        { }

        public CustomerVM(Customer p_cust)
        {
            Id = p_cust.Id;
            Name = p_cust.Name;
            Address = p_cust.Address;
            Email = p_cust.Email;
        }

        public int Id { set; get; }

        [Required]
        public string Name { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        public string Email { set; get; }
    }
}
