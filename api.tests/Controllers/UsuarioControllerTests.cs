using api.Application.Estudante.Command;
using api.Application.Usuario.Command;
using api.Controllers;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace api.tests.Controllers
{
    public class UsuarioControllerTests
    {
        [Fact]
        public async Task ListarTodos_DeveRetornarListaDeUsuarios()
        {
            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ListarUsuarioCommand>())).ReturnsAsync(new List<UsuarioModel> { new UsuarioModel { Senha = "123"}, new UsuarioModel {Senha = "321" } });

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ListarTodos();

            Assert.IsType<ActionResult<IEnumerable<UsuarioModel>>>(result);
            var usuarios = Assert.IsAssignableFrom<IEnumerable<UsuarioModel>>(result.Value);
            Assert.Equal(2, usuarios.Count());
        }

        [Fact]
        public async Task UsuarioPorId_DeveRetornarUsuarioQuandoEncontrado()
        {
            var usuarioId = Guid.NewGuid();
            var usuarioRetornado = new UsuarioModel { Id = usuarioId, Login = "Teste", Senha = "123" };

            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<UsuarioPorIdCommand>())).ReturnsAsync(usuarioRetornado);

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.UsuarioPorId(usuarioId);

            Assert.IsType<ActionResult<UsuarioModel>>(result);
            var usuario = Assert.IsType<UsuarioModel>(result.Value);
            Assert.Equal(usuarioId, usuario.Id);
        }

        [Fact]
        public async Task UsuarioPorId_DeveRetornarNoContentQuandoUsuarioNaoEncontrado()
        {
            var usuarioId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<UsuarioPorIdCommand>())).ReturnsAsync((UsuarioModel)null);

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.UsuarioPorId(usuarioId);

            Assert.IsType<ActionResult<UsuarioModel>>(result);
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task UsuarioPorLoginSenha_DeveRetornarUsuarioQuandoEncontrado()
        {
            var login = "USUARIO_TESTE";
            var senha = "senha_teste";
            var usuarioRetornado = new UsuarioModel { Login = login, Senha = senha };

            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<UsuarioPorLoginSenhaCommand>())).ReturnsAsync(usuarioRetornado);

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.UsuarioPorLoginSenha(login, senha);

            Assert.IsType<ActionResult<UsuarioModel>>(result);
            var usuario = Assert.IsType<UsuarioModel>(result.Value);
            Assert.Equal(login, usuario.Login);
        }

        [Fact]
        public async Task UsuarioPorLoginSenha_DeveRetornarNoContentQuandoUsuarioNaoEncontrado()
        {
            var login = "usuario_teste";
            var senha = "senha_teste";

            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<UsuarioPorLoginSenhaCommand>())).ReturnsAsync((UsuarioModel)null);

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.UsuarioPorLoginSenha(login, senha);

            Assert.IsType<ActionResult<UsuarioModel>>(result);
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task SalvarUsuario_DeveRetornarOk()
        {
            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<SalvarUsuarioCommand>())).ReturnsAsync(new UsuarioModel { Senha = "123"});

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.SalvarUsuario(new SalvarUsuarioCommand
            {
                Id = Guid.NewGuid(),
                Login = "Fernando",
                Senha = "123"
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AtualizarUsuario_DeveRetornarOk()
        {
            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<AtualizarUsuarioCommand>())).ReturnsAsync(new UsuarioModel { Senha = "123"});

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.AtualizarUsuario(new AtualizarUsuarioCommand
            {
                Id = Guid.NewGuid(),
                Login = "Fernando",
                Senha = "123"
            });

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ExcluirUsuario_DeveRetornarOk()
        {
            var loggerMock = new Mock<ILogger<UsuarioController>>();

            var mediatorMock = new Mock<IMediatorService>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ExcluirUsuarioCommand>()));

            var controller = new UsuarioController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.ExcluirUsuario(Guid.NewGuid());

            Assert.IsType<OkResult>(result);
        }
    }
}