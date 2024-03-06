using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Application.Input;
using Roteirizador.Application.UseCases;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Testes.Application
{
    [TestClass]
    public class CalcularRotaMaisBarataUseCaseTests
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
        public async Task QuandoObterRotasPossiveisRetornarListaDeRotas()
        {
            //Arrange            
            var obterRotaQueryMock = new Mock<IRotaQuery>();
            var calculoRotas = new CalculoRotas();

            obterRotaQueryMock.Setup(x => x.SelecionarTodosAsync())
               .ReturnsAsync(_rotasPossiveis);


            var calcularRotaMaisBarataUseCase = new CalcularRotaMaisBarataUseCase(obterRotaQueryMock.Object, calculoRotas);

            var input = new ViagemInput() { Origem = "GRU", Destino = "CDG" };

            //Act
            var result = await calcularRotaMaisBarataUseCase.CalcularAsync(input);

            //Assert
            result.Should().NotBeNull();
            result.ValorTotal.Should().Be(40);
        }
    }
}
