using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace CoursesAppMVC.Models
{
    public class Student: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int Age  { get; set; }
        public string Address { get; set; }
        public Guid CourseId { get; set; }

    }
}
