using Decompor.Application.Dtos;

namespace Decompor.Application.interfaces
{
    public interface IDecomporNumeroService
    {
        NumeroDto Decompor(int numero);       
    }
}