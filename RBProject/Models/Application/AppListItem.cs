using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBProject.Models.Application
{
    public class AppListItem
    {
        public string FullName { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        public bool HasResponse { get; set; }
        public int PhoneNumber { get; set; }
        public int AppId { get; set; }
    }
}