using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.DTOs
{
    public abstract class Employee
    {
		public int? Id { get; set; }
		public string Name { get; set; }
		public int? RoleId { get; set; }
		public string RoleName { get; set; }
		public string RoleDescription { get; set; }
		public double ?Salary { get; set; }
		public virtual double AnnualSalary { get; set; }

	}
}
