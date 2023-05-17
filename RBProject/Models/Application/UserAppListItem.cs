using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBProject.Models.Application
{
    public class UserAppListItem
    {
        public string JobTitle { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        public int AppId { get; set; }
    }
}