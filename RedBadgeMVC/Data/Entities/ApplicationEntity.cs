using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data.Entities
{
    public class ApplicationEntity
    {
        [Key]
        public int AppId { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string DesiredPay { get; set; }
        public bool HasResponse { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantFKey { get; set; }
        public virtual ApplicantEntity Applicant { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
         public virtual JobEntity Job { get; set; }
        public virtual ResponseEntity Response{ get; set; }
}
}