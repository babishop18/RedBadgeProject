using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBProject.Models.Application
{
    public class AppDetail
    {
        public int AppId { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string DesiredPay { get; set; }
        public bool HasResponse { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
    }
}