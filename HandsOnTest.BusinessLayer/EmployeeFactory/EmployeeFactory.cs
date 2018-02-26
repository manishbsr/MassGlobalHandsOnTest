using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DTOs;
using HandsOnTest.DTOs.Constants;
namespace HandsOnTest.BusinessLayer
{
	public class EmployeeFactory : IEmployeeFactory
	{
		public Employee CreateEmployee(string contractType)
		{
			if (contractType == EmployeeTypeContract.Hourly)
				return new HourlyEmployee();
			if (contractType == EmployeeTypeContract.Monthy)
				return new MonthlyEmployee();

			throw new Exception("contractType is not supported");
		}
	}
}
