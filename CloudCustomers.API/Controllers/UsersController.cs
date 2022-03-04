using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService _usersService){
        _usersService = _usersService;
    }

    [HttpGet(Name = "GetUSers")]
    public Task<ActionResult> Get()
    {
        var users = await _usersService.GetAllUsers();
        if(users.Any())
        {
            return NotFound();
        }
                
    }
}
