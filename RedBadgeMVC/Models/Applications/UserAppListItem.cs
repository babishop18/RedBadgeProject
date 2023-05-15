using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.Applications
{
    public class UserAppListItem
    {
        public string JobTitle { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        public int AppId { get; set; }
        
    }
}