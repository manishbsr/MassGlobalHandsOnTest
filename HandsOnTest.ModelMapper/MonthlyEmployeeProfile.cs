using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using HandsOnTest.DTOs;
namespace HandsOnTest.ModelMapper
{
	public class MonthlyEmployeeProfile : Profile
	{
		public MonthlyEmployeeProfile()
		{
			CreateMap<HandsOnTest.DbModels.Employee, MonthlyEmployee>()
				.ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.MonthlySalary));
		}
	}
}
