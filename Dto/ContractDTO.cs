namespace TodoApi.Dto;

public class ContractDTO
{
    public long? Id { get; set; }
    public long Salary { get; set; }

    public long? UserId { get; set; }

    public UserDTO? User { get; set; }
}