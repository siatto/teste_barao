using api.Controllers;
using api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace api.tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> authServiceMock;
        private readonly Mock<ILogger<AuthController>> loggerMock;
        private readonly AuthController authController;

        public AuthControllerTests()
        {
            authServiceMock = new Mock<IAuthService>();
            loggerMock = new Mock<ILogger<AuthController>>();
            authController = new AuthController(authServiceMock.Object, loggerMock.Object);
        }

        [Fact]
        public void Login_DeveRetornarToken()
        {
            var login = "usuario";
            var senha = "senha";
            var tokenMock = "token_mock";

            authServiceMock.Setup(x => x.GerarToken(login, senha)).Returns(tokenMock);

            var result = authController.Login(login, senha);

            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var tokenProperty = okObjectResult.Value.GetType().GetProperty("Token");
            var tokenValue = tokenProperty.GetValue(okObjectResult.Value, null);

            Assert.Equal(tokenMock, tokenValue);
        }

        [Fact]
        public void Login_DeveRetornarUnauthorizedQuandoTokenNaoGerado()
        {
            var login = "usuario";
            var senha = "senha";

            authServiceMock.Setup(x => x.GerarToken(login, senha)).Returns(string.Empty);

            var result = authController.Login(login, senha);

            Assert.NotNull(result.Result);
            Assert.IsType<UnauthorizedResult>(result.Result);
        }
    }
}