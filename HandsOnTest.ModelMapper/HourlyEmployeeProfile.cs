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
	public class HourlyEmployeeProfile: Profile
	{
		public HourlyEmployeeProfile()
		{
			CreateMap<HandsOnTest.DbModels.Employee, HourlyEmployee>()
				.ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.HourlySalary));
		}
	}
}
