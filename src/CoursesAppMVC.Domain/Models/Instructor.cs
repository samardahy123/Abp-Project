using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace CoursesAppMVC.Models
{
    public class Instructor: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string ShortBio { get; set; }
    }
}
