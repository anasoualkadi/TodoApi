namespace TodoApi.Models;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public virtual ICollection<TodoItem>? TodoItems { get; set; }

    public Contract? Contract { get; set; }

}