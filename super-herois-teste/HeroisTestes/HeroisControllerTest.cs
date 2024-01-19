using Microsoft.AspNetCore.Mvc;
using Moq;
using super_herois_api.Controllers;
using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;
using super_herois_api.Exceptions;
using super_herois_api.Services;

namespace super_herois_teste.HeroisTestes
{
    public class HeroisControllerTest
    {
        private readonly HeroisController _controller;
        private readonly Mock<IServiceBase<Herois, HeroisDTO>> _mockService;

        public HeroisControllerTest()
        {
            _mockService = new Mock<IServiceBase<Herois, HeroisDTO>>();
            _controller = new HeroisController(_mockService.Object);
        }
        
        private readonly List<Herois> herois = new()
        {
            new Herois(1, "Batman", "Batman", new DateTime(1939, 5, 1), 1.88, 95),
            new Herois(2, "Superman", "Superman", new DateTime(1938, 6, 1), 1.91, 107),
        };

        private readonly HeroisDTO heroiDto = new(1, "Batman", "Batman", new DateTime(1939, 5, 1), 1.88, 95, new List<Superpoderes>());

        [Fact]
        public void GetTestOk()
        {
            _mockService.Setup(service => service.Listar()).Returns(herois);

            var result = _controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var heroes = Assert.IsAssignableFrom<IEnumerable<Herois>>(okResult.Value);
            Assert.Equal(2, heroes.Count());
        }

        [Fact]
        public void GetTestFail()
        {
            _mockService.Setup(service => service.Listar()).Returns(new List<Herois>());

            var result = _controller.Get();

            var notFoundResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTestExcepetion()
        {
            _mockService.Setup(service => service.Listar()).Throws(new Exception());

            var result = _controller.Get();

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public void GetIdTestOk()
        {
            _mockService.Setup(service => service.Buscar(1)).Returns(heroiDto);

            var result = _controller.Get(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var heroi = Assert.IsAssignableFrom<HeroisDTO>(okResult.Value);
            Assert.Equal(1, heroi.Id);
        }

        [Fact]
        public void GetIdTestFail()
        {
            _mockService.Setup(service => service.Buscar(1)).Returns((HeroisDTO)null);

            var result = _controller.Get(1);

            var notFoundResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetIdTestBadRequest()
        {
            _mockService.Setup(service => service.Buscar(1)).Throws(new HeroisExcepetion(""));

            var result = _controller.Get(1);

            var badRequestResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetIdTestExcepetion()
        {
            _mockService.Setup(service => service.Buscar(1)).Throws(new Exception());

            var result = _controller.Get(1);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        
        [Fact]
        public void PostTestOk()
        {
            _mockService.Setup(service => service.Inserir(heroiDto)).Returns(herois[0]);

            var result = _controller.Post(heroiDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var heroi = Assert.IsAssignableFrom<Herois>(okResult.Value);
            Assert.Equal(1, heroi.Id);
        }

        [Fact]
        public void PostTestBadRequest()
        {
            _mockService.Setup(service => service.Inserir(heroiDto)).Throws(new HeroisExcepetion(""));

            var result = _controller.Post(heroiDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostTestExcepetion()
        {
            _mockService.Setup(service => service.Inserir(heroiDto)).Throws(new Exception());

            var result = _controller.Post(heroiDto);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public void PutTestOk()
        {
            _mockService.Setup(service => service.Atualizar(1, heroiDto)).Returns(herois[0]);

            var result = _controller.Put(1, heroiDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var heroi = Assert.IsAssignableFrom<HeroisDTO>(okResult.Value);
            Assert.Equal(1, heroi.Id);
        }

        [Fact]
        public void PutTestBadRequest()
        {
            _mockService.Setup(service => service.Atualizar(1, heroiDto)).Throws(new HeroisExcepetion(""));

            var result = _controller.Put(1, heroiDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PutTestExcepetion()
        {
            _mockService.Setup(service => service.Atualizar(1, heroiDto)).Throws(new Exception());

            var result = _controller.Put(1, heroiDto);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public void DeleteTestOk()
        {
            _mockService.Setup(service => service.Deletar(1)).Returns(herois[0]);

            var result = _controller.Delete(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DeleteTestBadRequest()
        {
            _mockService.Setup(service => service.Deletar(1)).Throws(new HeroisExcepetion(""));

            var result = _controller.Delete(1);

            var badRequestResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteTestExcepetion()
        {
            _mockService.Setup(service => service.Deletar(1)).Throws(new Exception());

            var result = _controller.Delete(1);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}