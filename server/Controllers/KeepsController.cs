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

    [HttpGet]
    public ActionResult<List<Keep>> GetKeeps()
    {
        try
        {
            List<Keep> keeps = _keepsService.GetKeeps();
            return Ok(keeps);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{keepId}")]
    public ActionResult<Keep> GetKeepById(int keepId)
    {
        try
        {
            Keep keep = _keepsService.GetKeepByIdAndIncrement(keepId);
            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPut("{keepId}")]
    public async Task<ActionResult<Keep>> EditKeep(int keepId, [FromBody] Keep keepData)
    {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        Keep keep = _keepsService.EditKeep(keepId, userInfo.Id, keepData);
        return Ok(keep);
    }

    [Authorize]
    [HttpDelete("{keepId}")]
    public async Task<ActionResult<string>> DeleteKeep(int keepId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string Message = _keepsService.DeleteKeep(keepId, userInfo.Id);
            return Ok(Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}