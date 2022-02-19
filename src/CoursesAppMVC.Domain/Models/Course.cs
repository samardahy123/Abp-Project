using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace CoursesAppMVC.Models
{
    public class Course: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Guid InstructorId { get; set; }

    }
}
