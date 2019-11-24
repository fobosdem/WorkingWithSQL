using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL.BlToDalController
{
	public class CreatorController : IController<CreatorDTO>
	{
		private CreatorsDapperRepository _creatorsDapperRepository = new CreatorsDapperRepository();
		public CreatorDTO Create(CreatorDTO creator)
		{
			var result = _creatorsDapperRepository.Create(MappingClass.CreatorFromBlToDal(creator));
			return MappingClass.CreatorFromDalToBl(result);
		}

		public void Delete(CreatorDTO creator)
		{
			_creatorsDapperRepository.Delete(MappingClass.CreatorFromBlToDal(creator));
		}

		public List<CreatorDTO> GetAll()
		{
			List<CreatorDTO> result = new List<CreatorDTO>();
			foreach (Creator creator in _creatorsDapperRepository.GetAll())
			{
				result.Add(MappingClass.CreatorFromDalToBl(creator));
			}
			return result;
		}

		public CreatorDTO GetById(int Id)
		{
			return MappingClass.CreatorFromDalToBl(_creatorsDapperRepository.GetById(Id));
		}

		public void Update(CreatorDTO creator)
		{
			_creatorsDapperRepository.Update(MappingClass.CreatorFromBlToDal(creator));
		}
	}
}
