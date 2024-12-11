namespace TodoApi.Dto;

public class UserDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public ICollection<TodoItemDTO>? TodoItems { get; set; } = new List<TodoItemDTO>();
}