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
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public Int32? IsActive { get; set; }
        public Int32? IsLocked { get; set; }
        public Int32? IsVerified { get; set; }
        public string SecurityToken { get; set; }
      //  [NotMapped]
        public DateTime? LastLoginDateTime { get; set; }
        public Int32? InvalidAttempts { get; set; }
        public DateTime? CreatedDateTime { get; set; }




    }

    public class UserManagement : DbContext
    {
        public UserManagement(): base() { }

       public DbSet<Users> Users { get; set; }
    }

}