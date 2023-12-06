using api.Application.Estudante.Command;
using api.Controllers;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace api.tests.Controllers
{
    public class EstudanteControllerTests
    {
        [Fact]
        public async Task ListarTodos_DeveRetornarListaDeEstudantes()
        {
            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ListarEstudantesCommand>())).ReturnsAsync(new List<EstudanteModel> { new EstudanteModel(), new EstudanteModel() });

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ListarTodos();

            Assert.IsType<ActionResult<IEnumerable<EstudanteModel>>>(result);
            var estudantes = Assert.IsAssignableFrom<IEnumerable<EstudanteModel>>(result.Value);
            Assert.Equal(2, estudantes.Count());
        }

        [Fact]
        public async Task EstudantePorId_DeveRetornarEstudanteQuandoEncontrado()
        {
            var estudanteId = Guid.NewGuid();
            var estudanteRetornado = new EstudanteModel { Id = estudanteId, NomeCompleto = "Teste" };

            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudantePorIdCommand>())).ReturnsAsync(estudanteRetornado);

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudantePorId(estudanteId);

            Assert.IsType<ActionResult<EstudanteModel>>(result);
            var estudante = Assert.IsType<EstudanteModel>(result.Value);
            Assert.Equal(estudanteId, estudante.Id);
        }

        [Fact]
        public async Task EstudantePorId_DeveRetornarNoContentQuandoNaoEncontrado()
        {
            var estudanteId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudantePorIdCommand>())).ReturnsAsync((EstudanteModel)null);

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudantePorId(estudanteId);

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task EstudantePorNome_DeveRetornarListaDeEstudantesQuandoEncontrados()
        {
            var nome = "Teste";
            var estudanteRetornado = new List<EstudanteModel> { new EstudanteModel { NomeCompleto = nome } };

            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EstudantePorNomeCommand>())).ReturnsAsync(estudanteRetornado);

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.EstudantePorNome(nome);

            Assert.IsType<ActionResult<IEnumerable<EstudanteModel>>>(result);
            var estudantes = Assert.IsAssignableFrom<IEnumerable<EstudanteModel>>(result.Value);
            Assert.Single(estudantes);
        }

        [Fact]
        public async Task SalvarEstudante_DeveRetornarOkQuandoSalvoComSucesso()
        {
            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<SalvarEstudanteCommand>())).ReturnsAsync(new EstudanteModel());

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.SalvarEstudanteAsync(new SalvarEstudanteCommand
            {
                Id = Guid.NewGuid(),
                NomeCompleto = "Fernando Silva de Britto",
                DataNascimento = new DateTime(1987, 3, 21),
                Localidade = null
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AtualizarEstudante_DeveRetornarOkQuandoAtualizadoComSucesso()
        {
            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<AtualizarEstudanteCommand>())).ReturnsAsync(new EstudanteModel());

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.AtualizarEstudante(new AtualizarEstudanteCommand
            {
                Id = Guid.NewGuid(),
                NomeCompleto = "Fernando Silva de Britto",
                DataNascimento = new DateTime(1987, 3, 21),
                Localidade = null
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ExcluirEstudante_DeveRetornarOkQuandoExcluidoComSucesso()
        {
            var loggerMock = new Mock<ILogger<EstudanteController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ExcluirEstudanteCommand>()));

            var controller = new EstudanteController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ExcluirEstudante(Guid.NewGuid());

            Assert.IsType<OkResult>(result);
        }
    }
}