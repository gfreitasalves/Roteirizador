using Roteirizador.Application.Input;
using Roteirizador.Application.UseCases.Interfaces;

namespace Roteirizador.Api
{
    public static class RoutesConfiguration
    {
        public static WebApplication RegisterRoutes(this WebApplication app)
        {
            RegistrarRota(app);
            RegistrarCalcularRota(app);

            return app;
        }
        private static void RegistrarCalcularRota(WebApplication app)
        {
            //Calculo de Rotas

            app.MapPost("/CalcularRota", async (ICalcularRotaMaisBarataUseCase calcularRotaMaisBarataUseCase, ViagemInput viagem) =>
            {
                var result = await calcularRotaMaisBarataUseCase.CalcularAsync(viagem);

                return result;
            })
            .WithName("CalcularRota")
            .WithOpenApi();
        }

        private static void RegistrarRota(WebApplication app)
        {
            // Manter Rotas
            app.MapGet("/Rota", async (IManterRotasUseCase manterRotasUseCase) =>
            {
                var list = await manterRotasUseCase.SelecionarTodosAsync();

                return list;
            })
            .WithName("ListarRotas")
            .WithOpenApi();

            app.MapGet("/Rota/{id}", async (Guid id, IManterRotasUseCase manterRotasUseCase) =>
            {
                var list = await manterRotasUseCase.SelecionarPorIdAsync(id);

                return list;
            })
            .WithName("ObterRota")
            .WithOpenApi();

            app.MapPost("/Rota", async (IManterRotasUseCase manterRotasUseCase, RotaInput rota) =>
            {
                var result = await manterRotasUseCase.InserirAsync(rota);

                return result;
            })
            .WithName("CriarRota")
            .WithOpenApi();

            app.MapPut("/Rota", async (IManterRotasUseCase manterRotasUseCase, RotaInput rota) =>
            {
                var result = await manterRotasUseCase.AtualizarAsync(rota);

                return result;
            })
            .WithName("AtalizarRota")
            .WithOpenApi();

            app.MapDelete("/Rota/{id}", async (IManterRotasUseCase manterRotasUseCase, Guid id) =>
            {
                var result = await manterRotasUseCase.DeletarAsync(id);

                return result;
            })
            .WithName("DeletarRota")
            .WithOpenApi();
        }
    }
}
