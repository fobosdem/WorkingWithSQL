using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	internal static class MappingClass
	{
		private static IMapper _blMapper = new MapperConfiguration(
			conf =>
			{
				conf.CreateMap<Game, GameDTO>();
				conf.CreateMap<GameDTO, Game>();
				conf.CreateMap<Genre, GenreDTO>();
				conf.CreateMap<GenreDTO, Genre>();
				conf.CreateMap<Creator, CreatorDTO>();
				conf.CreateMap<CreatorDTO, Creator>();
			}).CreateMapper();

		internal static Game GameFromBlToDal(GameDTO game)
		{
			return _blMapper.Map<GameDTO, Game>(game);
		}
		internal static GameDTO GameFromDalToBl(Game game)
		{
			return _blMapper.Map<Game, GameDTO>(game);
		}
		internal static Genre GenreFromBlToDal(GenreDTO genre)
		{
			return _blMapper.Map<GenreDTO, Genre>(genre);
		}
		internal static GenreDTO GenreFromDalToBl(Genre genre)
		{
			return _blMapper.Map<Genre, GenreDTO>(genre);
		}
		internal static Creator CreatorFromBlToDal(CreatorDTO creator)
		{
			return _blMapper.Map<CreatorDTO, Creator>(creator);
		}
		internal static CreatorDTO CreatorFromDalToBl(Creator creator)
		{
			return _blMapper.Map<Creator, CreatorDTO>(creator);
		}
	}
}
