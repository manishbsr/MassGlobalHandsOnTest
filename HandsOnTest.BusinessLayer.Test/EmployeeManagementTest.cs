using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HandsOnTest.BusinessLayer;
using AutoMapper;
using HandsOnTest.DataAccessLayer.Contracts;
using System.Collections.Generic;
using HandsOnTest.DTOs.Constants;
using System.Linq;

namespace HandsOnTest.BusinessLayer.Test
{
	[TestClass]
	public class EmployeeManagementTest
	{
		private static IMapper mapper = null;

		public EmployeeManagementTest()
		{
			mapper = RegisterAutoMapperProfiles();
		}

		[TestMethod]
		public void GetEmployees_TestWithValidContractType()
		{

			
			var employeeRepositoryMock = new Mock<IEmployeeRepository>();
			var employeeFactory = new EmployeeFactory(); 
			var hourlysalaryCalculatorMock = new Mock<ISalaryCalculator>();
			var monthlysalaryCalculatorMock = new Mock<ISalaryCalculator>();
			Func<string, ISalaryCalculator> salaryCalculatorFactory = delegate (string name)
				 {
					 if (name == EmployeeTypeContract.Hourly)
						 return hourlysalaryCalculatorMock.Object;
					 else if (name == EmployeeTypeContract.Monthy)
						 return monthlysalaryCalculatorMock.Object;

					 return null;
				 };
			

			EmployeeManagement employeeManagementTest = new EmployeeManagement(employeeRepositoryMock.Object, employeeFactory,
															salaryCalculatorFactory, mapper);

			
			List<HandsOnTest.DbModels.Employee> dbEmployees = new List<DbModels.Employee>();
			dbEmployees.Add(new DbModels.Employee() { Id = 1, Name = "Emp1", ContractTypeName = EmployeeTypeContract.Hourly, HourlySalary=200.00 });
			dbEmployees.Add(new DbModels.Employee() { Id = 2, Name = "Emp2", ContractTypeName = EmployeeTypeContract.Monthy, MonthlySalary=2000.00 });
			employeeRepositoryMock.Setup(t => t.GetAll()).Returns(dbEmployees);
			hourlysalaryCalculatorMock.Setup(t => t.GetAnnualSalary(It.IsAny<double?>())).Returns(400);
			monthlysalaryCalculatorMock.Setup(t => t.GetAnnualSalary(It.IsAny<double?>())).Returns(100);
			
			var employees=employeeManagementTest.GetEmployees(1);
			Assert.AreEqual(1, employees.Count);
			Assert.AreEqual(400, employees[0].AnnualSalary);



			employees = employeeManagementTest.GetEmployees(2);
			Assert.AreEqual(1, employees.Count);
			Assert.AreEqual(100, employees[0].AnnualSalary);

			employees = employeeManagementTest.GetEmployees(null);
			Assert.AreEqual(2, employees.Count);
			Assert.AreEqual(400, employees[0].AnnualSalary);
			Assert.AreEqual(100, employees[1].AnnualSalary);
			//employeeManagementTest.GetEmployees()

		}

		[TestMethod]
		public void GetEmployees_TestWithInValidContractType()
		{
			var employeeRepositoryMock = new Mock<IEmployeeRepository>();
			var employeeFactory = new EmployeeFactory();
			var hourlysalaryCalculatorMock = new Mock<ISalaryCalculator>();
			var monthlysalaryCalculatorMock = new Mock<ISalaryCalculator>();
			Func<string, ISalaryCalculator> salaryCalculatorFactory = delegate (string name)
			{
				if (name == EmployeeTypeContract.Hourly)
					return hourlysalaryCalculatorMock.Object;
				else if (name == EmployeeTypeContract.Monthy)
					return monthlysalaryCalculatorMock.Object;

				return null;
			};


			EmployeeManagement employeeManagementTest = new EmployeeManagement(employeeRepositoryMock.Object, employeeFactory,
															salaryCalculatorFactory, mapper);


			List<HandsOnTest.DbModels.Employee> dbEmployees = new List<DbModels.Employee>();
			dbEmployees.Add(new DbModels.Employee() { Id = 1, Name = "Emp1", ContractTypeName = EmployeeTypeContract.Hourly, HourlySalary = 200.00 });
			dbEmployees.Add(new DbModels.Employee() { Id = 2, Name = "Emp2", ContractTypeName = "XYZ", MonthlySalary = 2000.00 });
			employeeRepositoryMock.Setup(t => t.GetAll()).Returns(dbEmployees);
			hourlysalaryCalculatorMock.Setup(t => t.GetAnnualSalary(It.IsAny<double?>())).Returns(400);
			monthlysalaryCalculatorMock.Setup(t => t.GetAnnualSalary(It.IsAny<double?>())).Returns(100);

			try
			{
				var employees = employeeManagementTest.GetEmployees(1);
				Assert.Fail();
			}
			catch
			{
				
			}
		}
		private static IMapper RegisterAutoMapperProfiles()
		{

			var profiles = from t in typeof(HandsOnTest.ModelMapper.HourlyEmployeeProfile).Assembly.GetTypes()
						   where typeof(Profile).IsAssignableFrom(t)
						   select (Profile)Activator.CreateInstance(t);

			var config = new MapperConfiguration(cfg =>
			{
				foreach (var profile in profiles)
				{
					cfg.AddProfile(profile);
				}
			});

			return config.CreateMapper();
		}
	}
}
