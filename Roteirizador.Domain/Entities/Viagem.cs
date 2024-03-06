using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roteirizador.Domain.Entities
{
    public class Viagem : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Origem { get; set; }
        public string? Destino { get; set; }
        public required LinkedList<Rota> Rotas { get; set; }        

        public void CalcularRotas(LinkedList<Rota> Rotas, string origem, string destino) 
        {

        }
    }
}
