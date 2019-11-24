using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Context
{
	internal class DbRepository : DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Creator> Creators { get; set; }
		public DbRepository():base (@"Data Source=DESKTOP-R04KCA7;Initial Catalog=GamesAndCreator;Integrated Security=True;")
		{

		}
	}
}
