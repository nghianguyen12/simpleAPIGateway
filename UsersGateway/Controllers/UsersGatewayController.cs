using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
[Authorize]
public class UsersGatewayController : ControllerBase
{
    private readonly IHttpClientFactory _factory;

    public UsersGatewayController(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var client = _factory.CreateClient("UserService");

        var response = await client.GetAsync($"api/users/{id}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }
}
