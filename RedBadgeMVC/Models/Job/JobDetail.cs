using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.Job
{
    public class JobDetail
    {
        public string JobTitle { get; set; }
        public int JobId { get; set; }
        public int? JobSalary { get; set; }
        public int? JobHourlyPay { get; set; }
        public string JobLocation { get; set; }
        public string JobSummary { get; set; }
    }
}