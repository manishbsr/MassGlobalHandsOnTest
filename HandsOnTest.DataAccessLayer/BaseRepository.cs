using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DataAccessLayer.Contracts;
//using HandsOnTest.DataAccessLayer.Models;
using HandsOnTest.DbModels;
namespace HandsOnTest.DataAccessLayer
{
	public abstract class BaseRepository<T> : IRepository<T> where T : class
	{
		public abstract void Dispose();
		protected abstract void Dispose(bool disposing);
		
		
		public virtual IList<T> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
