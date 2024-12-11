using TodoApi.Dto;

namespace TodoApi.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<IEnumerable<UserDTO>> GetAllUsersWithToDoItemsEagerAsync();
    Task<IEnumerable<UserDTO>> GetAllUsersWithToDoItemsLazyAsync();
    Task<UserDTO> GetUserByIdAsync(long id);
    Task<UserDTO> AddUserAsync(UserDTO userDTO);

}

