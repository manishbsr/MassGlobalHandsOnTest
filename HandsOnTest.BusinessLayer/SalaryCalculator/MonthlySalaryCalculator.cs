using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.BusinessLayer
{
	public class MonthlySalaryCalculator : ISalaryCalculator
	{
		public double GetAnnualSalary(double? salary)
		{
			if(salary.HasValue)
			{
				return salary.Value * 12;
			}
			return 0;
		}
	}
	
}
