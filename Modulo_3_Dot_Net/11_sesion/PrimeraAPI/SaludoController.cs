using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SaludoController : ControllerBase
{
    
    // GET /saludo
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { mensaje = "Hola desde el SaludoController"});
    }

    // GET /saludo/Saludo2/{name}
    [HttpGet("saludo2/{name}")]
    public IActionResult GetSaludo2(string name)
    {
        var respuesta = new
        {
            mensaje = $"Hola: {name}"
        };

        return Ok(respuesta);
    }

}