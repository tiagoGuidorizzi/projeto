using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Domain;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IRepository<Player> _repository;

    public PlayerController(IRepository<Player> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetPlayers()
    {
        var players = _repository.GetAll();
        return Ok(players);
    }
}