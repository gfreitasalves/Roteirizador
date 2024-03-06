using Roteirizador.Application.UseCases;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Testes.Domain
{
    [TestClass]
    public class CalculoRotasTests
    {
        private readonly IList<Rota> _rotasPossiveis = new List<Rota>()
        {
            new Rota(null,"GRU","BRC",10),
            new Rota(null,"BRC","SCL",5),
            new Rota(null,"GRU","CDG",75),
            new Rota(null,"GRU","SCL",20),
            new Rota(null,"GRU","ORL",56),
            new Rota(null,"ORL","CDG",5),
            new Rota(null,"SCL","ORL",20)
        };


        [TestMethod]
        public void QuandoObterRotasPossiveisRetornarListaDeRotas()
        {
            //Arrange
            var calculoRotas = new CalculoRotas();

            //Act
            var result = calculoRotas.ObterRotasPossiveis("GRU", "CDG", _rotasPossiveis);

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(4);
        }
    }
}
