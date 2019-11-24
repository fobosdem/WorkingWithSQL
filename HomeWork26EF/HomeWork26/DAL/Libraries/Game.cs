using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL
{
	public class Game
	{
		public int Id { get; set; }
		public string GameName { get; set; }
		public int CreateYear { get; set; }
		public int GenreId { get; set; }
		public int CreatorId { get; set; }
		public Creator Creator { get; set; }
		public Genre Genre { get; set; }
	}

	public class Creator
	{
		public int Id { get; set; }
		public string CreatorName { get; set; }
		public int LicenseNumber { get; set; }
		public List<Game> Games { get; set; }
	}

	public class Genre
	{
		public int Id { get; set; }
		public string GenreName { get; set; }
		public string Description { get; set; }
		public List<Game> Games { get; set; }
	}
}
