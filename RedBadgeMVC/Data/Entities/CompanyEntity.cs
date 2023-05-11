using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RedBadgeMVC.Data.Entities
{
    public class CompanyEntity : UserEntity
    {
        public string CompanyName { get; set; }
        public string CompanyCategory { get; set; }
        public string CompanyDescription { get; set; }
        public virtual List<JobEntity> Jobs {get;set;} = new List<JobEntity>();
        
    }
}