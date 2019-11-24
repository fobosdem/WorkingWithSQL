using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Context;

namespace DAL
{
	public class GenreDapperRepository : IRepository<Genre>
	{
		
		public Genre Create(Genre genre)
		{
			using (DbRepository db = new DbRepository())
			{
				db.Genres.Add(genre);
				db.SaveChanges();
			}
			return genre;
		}

		public void Delete(Genre genre)
		{
			using (DbRepository db = new DbRepository())
			{
				if (db.Genres.Any(g => g.GenreName == genre.GenreName))
				{
					db.Genres.Remove(db.Genres.FirstOrDefault(g => g.GenreName == genre.GenreName));
					db.SaveChanges();
				}
			}
		}

		public List<Genre> GetAll()
		{
			using (DbRepository db = new DbRepository())
			{
				return db.Genres.ToList();
			}
		}

		public Genre GetById(int Id)
		{
			using (DbRepository db = new DbRepository())
			{
				return db.Genres.FirstOrDefault(g => g.Id == Id);
			}
		}

		public void Update(Genre genre)
		{
			using (DbRepository db = new DbRepository())
			{
				var upGenre = db.Genres.FirstOrDefault(cr => cr.GenreName == genre.GenreName);
				upGenre.GenreName = genre.GenreName;
				upGenre.Description = genre.Description;
				db.SaveChanges();
			}
		}
	}
}
