using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data.Entities
{
    public class ApplicantEntity : UserEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual List<ApplicationEntity> MyApplications {get;set;} = new List<ApplicationEntity>();
        public virtual List<ResponseEntity> Responses {get;set;} = new List<ResponseEntity>();
    }
}