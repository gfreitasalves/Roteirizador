namespace Roteirizador.Domain.Entities
{
    public class Rota(string origem, string destino, decimal valor) : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Origem { get; set; } = origem;
        public string Destino { get; set; } = destino;
        public decimal Valor { get; set; } = valor;
    }
}
