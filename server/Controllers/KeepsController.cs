namespace Keepr_Remastered.Controllers;

[ApiController]
[Route("api/[controller]")]

public class KeepsController : ControllerBase
{
    private readonly Auth0Provider _auth0Provider;
    private readonly KeepsService _keepsService;

    public KeepsController(Auth0Provider auth0Provider, KeepsService keepsService)
    {
        _auth0Provider = auth0Provider;
        _keepsService = keepsService;
    }

    [Authorize]
    [HttpPost]

    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            keepData.CreatorId = userInfo.Id;
            Keep keep = _keepsService.CreateKeep(keepData);
            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}