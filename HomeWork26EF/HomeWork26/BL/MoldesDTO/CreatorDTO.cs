using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class CreatorDTO
	{
		public int Id { get; set; }
		public string CreatorName { get; set; }
		public int LicenseNumber { get; set; }
		public List<GameDTO> Games { get; set; }

	}
}
