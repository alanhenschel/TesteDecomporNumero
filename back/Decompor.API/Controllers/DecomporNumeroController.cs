using Decompor.Application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Decompor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DecomporNumeroController : ControllerBase
{

    private readonly IDecomporNumeroService _decomporNumeroService;

    public DecomporNumeroController(IDecomporNumeroService decomporNumeroService)
        {
            this._decomporNumeroService = decomporNumeroService;
        }

    [HttpPost("{numero}")]
    public IActionResult Post(int numero)
    {
        try
        {

            var resultado = _decomporNumeroService.Decompor(numero);

            if (resultado == null) return BadRequest("Erro ao tentar decompor numero.");

            return Ok(resultado);
        }
        catch (Exception ex)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar decompor numero. Erro: {ex.Message}");
        }
    }
}
