using System;
using System.Collections.Generic;

#nullable disable

namespace ChinookApp.DataModel
{
    public partial class Employee1
    {
        public Employee1()
        {
            EmployeeDetails = new HashSet<EmployeeDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public int DeptId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
