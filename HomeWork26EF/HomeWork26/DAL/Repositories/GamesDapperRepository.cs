using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Context;

namespace DAL
{
	public class GamesDapperRepository : IRepository<Game>
	{
		public Game Create(Game game)
		{
			using (DbRepository db = new DbRepository())
			{
				db.Games.Add(game);
				db.SaveChanges();
			}
			return game;
		}

		public void Delete(Game game)
		{
			using (DbRepository db = new DbRepository())
			{
				if (db.Games.Any(g => g.GameName == game.GameName))
				{
					db.Games.Remove(db.Games.FirstOrDefault(g => g.GameName == game.GameName));
					db.SaveChanges();
				}
			}
		}

		public List<Game> GamesByLicense(int license)
		{
			using (DbRepository db = new DbRepository())
			{
				return license == 0 ? db.Games.Include("Creator").Include("Genre").ToList() : db.Games.Include("Creator").Include("Genre").Where(s => s.Creator.LicenseNumber == license).ToList();
			}
		}

		public List<Game> GetAll()
		{
			using (DbRepository db = new DbRepository())
			{
				return db.Games.ToList();
			}
		}

		public Game GetById(int Id)
		{
			using (DbRepository db = new DbRepository())
			{
				return db.Games.Where(cr => cr.Id == Id).FirstOrDefault();
			}
		}

		public void Update(Game game)
		{
			using (DbRepository db = new DbRepository())
			{
				var upGame = db.Games.Where(g => g.GameName == game.GameName).FirstOrDefault();
				upGame.GameName = game.GameName;
				upGame.GenreId = game.GenreId;
				upGame.CreateYear = game.CreateYear;
				upGame.CreatorId = game.CreatorId;
				db.SaveChanges();
			}
		}
	}
}
