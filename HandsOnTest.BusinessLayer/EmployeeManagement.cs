using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DTOs;
using HandsOnTest.DataAccessLayer.Contracts;
using AutoMapper;
namespace HandsOnTest.BusinessLayer
{
	public class EmployeeManagement :BaseBL, IEmployeeManagement
	{
		private readonly IEmployeeRepository _EmployeeRepository;
		private readonly IEmployeeFactory _EmployeeFactory;
		private readonly Func<string, ISalaryCalculator> _SalaryCacluatorFactory;


		public EmployeeManagement(IEmployeeRepository employeeRepository, IEmployeeFactory  employeeFactory, Func<string,ISalaryCalculator> salaryCacluatorFactory, IMapper mapper):base(mapper)
		{
			_EmployeeRepository = employeeRepository;
			_EmployeeFactory = employeeFactory;
			_SalaryCacluatorFactory = salaryCacluatorFactory;
		}
		public List<Employee> GetEmployees(int? employeeId)
		{
			List<Employee> lstEmployees = new List<Employee>();
			var employees = _EmployeeRepository.GetAll();

			foreach (var employee in employees)
			{
				var oEmployee = _EmployeeFactory.CreateEmployee(employee.ContractTypeName);
				oEmployee= Mapper.Map(employee, oEmployee);
				oEmployee.AnnualSalary = _SalaryCacluatorFactory(employee.ContractTypeName).GetAnnualSalary(oEmployee.Salary);
				
				lstEmployees.Add(oEmployee);
			}
			if (employeeId.HasValue)
			{

				return lstEmployees.Where(t => t.Id == employeeId.Value).ToList();
			}
			return lstEmployees;
		}
		
	}
}
