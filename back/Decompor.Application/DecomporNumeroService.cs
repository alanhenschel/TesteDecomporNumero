using Decompor.Application.Dtos;
using Decompor.Application.interfaces;

namespace Decompor.Application;
public class DecomporNumeroService : IDecomporNumeroService
{
    private static IEnumerable<int> GetDivisores(int numero)
    {
        return from i in Enumerable.Range(1, numero) where numero % i == 0 select i;
    }
    private static List<int> GetPrimos(IEnumerable<int> divisores)
    {
        List<int> primos = new List<int>();

        foreach (var divisor in divisores)
        {
            var todosDivisores = from i in Enumerable.Range(2, divisor) where divisor % i == 0 select i;

            if (todosDivisores.Count() == 1)
            {
                if (primos.Count == 0) {
                    primos.Add(1);
                }
                primos.Add(divisor);
            }
        }



        return primos;
    }

    public NumeroDto Decompor(int numero)
    {
        var divisores = GetDivisores(numero);
        var primos = GetPrimos(divisores);

        return new NumeroDto()
        {
            Numero = numero,
            Divisores = divisores.ToList(),
            Primos = primos.ToList()
        };
    }
}
