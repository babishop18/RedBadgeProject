using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBProject.Data.Entities
{
    public class ResponseEntity
    {
        [Key]
        public int ResponseId { get; set; }
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string ResponseMessage { get; set; }
        public DateTimeOffset DateResponded { get; set; }
        [ForeignKey("Application")]
        public int AppFKey { get; set; }
    }
}