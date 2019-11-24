using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
	public class GenreDapperRepository : IRepository<Genre>
	{
		private readonly string _connectionString = @"Data Source=DESKTOP-R04KCA7;Initial Catalog=GamesAndCreator;Integrated Security=True";
		
		public Genre Create(Genre genre)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "INSERT INTO Genres (GenreName, Description) VALUES(@GenreName, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
				int genreId = db.Query<int>(sqlQuery, genre).FirstOrDefault();
				genre.Id = genreId;
			}
			return genre;
		}

		public void Delete(Genre genre)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "DELETE FROM Genres WHERE Id = @Id";
				db.Execute(sqlQuery, new { genre.Id });
			}
		}

		public List<Genre> GetAll()
		{
			List<Genre> genres = new List<Genre>();
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				genres = db.Query<Genre>("SELECT * FROM Genres").ToList();
			}
			return genres;
		}

		public Genre GetById(int Id)
		{
			Genre genre = null;
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				genre = db.Query<Genre>("SELECT * FROM Genres WHERE Id = @id", new { Id }).FirstOrDefault();
			}
			return genre;
		}

		public void Update(Genre genre)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				int takeIdQuery = db.Query<Genre>("SELECT * FROM Genres WHERE GenreName = @GenreName", new { genre.GenreName }).FirstOrDefault().Id;

				genre.Id = takeIdQuery;

				var sqlQuery = "UPDATE Genres SET GenreName = @GenreName, Description = @Description WHERE Id = @Id";
				db.Execute(sqlQuery, genre);
			}
		}
	}
}
