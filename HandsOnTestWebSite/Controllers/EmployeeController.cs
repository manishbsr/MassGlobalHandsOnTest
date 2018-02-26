using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandsOnTest.DTOs;
using HandsOnTest.BusinessLayer;
namespace HandsOnTestWebSite.Controllers
{
    public class EmployeeController : ApiController
    {
		private readonly IEmployeeManagement employeeManagement;
		public EmployeeController(IEmployeeManagement employeeManagement)
		{
			

		
			this.employeeManagement = employeeManagement;
		}
		public IList<Employee> GetEmployees(int id)
		{
			return employeeManagement.GetEmployees(id);
		}
		public IList<Employee> GetEmployees()
		{
			return employeeManagement.GetEmployees(null);
		}
	}
}
