using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBProject.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
         public string? Username{get;set;}
        [Required]
        public string? Password{get;set;}
    }
}