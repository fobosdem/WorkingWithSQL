using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public interface IRepository<T> where T : class
	{
		T GetById(int Id);
		List<T> GetAll();
		void Update(T genre);
		void Delete(T genre);
		T Create(T genre);
	}
}
