namespace Roteirizador.Application.Output
{
    public class RotaOutput(Guid id, string origem, string destino, decimal valor)
    {
        public Guid Id { get; } = id;
        public string Origem { get; } = origem;
        public string Destino { get; } = destino;
        public decimal Valor { get; } = valor;
    }
}
