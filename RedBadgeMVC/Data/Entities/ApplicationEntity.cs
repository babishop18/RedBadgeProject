using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data.Entities
{
    public class ApplicationEntity
    {
        [Key]
        public int Id { get; set; }
    }
}