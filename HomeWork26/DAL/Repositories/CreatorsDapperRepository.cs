using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
	public class CreatorsDapperRepository : IRepository<Creator>
	{
		private readonly string _connectionString = @"Data Source=DESKTOP-R04KCA7;Initial Catalog=GamesAndCreator;Integrated Security=True";

		public Creator Create(Creator creator)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "INSERT INTO Creators (CreatorName, LicenseNumber) VALUES(@CreatorName, @LicenseNumber); SELECT CAST(SCOPE_IDENTITY() as int)";
				int creatorId = db.Query<int>(sqlQuery, creator).FirstOrDefault();
				creator.Id = creatorId;
			}
			return creator;
		}

		public void Delete(Creator creator)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "DELETE FROM Creators WHERE Id = @Id";
				db.Execute(sqlQuery, new { creator.Id });
			}
		}

		public List<Creator> GetAll()
		{
			List<Creator> creators = new List<Creator>();
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				creators = db.Query<Creator>("SELECT * FROM Creators").ToList();
			}
			return creators;
		}

		public Creator GetById(int Id)
		{
			Creator creator = null;
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				creator = db.Query<Creator>("SELECT * FROM Creators WHERE Id = @id", new { Id }).FirstOrDefault();
			}
			return creator;
		}

		public void Update(Creator creator)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var sqlQuery = "UPDATE Genres SET CreatorName = @CreatorName, LicenseNumber = @LicenseNumber WHERE Id = @Id";
				db.Execute(sqlQuery, creator);
			}
		}
	}
}
