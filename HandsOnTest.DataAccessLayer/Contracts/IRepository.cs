using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.DataAccessLayer.Contracts
{
	public interface IRepository<T>:IDisposable where T:class
	{
		IList<T> GetAll();
		
	}
}
