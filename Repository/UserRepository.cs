using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserServices.Models;

namespace UserServices.Repository
{
	public class UserRepository : IUserRepository
	{
		ApiDemoContext db;
		public UserRepository(ApiDemoContext _db)
		{
			db = _db;
		}

		public async Task<int> AddNewUser(TblUser user)
		{
			if (db != null)
			{
				await db.TblUser.AddAsync(user);
				await db.SaveChangesAsync();
				return user.Id;
			}

			return 0;
		}

		public async Task<int> DeleteUser(int? userId)
		{
			int result = 0;

			if (db != null)
			{
				var post = await db.TblUser.FirstOrDefaultAsync(x => x.Id == userId);
				if (post != null)
				{
					db.TblUser.Remove(post);
					result = await db.SaveChangesAsync();
				}
				return result;
			}
			return result;
		}

		public async Task<TblUser> GetUser(int? userId)
		{
			if (db != null)
			{
				return await (from x in db.TblUser where x.Id == userId select x).FirstOrDefaultAsync();
			}
			return null;
		}

		public async Task<List<TblUser>> GetUsersList()
		{
			if (db != null)
			{
				return await db.TblUser.ToListAsync();
			}
			return null;
		}

		public async Task UpdateUser(TblUser user)
		{
			if (db != null)
			{
				db.TblUser.Update(user);
				await db.SaveChangesAsync();
			}
		}
	}
}
