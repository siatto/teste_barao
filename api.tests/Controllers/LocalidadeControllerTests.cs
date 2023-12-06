using api.Application.Estudante.Command;
using api.Application.EstudanteLocalidade.Command;
using api.Application.Localidade.Command;
using api.Controllers;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace api.tests.Controllers
{
    public class LocalidadeControllerTests
    {
        [Fact]
        public async Task ListarTodos_DeveRetornarListaDeLocalidades()
        {
            var loggerMock = new Mock<ILogger<LocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ListarLocalidadeCommand>())).ReturnsAsync(new List<LocalidadeModel> { new LocalidadeModel(), new LocalidadeModel() });

            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ListarTodos();

            Assert.IsType<ActionResult<IEnumerable<LocalidadeModel>>>(result);
            var localidades = Assert.IsAssignableFrom<IEnumerable<LocalidadeModel>>(result.Value);
            Assert.Equal(2, localidades.Count());
        }

        [Fact]
        public async Task LocalidadePorId_DeveRetornarLocalidadeQuandoEncontrada()
        {
            var localidadeId = Guid.NewGuid();
            var localidadeRetornado = new LocalidadeModel { Id = localidadeId };

            var loggerMock = new Mock<ILogger<LocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<LocalidadePorIdCommand>())).ReturnsAsync(localidadeRetornado);

            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.LocalidadePorId(localidadeId);

            Assert.IsType<ActionResult<LocalidadeModel>>(result);
            var localidade = Assert.IsType<LocalidadeModel>(result.Value);
            Assert.Equal(localidadeId, localidade.Id);
        }

        [Fact]
        public async Task LocalidadePorId_DeveRetornarNoContentQuandoLocalidadeNaoEncontrada()
        {
            var localidadeId = Guid.NewGuid();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<LocalidadePorIdCommand>())).ReturnsAsync((LocalidadeModel)null);

            var loggerMock = new Mock<ILogger<LocalidadeController>>();
            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.LocalidadePorId(localidadeId);

            Assert.IsType<ActionResult<LocalidadeModel>>(result);
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task LocalidadePorLogradouro_DeveRetornarListaDeLocalidades()
        {
            var logradouro = "Teste";
            var localidadeRetornado = new List<LocalidadeModel> { new LocalidadeModel { Logradouro = logradouro } };

            var loggerMock = new Mock<ILogger<LocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<LocalidadePorLogradouroCommand>())).ReturnsAsync(localidadeRetornado);

            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.LocalidadePorLogradouro(logradouro);

            Assert.IsType<ActionResult<IEnumerable<LocalidadeModel>>>(result);
            var localidades = Assert.IsAssignableFrom<IEnumerable<LocalidadeModel>>(result.Value);
            Assert.Equal(1, localidades.Count());
        }

        [Fact]
        public async Task SalvarLocalidade_DeveRetornarOk()
        {
            var localidadeServiceMock = new Mock<ILocalidadeService>();
            var loggerMock = new Mock<ILogger<LocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<SalvarLocalidadeCommand>())).ReturnsAsync(new LocalidadeModel());

            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.SalvarLocalidade(new SalvarLocalidadeCommand
            {
                Id = Guid.NewGuid(),
                Cep = "14600000",
                Cidade = "São joaquim da barra",
                Estado = "SP",
                Logradouro = "teste"
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AtualizarLocalidade_DeveRetornarOk()
        {
            var loggerMock = new Mock<ILogger<LocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<AtualizarLocalidadeCommand>())).ReturnsAsync(new LocalidadeModel());

            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.AtualizarLocalidade(new AtualizarLocalidadeCommand
            {
                Id = Guid.NewGuid(),
                Cep = "14600000",
                Cidade = "São joaquim da barra",
                Estado = "SP",
                Logradouro = "teste"
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ExcluirLocalidade_DeveRetornarOk()
        {
            var loggerMock = new Mock<ILogger<LocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ExcluirLocalidadeCommand>()));

            var controller = new LocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ExcluirLocalidade(Guid.NewGuid());

            Assert.IsType<OkResult>(result);
        }
    }
}