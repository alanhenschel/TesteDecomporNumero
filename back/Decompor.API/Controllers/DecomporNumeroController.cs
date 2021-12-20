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
    public async Task<IActionResult> Post(int numero)
    {
        try
        {
            var t1 = Task.Run(() => _decomporNumeroService.Decompor(numero));

            await Task.WhenAll(t1);

            var resultado = t1.Result;

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
