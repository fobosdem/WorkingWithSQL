using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlToDalController
{
	public class GameController : IController<GameDTO>
	{
		private GamesDapperRepository _gamesDapperRepository = new GamesDapperRepository();

		public GameDTO Create(GameDTO game)
		{
			var result = _gamesDapperRepository.Create(MappingClass.GameFromBlToDal(game));
			return MappingClass.GameFromDalToBl(result);
		}

		public void Delete(GameDTO game)
		{
			_gamesDapperRepository.Delete(MappingClass.GameFromBlToDal(game));
		}

		public List<GameDTO> GetAll()
		{
			List<GameDTO> result = new List<GameDTO>();
			foreach(Game game in _gamesDapperRepository.GetAll())
			{
				result.Add(MappingClass.GameFromDalToBl(game));
			}
			return result;
		}

		public GameDTO GetById(int Id)
		{
			return MappingClass.GameFromDalToBl(_gamesDapperRepository.GetById(Id));
		}

		public void Update(GameDTO game)
		{
			_gamesDapperRepository.Update(MappingClass.GameFromBlToDal(game));
		}

		public List<GameDTO> GamesByLicense(int license)
		{
			List<GameDTO> result = new List<GameDTO>();
			foreach (Game game in _gamesDapperRepository.GamesByLicense(license))
			{
				result.Add(MappingClass.GameFromDalToBl(game));
			}
			return result;
		}
	}
}
