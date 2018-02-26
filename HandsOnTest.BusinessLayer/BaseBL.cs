using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HandsOnTest.BusinessLayer
{
	public abstract class BaseBL : IDisposable
	{
		protected IMapper Mapper { get; private set; }
		public BaseBL(IMapper mapper)
		{
			Mapper = mapper;

		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
