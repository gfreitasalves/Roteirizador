using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Application.Command;
using Roteirizador.Application.Input;
using Roteirizador.Application.UseCases;
using Roteirizador.Application.UseCases.Interfaces;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Testes.Application
{
    [TestClass]
    public class CalcularRotaMaisBarataUseCaseTests
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
        public async Task QuandoObterRotasPossiveisRetornarListaDeRotas()
        {
            //Arrange            
            var obterRotaQueryMock = new Mock<IObterRotaQuery>();
            var obterRotasPossiveisService = new ObterRotasPossiveisService();

            obterRotaQueryMock.Setup(x => x.SelecionarTodosAsync())
               .ReturnsAsync(_rotasPossiveis);


            var calcularRotaMaisBarataUseCase = new CalcularRotaMaisBarataUseCase(obterRotaQueryMock.Object, obterRotasPossiveisService);

            var input = new ViagemInput() { Origem = "GRU", Destino = "CDG" };

            //Act
            var result = await calcularRotaMaisBarataUseCase.Calcular(input);

            //Assert
            result.Should().NotBeNull();
            result.ValorTotal.Should().Be(40);
        }
    }
}
