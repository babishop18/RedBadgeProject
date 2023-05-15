using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.Response
{
    public class ResponseDetail
    {
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string ResponseMessage { get; set; }
        public int ResponseId { get; set; }
    }
}