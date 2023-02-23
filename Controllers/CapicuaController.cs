using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class CapicuaController: ControllerBase
{
     private readonly ICapicuaService _capicuaService;

     public CapicuaController(ICapicuaService capicuaService)
     {
        _capicuaService = capicuaService;
     }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Capicua capicua){
        return Ok(await _capicuaService.Save(capicua));
    }

    [HttpGet]
    public List<Capicua> Get(){

        return _capicuaService.GetListCapi();
    }
    
}