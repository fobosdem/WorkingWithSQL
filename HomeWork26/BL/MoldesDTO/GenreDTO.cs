using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class GenreDTO
	{
		public int Id { get; set; }
		public string GenreName { get; set; }
		private string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				var setValue = value;

				if (setValue.ToCharArray().Length > 600)
				{
					throw new ValidationException("Description shouldbe less than 600 letters", "");
				}

				_description = setValue;
			}
		}
	}
}
