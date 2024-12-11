using Microsoft.AspNetCore.Mvc;
using TodoApi.Dto;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/TodoItems
    [HttpGet("GetUsers")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {

        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("GetUsersWithToDoItemsEager")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersWithToDoItemsEager()
    {

        var users = await _userService.GetAllUsersWithToDoItemsEagerAsync();
        return Ok(users);
    }

    [HttpGet("GetUsersWithToDoItemsLazy")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersWithToDoItemsLazy()
    {

        var users = await _userService.GetAllUsersWithToDoItemsLazyAsync();
        return Ok(users);
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(long id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
    {
        var user = await _userService.AddUserAsync(userDTO);

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            user);
    }

}