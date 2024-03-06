namespace Roteirizador.Domain.Entities
{
    public class Rota : IEntity
    {
        public Rota()
        {
            Origem = string.Empty;
            Destino = string.Empty;
        }
        public Rota(Guid? id, string origem, string destino, decimal valor)
        {
            Id = id ?? Guid.NewGuid();
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
        public Guid Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal Valor { get; set; }
    }
}
