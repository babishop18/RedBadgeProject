using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RedBadgeMVC.Data.Entities
{
    public class CompanyEntity : UserEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual List<JobEntity> Jobs {get;set;} = new List<JobEntity>();
        
    }
}