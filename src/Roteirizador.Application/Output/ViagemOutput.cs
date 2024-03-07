namespace Roteirizador.Application.Output
{
    public class ViagemOutput(string origem, string destino,string mensagem, bool sucesso, IList<RotaOutput> rotas)
    {
        public string Origem { get; } = origem;
        public string Destino { get; } = destino;
        public string Mensagem { get; } = mensagem;
        public bool Sucesso { get; } = sucesso;
        public decimal ValorTotal { get { return Rotas.Sum(x => x.Valor); } }
        public IList<RotaOutput> Rotas { get; set; } = rotas;
    }
}
