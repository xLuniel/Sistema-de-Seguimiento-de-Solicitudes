using Microsoft.AspNetCore.Mvc;
using Sistema_de_Seguimiento_de_Solicitudes.Models;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CalendarioController : ControllerBase
{
    private static List<CalendarioDTO> DiasActivos = new();

    [HttpGet]
    public ActionResult<List<CalendarioDTO>> Get()
    {
        return Ok(DiasActivos);
    }

    [HttpPost]
    public IActionResult Post(List<CalendarioDTO> diasActivos)
    {
        DiasActivos = diasActivos;
        return Ok();
    }
}
