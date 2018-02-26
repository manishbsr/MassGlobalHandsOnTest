using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DTOs;
namespace HandsOnTest.BusinessLayer
{
	public interface IEmployeeManagement
	{
		/// <summary>
		/// Return te list of employees. if employee id is passed as null, it will return all the employees
		/// </summary>
		/// <param name="employeeId"></param>
		/// <returns></returns>
		List<Employee> GetEmployees(int? employeeId);
	}
}
