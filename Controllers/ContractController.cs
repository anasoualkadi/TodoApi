using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Dto;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly TodoContext _context;

    public ContractController(TodoContext context)
    {
        _context = context;
    }

    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractDTO>>> GetTodoItems()
    {
        var listModel = _context.Contracts.Include(x => x.User).ToList();
        return await _context.Contracts
            .Select(x => ContractToDTO(x))
            .ToListAsync();
    }


    [HttpPost]
    public async Task<ActionResult<ContractDTO>> PostContract(ContractDTO contractDTO)
    {
        var contract = new Contract
        {
            Salary = contractDTO.Salary,
            UserId = contractDTO.UserId
        };

        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();

        return Ok(contract);
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

    private static ContractDTO ContractToDTO(Contract contract)
    {
        return new ContractDTO
        {
            Id = contract.Id,
            Salary = contract.Salary,
            User = UserToDto(contract.User)
        };
    }
}