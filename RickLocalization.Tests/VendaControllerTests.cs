using AutoMapper;
using RickLocalization.Domain;
using RickLocalization.Repository;
using RickLocalization.Repository.Data;
using RickLocalization.WebApi.Controllers;
using RickLocalization.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace RickLocalization.Tests
{

    public class VendaControllerTests : BaseControllerTests
    {
        private readonly ILogger<VendaController> _logger;
        private readonly Venda _venda;
        private readonly List<Venda> _vendas = new List<Venda>();
        private readonly MapperConfiguration _mockMapper;

        public VendaControllerTests()
            : base(
                 new DbContextOptionsBuilder<VendasContext>()
                .UseSqlServer("Data Source=NOTEPESSOAL;Initial Catalog=BD2;Integrated Security=True;")
                //.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options)
        {
            var listaPedido1 = new List<Pedido>() { new Pedido() };

            var venda1 = new Venda(listaPedido1);
            _venda = venda1;
            _vendas.Add(venda1);

            _mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
        }

        [Fact]
        public void Get_Venda_DeveRetornarNotNull()
        {
            //Arrange Repository
            Mock<IVendaRepository> mockRepo = new Mock<IVendaRepository>();
            mockRepo.Setup(m => m.GetAsync(It.IsAny<bool>())).ReturnsAsync(_vendas.ToArray);

            var mapper = _mockMapper.CreateMapper();

            var controller = new VendaController(mockRepo.Object, mapper);
            //Act
            var result = controller.Get();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_VendaPorId_DeveRetornarNotNull()
        {
            //Arrange Repository
            Mock<IVendaRepository> mockRepo = new Mock<IVendaRepository>();
            mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(_venda);

            var mapper = _mockMapper.CreateMapper();

            var controller = new VendaController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetById(100000);

            //Assert
            Assert.NotNull(result);
        }




    }
}
