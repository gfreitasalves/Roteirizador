namespace Roteirizador.Application.Input
{
    public class RotaInput
    {
        public Guid? Id { get; set; }
        public required string Origem { get; set; }
        public required string Destino { get; set; }
        public required decimal Valor { get; set; }
    }
}
