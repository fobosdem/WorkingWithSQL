using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Context;
namespace DAL
{
	public class CreatorsDapperRepository : IRepository<Creator>
	{
		public Creator Create(Creator creator)
		{
			using (DbRepository db = new DbRepository())
			{
				db.Creators.Add(creator);
				db.SaveChanges();
			}
			return creator;
		}

		public void Delete(Creator creator)
		{
			using (DbRepository db = new DbRepository())
			{
				if (db.Creators.Any(g => g.CreatorName == creator.CreatorName))
				{
					db.Creators.Remove(db.Creators.FirstOrDefault(g => g.CreatorName == creator.CreatorName));
					db.SaveChanges();
				}
			}
		}

		public List<Creator> GetAll()
		{
			List<Creator> creators = new List<Creator>();
			using (DbRepository db = new DbRepository())
			{
				return db.Creators.AsList();
			}
		}

		public Creator GetById(int Id)
		{
			using (DbRepository db = new DbRepository())
			{
				return db.Creators.Where(cr => cr.Id == Id).FirstOrDefault();
			}
		}

		public void Update(Creator creator)
		{
			using (DbRepository db = new DbRepository())
			{
				var UpCreator = db.Creators.Where(cr => cr.CreatorName == creator.CreatorName).FirstOrDefault();
				UpCreator.CreatorName = creator.CreatorName;
				UpCreator.LicenseNumber = creator.LicenseNumber;
				db.SaveChanges();
			}
		}
	}
}
