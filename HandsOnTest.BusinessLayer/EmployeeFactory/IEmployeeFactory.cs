using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DTOs;
namespace HandsOnTest.BusinessLayer
{
	/// <summary>
	/// Factory to Create the Employee DTO as per Employee Contract Type
	/// </summary>
	public interface IEmployeeFactory
	{
		/// <summary>
		/// Create the Employee as per contractType
		/// </summary>
		/// <param name="contractType"></param>
		/// <returns></returns>
		Employee CreateEmployee(string contractType);
	}
}
