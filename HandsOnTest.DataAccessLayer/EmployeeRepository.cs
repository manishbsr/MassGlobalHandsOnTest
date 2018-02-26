using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DataAccessLayer.Contracts;
//using HandsOnTest.DataAccessLayer.Models;
using HandsOnTest.DbModels;
using HandsOnTest.DataAccessLayer.ExternalSourceClient;
namespace HandsOnTest.DataAccessLayer
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		private readonly IExternalSourceClientClient _apiClient;
		public EmployeeRepository(IExternalSourceClientClient externalSourceClientClient)
		{
			_apiClient = externalSourceClientClient;
		}

		

		public override IList<Employee> GetAll()
		{
			try
			{
				//return new List<Employee>() { new Employee() { Name = "Test1", Id = 1, ContractTypeName="HourlySalaryEmployee" } };

				return _apiClient.ApiEmployeesGet();
			}
			catch 
			{
				//log the detials
				throw new Exception("Not able to get the Employees");
			}
		}
		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				_apiClient.Dispose();
			}
			
		}
	}
}
