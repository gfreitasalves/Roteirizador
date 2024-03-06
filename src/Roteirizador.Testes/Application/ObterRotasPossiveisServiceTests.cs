using Roteirizador.Application.Command;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Testes.Application
{
    [TestClass]
    public class ObterRotasPossiveisServiceTests
    {
        private readonly IList<Rota> _rotasPossiveis = new List<Rota>()
        {
            new Rota("GRU","BRC",10),
            new Rota("BRC","SCL",5),
            new Rota("GRU","CDG",75),
            new Rota("GRU","SCL",20),
            new Rota("GRU","ORL",56),
            new Rota("ORL","CDG",5),
            new Rota("SCL","ORL",20)
        };


        [TestMethod]
        public void QuandoObterRotasPossiveisRetornarListaDeRotas()
        {
            //Arrange
            var obterRotasPossiveisService = new ObterRotasPossiveisService();

            //Act
            var result = obterRotasPossiveisService.ObterRotasPossiveis("GRU", "CDG", _rotasPossiveis);

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(4);            
        }
    }
}
