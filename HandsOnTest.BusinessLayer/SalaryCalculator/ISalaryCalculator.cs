using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.BusinessLayer
{
	/// <summary>
	/// Interface for Calculation of the annual salary
	/// </summary>
    public interface ISalaryCalculator
    {
		/// <summary>
		/// Get the annual salary
		/// </summary>
		/// <param name="salary"></param>
		/// <returns></returns>
		double GetAnnualSalary(double? salary);
    }
}
