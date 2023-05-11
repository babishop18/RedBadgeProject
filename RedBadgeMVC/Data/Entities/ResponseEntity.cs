using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data.Entities
{
    public class ResponseEntity
    {
        [Key]
        public int ResponseId { get; set; }
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string ResponseMessage { get; set; }
        [ForeignKey("Application")]
        public int AppFKey { get; set; }

    }
}