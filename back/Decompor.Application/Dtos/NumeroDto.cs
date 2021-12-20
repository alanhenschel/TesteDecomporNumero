namespace Decompor.Application.Dtos
{
    public class NumeroDto
    {
        public int Numero { get; set; }
        public IList<int>? Divisores { get; set; }
        public IList<int>? Primos { get; set; }
    }
}