using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
	public class GamesDapperRepository : IRepository<Game>
	{
		private readonly string _connectionString = @"Data Source=DESKTOP-R04KCA7;Initial Catalog=GamesAndCreator;Integrated Security=True";

		public Game Create(Game game)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "INSERT INTO Game (GameName, GameYear, GenreId, CreatorId) VALUES(@GameName, @GameYear, @GenreId, @CreatorId); SELECT CAST(SCOPE_IDENTITY() as int)";
				int gameId = db.Query<int>(sqlQuery, game).FirstOrDefault();
				game.Id = gameId;
			}
			return game;
		}

		public void Delete(Game game)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "DELETE FROM Users WHERE Id = @Id";
				db.Execute(sqlQuery, new { game.Id });
			}
		}

		public List<Game> GamesByLicense(int license)
		{
			List<Game> games = new List<Game>();
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				games = db.Query<Game>(
					"SELECT g.Id, g.GameName, g.GameYear, g.GenreId, g.CreatorId FROM Game g"
					+ " LEFT JOIN Creator c ON c.Id = g.CreatorId"
					+ " WHERE c.LicenseNumber = @license", new { license }).ToList();
			}
			return games;
		}

		public List<Game> GetAll()
		{
			List<Game> games = new List<Game>();
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				games = db.Query<Game>("SELECT * FROM Games").ToList();
			}
			return games;
		}

		public Game GetById(int Id)
		{
			Game game = null;
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				game = db.Query<Game>("SELECT * FROM Games WHERE Id = @id", new { Id }).FirstOrDefault();
			}
			return game;
		}

		public void Update(Game game)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "UPDATE Users SET GameName = @GameName, CreateYear = @CreateYear, GenreId = @GenreId, CreatorId = @CreatorId WHERE Id = @Id";
				db.Execute(sqlQuery, game);
			}
		}
	}
}
