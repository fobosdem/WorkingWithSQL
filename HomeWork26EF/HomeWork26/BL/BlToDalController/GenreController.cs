using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlToDalController
{
	public class GenreController : IController<GenreDTO>
	{
		private GenreDapperRepository _genreDapperRepository = new GenreDapperRepository();
		public GenreDTO Create(GenreDTO genre)
		{
			var result = _genreDapperRepository.Create(MappingClass.GenreFromBlToDal(genre));
			return MappingClass.GenreFromDalToBl(result);
		}

		public void Delete(GenreDTO genre)
		{
			_genreDapperRepository.Delete(MappingClass.GenreFromBlToDal(genre));
		}

		public List<GenreDTO> GetAll()
		{
			List<GenreDTO> result = new List<GenreDTO>();
			foreach (Genre genre in _genreDapperRepository.GetAll())
			{
				result.Add(MappingClass.GenreFromDalToBl(genre));
			}
			return result;
		}

		public GenreDTO GetById(int Id)
		{
			return MappingClass.GenreFromDalToBl(_genreDapperRepository.GetById(Id));
		}

		public void Update(GenreDTO genre)
		{
			_genreDapperRepository.Update(MappingClass.GenreFromBlToDal(genre));
		}
	}
}
