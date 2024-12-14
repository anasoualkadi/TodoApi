namespace TodoApi.Models;

public class Contract
{
    public long Id { get; set; }
    public long Salary { get; set; }
    public long? UserId { get; set; }
    public User? User { get; set; }

}