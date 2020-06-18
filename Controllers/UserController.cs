using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServices.Models;
using UserServices.Repository;

namespace UserServices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IUserRepository userRepository;
		public UserController(IUserRepository _userRepository)
		{
			userRepository = _userRepository;
		}

		[HttpGet]
		[Route("GetUsers")]
		public async Task<IActionResult> GetUsers()
		{
			try
			{
				var users = await userRepository.GetUsersList();
				if (users == null)
				{
					return NotFound();
				}

				return Ok(users);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("GetUser")]
		public async Task<IActionResult> GetUser(int? userID)
		{
			if (userID == null)
			{
				return BadRequest();
			}

			try
			{
				var post = await userRepository.GetUser(userID);

				if (post == null)
				{
					return NotFound();
				}

				return Ok(post);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("AddUser")]
		public async Task<IActionResult> AddUser([FromBody]TblUser model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var userId = await userRepository.AddNewUser(model);
					if (userId > 0)
					{
						return Ok(userId);
					}
					else
					{
						return NotFound();
					}
				}
				catch (Exception)
				{

					return BadRequest();
				}

			}

			return BadRequest();
		}

		[HttpPost]
		[Route("DeleteUser")]
		public async Task<IActionResult> DeleteUser([FromBody]int? userId)
		{
			int result = 0;

			if (userId == null)
			{
				return BadRequest();
			}

			try
			{
				result = await userRepository.DeleteUser(userId);
				if (result == 0)
				{
					return NotFound();
				}
				return Ok();
			}
			catch (Exception)
			{

				return BadRequest();
			}
		}

		[HttpPost]
		[Route("UpdateUser")]
		public async Task<IActionResult> UpdateUser([FromBody]TblUser model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await userRepository.UpdateUser(model);

					return Ok();
				}
				catch (Exception ex)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}
	}
}