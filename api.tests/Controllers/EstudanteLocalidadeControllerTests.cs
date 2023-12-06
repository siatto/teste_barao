using api.Application.Estudante.Command;
using api.Application.EstudanteLocalidade.Command;
using api.Controllers;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace api.tests.Controllers
{
    public class EstudanteLocalidadeControllerTests
    {
        [Fact]
        public async Task ListarTodos_DeveRetornarListaDeEstudantesLocalidades()
        {
            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ListarEstudanteLocalidadeCommand>())).ReturnsAsync(new List<EstudanteLocalidadeModel> { new EstudanteLocalidadeModel(), new EstudanteLocalidadeModel() });

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ListarTodos();

            Assert.IsType<ActionResult<IEnumerable<EstudanteLocalidadeModel>>>(result);
            var estudantesLocalidades = Assert.IsAssignableFrom<IEnumerable<EstudanteLocalidadeModel>>(result.Value);
            Assert.Equal(2, estudantesLocalidades.Count());
        }

        [Fact]
        public async Task EstudanteLocalidadePorId_DeveRetornarEstudanteLocalidadeQuandoEncontrado()
        {
            var estudanteLocalidadeId = Guid.NewGuid();
            var estudanteRetornado = new EstudanteLocalidadeModel { Id = estudanteLocalidadeId };

            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudanteLocalidadePorIdCommand>())).ReturnsAsync(estudanteRetornado);

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudanteLocalidadePorId(estudanteLocalidadeId);

            Assert.IsType<ActionResult<EstudanteLocalidadeModel>>(result);
            var estudanteLocalidade = Assert.IsType<EstudanteLocalidadeModel>(result.Value);
            Assert.Equal(estudanteLocalidadeId, estudanteLocalidade.Id);
        }

        [Fact]
        public async Task EstudanteLocalidadePorId_DeveRetornarNoContentQuandoNaoEncontrado()
        {
            var estudanteLocalidadeId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudanteLocalidadePorIdCommand>())).ReturnsAsync((EstudanteLocalidadeModel)null);

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudanteLocalidadePorId(estudanteLocalidadeId);

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task EstudanteLocalidadePorEstudante_DeveRetornarEstudanteLocalidadeQuandoEncontrado()
        {
            var estudanteLocalidadeId = Guid.NewGuid();
            var estudanteRetornado = new EstudanteLocalidadeModel { Id = estudanteLocalidadeId };

            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudanteLocalidadePorEstudanteCommand>())).ReturnsAsync(estudanteRetornado);

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudanteLocalidadePorEstudante(estudanteLocalidadeId);

            Assert.IsType<ActionResult<EstudanteLocalidadeModel>>(result);
            var estudanteLocalidade = Assert.IsType<EstudanteLocalidadeModel>(result.Value);
            Assert.Equal(estudanteLocalidadeId, estudanteLocalidade.Id);
        }

        [Fact]
        public async Task EstudanteLocalidadePorEstudante_DeveRetornarNoContentQuandoNaoEncontrado()
        {
            var estudanteId = Guid.NewGuid();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudanteLocalidadePorEstudanteCommand>())).ReturnsAsync((EstudanteLocalidadeModel)null);

            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();
            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudanteLocalidadePorEstudante(estudanteId);

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task SalvarEstudanteLocalidade_DeveRetornarOkQuandoSalvoComSucesso()
        {
            var estudanteLocalidadeServiceMock = new Mock<IEstudanteLocalidadeService>();
            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<SalvarEstudanteLocalidadeCommand>())).ReturnsAsync(new EstudanteLocalidadeModel());

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.SalvarEstudanteLocalidade(new SalvarEstudanteLocalidadeCommand
            { 
                Id = Guid.NewGuid(),
                EstudanteId = Guid.NewGuid(),
                LocalidadeId = Guid.NewGuid()
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AtualizarEstudanteLocalidade_DeveRetornarOkQuandoAtualizadoComSucesso()
        {
            var estudanteLocalidadeServiceMock = new Mock<IEstudanteLocalidadeService>();
            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<AtualizarEstudanteLocalidadeCommand>())).ReturnsAsync(new EstudanteLocalidadeModel());

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.AtualizarEstudanteLocalidade(new AtualizarEstudanteLocalidadeCommand
            {
                Id = Guid.NewGuid(),
                EstudanteId = Guid.NewGuid(),
                LocalidadeId = Guid.NewGuid()
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ExcluirEstudanteLocalidade_DeveRetornarOkQuandoExcluidoComSucesso()
        {
            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ExcluirEstudanteLocalidadeCommand>()));

            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ExcluirEstudanteLocalidade(Guid.NewGuid());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ExcluirEstudanteLocalidade_DeveRetornarInternalServerErrorQuandoErroAoExcluir()
        {
            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ExcluirEstudanteLocalidadeCommand>()))
                .ThrowsAsync(new Exception("Erro ao excluir estudante localidade"));

            var loggerMock = new Mock<ILogger<EstudanteLocalidadeController>>();
            var controller = new EstudanteLocalidadeController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ExcluirEstudanteLocalidade(Guid.NewGuid());

            Assert.IsType<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(500, objectResult.StatusCode);
        }
    }
}
