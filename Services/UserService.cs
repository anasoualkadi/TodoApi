using Microsoft.EntityFrameworkCore;
using TodoApi.Dto;
using TodoApi.Models;

namespace TodoApi.Services;

public class UserService : IUserService
{

    private readonly TodoContext _context;

    public UserService(TodoContext context)
    {
        _context = context;
    }

    public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
    {
        var user = new User
        {
            Name = userDTO.Name,
            Surname = userDTO.Surname
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return UserToDto(user);
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        return await _context.Users.Select(u => UserToDto(u)).ToListAsync();
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersWithToDoItemsEagerAsync()
    {
        return await _context.Users.Include(x => x.TodoItems).Select(u => UserWithToDoItemsToDto(u)).ToListAsync();
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersWithToDoItemsLazyAsync()
    {
        var users = await _context.Users.ToListAsync();
        var userDtos = users.Select(user => new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            TodoItems = user.TodoItems?.Select(todo => new TodoItemDTO
            {
                Id = todo.Id,
                Name = todo.Name,
                IsComplete = todo.IsComplete
            }).ToList()
        }).ToList();
        return userDtos;
    }

    public async Task<UserDTO> GetUserByIdAsync(long id)
    {
        var user = await _context.Users.FindAsync(id);
        return UserToDto(user);
    }

    private static UserDTO UserToDto(User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
        };
    }

    private static UserDTO UserWithToDoItemsToDto(User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            TodoItems = user.TodoItems?.Select(t => new TodoItemDTO()
            {
                Id = t.Id,
                Name = t.Name,
                IsComplete = t.IsComplete
            }).ToList()
        };
    }
}
