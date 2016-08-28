using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplication1.Models
{
    

    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

       
    }

    public class LibraryManagement : DbContext
    {
        public LibraryManagement()
            : base() { }

        public DbSet<Users> Users { get; set; }
    }

}