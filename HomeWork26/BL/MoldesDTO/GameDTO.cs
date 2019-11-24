using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class GameDTO
	{
		public int Id { get; set; }
		private string _gameName;
		public string GameName
		{
			get
			{
				return _gameName;
			}
			set
			{
				var setValue = value;

				if (setValue.ToCharArray().Length > 60)
				{
					throw new ValidationException("Name of the game should be less then 60 letters", "");
				}

				_gameName = setValue;
			}
		}
		private int _createYear { get; set; }
		public int CreateYear
		{
			get
			{
				return _createYear;
			}
			set
			{
				var setValue = value;

				if (_createYear < 1980 || _createYear > DateTime.Now.Year)
				{
					throw new ValidationException("Publishing year should be much than 1980 and not much than today's year", "");
				}

				_createYear = setValue;
			}
		}
		public int GenreId { get; set; }
		public int CreatorId { get; set; }
	}
}
