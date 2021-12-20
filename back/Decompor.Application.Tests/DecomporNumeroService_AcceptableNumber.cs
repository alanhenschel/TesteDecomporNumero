using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Decompor.Application.Tests;

public class DecomporNumeroService_AcceptableNumber
{
    [Fact]
    public void Decompor_45()
    {
        var DecomporNumeroService = new DecomporNumeroService();

        var resultado = DecomporNumeroService.Decompor(45);

        var divisores = new List<int> {1, 3, 5, 9, 15, 45};
        var primos = new List<int> {1, 3, 5};

        var numeroCorreto = resultado.Numero == 45 ? true : false;

        var divisoresCorretos = resultado.Divisores.All(divisores.Contains);

        var primosCorretos = resultado.Primos.All(primos.Contains);

        var tudoOk = (numeroCorreto && primosCorretos && divisoresCorretos);
        
        Assert.True(tudoOk, "45, seus divisores, e divisores primos estão Ok");
    }

    [Fact]
    public void Decompor_10_DivisoresErrados()
    {
        var DecomporNumeroService = new DecomporNumeroService();

        var resultado = DecomporNumeroService.Decompor(10);

        var divisores = new List<int> {1, 3, 5, 9, 15, 45};
        var primos = new List<int> {1, 3, 5};

        var numeroCorreto = resultado.Numero == 45 ? true : false;

        var divisoresCorretos = resultado.Divisores.All(divisores.Contains);

        var primosCorretos = resultado.Primos.All(primos.Contains);

        var tudoOk = (numeroCorreto && primosCorretos && divisoresCorretos);
        
        Assert.False(tudoOk, "10, seus divisores, e divisores primos estão errados");
    }
}