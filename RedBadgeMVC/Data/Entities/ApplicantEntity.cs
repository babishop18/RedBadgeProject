using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data.Entities
{
    public class ApplicantEntity : UserEntity
    {
        public string ApplicantName { get; set; }
        public int ApplicantAge { get; set; }
        public virtual List<ApplicationEntity> UserApps {get;set;} = new List<ApplicationEntity>();

    }
}