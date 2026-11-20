using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using calcalc.api.Data; 

namespace calcalc.api.Controllers;

[ApiController] 
[Route("/api/[controller]")]
public class UserController : ControllerBase 
{
	// UserControllerImplementation
	private readonly AppDbContext _db; 
	public UserController(AppDbContext db) 
	{
		_db = db; 
	}
	// GET /user/42 
	[HttpGet("{id:int}")]
	public async Task <IActionResult>GetById(int id) 
	{
		var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);

		if(user is null) 
		{
			return NotFound(); // return 404 
		}
		
		return Ok(new {
				user.Id,
				user.Email,
				user.CreatedAt
				});
	}

	[HttpGet]
	public async Task <IActionResult>GetAll()
	{
		var users = await _db.Users
			.AsNoTracking()
			.Select(user => new 
					{
					user.Id,
					user.Email,
					user.CreatedAt
					})
			.ToListAsync();

			return Ok(users);
	}
}
