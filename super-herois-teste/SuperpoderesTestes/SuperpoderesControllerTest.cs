using Microsoft.AspNetCore.Mvc;
using Moq;
using super_herois_api.Controllers;
using super_herois_api.Domain.Models;
using super_herois_api.Services;

namespace super_herois_teste.SuperpoderesTestes
{
    public class SuperpoderesControllerTest
    {
        private readonly SuperpoderesController _controller;
        private readonly Mock<IServiceBase<Superpoderes, Superpoderes>> _service;
        public SuperpoderesControllerTest()
        {
            _service = new Mock<IServiceBase<Superpoderes, Superpoderes>>();
            _controller = new SuperpoderesController(_service.Object);
        }

        private static Superpoderes GetSuperpoderes()
        {
            return new Superpoderes(1, "Super Força", "Força sobre humana");
        }

        [Fact]
        public void Get_QuandoChamado_DeveRetornarOk()
        {
            // Arrange
            _service.Setup(x => x.Listar()).Returns(new List<Superpoderes>());

            // Act
            var retorno = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void Get_QuandoChamado_DeveRetornarBadRequest()
        {
            // Arrange
            _service.Setup(x => x.Listar()).Throws(new Exception());

            // Act
            var retorno = _controller.Get();

            // Assert
            Assert.IsType<BadRequestObjectResult>(retorno);
        }

        [Fact]
        public void GetId_QuandoChamado_DeveRetornarOk()
        {
            // Arrange
            _service.Setup(x => x.Buscar(1)).Returns(GetSuperpoderes());

            // Act
            var retorno = _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void GetId_QuandoChamado_DeveRetornarBadRequest()
        {
            // Arrange             // Arrange
            _service.Setup(x => x.Buscar(1)).Throws(new Exception());
            // Act
            var retorno = _controller.Get(1);
            // Assert
            Assert.IsType<BadRequestObjectResult>(retorno);
        }
    }
}