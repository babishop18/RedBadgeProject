using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.Applications
{
    public class AppCreate
    {
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string DesiredPay { get; set; }
    }
}