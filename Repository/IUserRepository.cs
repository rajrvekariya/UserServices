using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserServices.Models;

namespace UserServices.Repository
{
	public interface IUserRepository
	{

        Task<List<TblUser>> GetUsersList();

        Task<TblUser> GetUser(int? userId);

        Task<int> AddNewUser(TblUser user);

        Task<int> DeleteUser(int? userId);

        Task UpdateUser(TblUser user);
    }
}
