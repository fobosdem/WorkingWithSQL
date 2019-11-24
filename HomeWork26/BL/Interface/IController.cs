using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public interface IController<T> where T : class
	{
		T GetById(int Id);
		List<T> GetAll();
		void Update(T item);
		void Delete(T item);
		T Create(T item);
	}
}
