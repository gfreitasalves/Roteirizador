namespace Roteirizador.Application.Output
{
    public class ViagemOutput(string origem, string destino, IList<RotaOutput> rotas)
    {
        public string Origem { get; } = origem;
        public string Destino { get; } = destino;
        public decimal ValorTotal { get { return Rotas.Sum(x => x.Valor); } }
        public IList<RotaOutput> Rotas { get; set; } = rotas;
    }
}
