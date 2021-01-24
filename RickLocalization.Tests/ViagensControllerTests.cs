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

    public class ViagensControllerTests : BaseControllerTests
    {
        private readonly ILogger<ViagemController> _logger;
        private readonly Venda _venda;
        private readonly List<Venda> _vendas = new List<Venda>();
        private readonly MapperConfiguration _mockMapper;

        private Personagem _personagem;
        private Dimensao _personagemDimensao;
        private Dimensao _origem;
        private Dimensao _destino;
        private Viagem _viagem;
        private readonly List<Viagem> _viagens;

        public ViagensControllerTests()
            : base(
                 new DbContextOptionsBuilder<RickLocalizationContext>()
                .UseSqlServer("Data Source=NOTEPESSOAL;Initial Catalog=BD2;Integrated Security=True;")
                //.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options)
        {
                        
            _viagens = new List<Viagem>()
            {
                new Viagem(1, new Personagem(1, "Ricky",new Dimensao(1, "C-130"),"http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg"),new Dimensao(1, "C-130"),new Dimensao(2, "C-131")),
                new Viagem(2, new Personagem(1, "Ricky",new Dimensao(1, "C-131"),"http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg"),new Dimensao(1, "C-131"),new Dimensao(2, "C-132")),
                new Viagem(3, new Personagem(1, "Ricky",new Dimensao(1, "C-130"),"http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg"),new Dimensao(1, "C-130"),new Dimensao(2, "C-132")),
            };           


            _mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
        }        

        [Fact]
        public void Get_ViagemPorParametros_DeveRetornarNotNull()
        {
            //Arrange Repository
            Mock<IViagemRepository> mockRepo = new Mock<IViagemRepository>();
            mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(_viagens.ToArray);

            var mapper = _mockMapper.CreateMapper();

            var controller = new ViagemController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetById(1,"C-130",true);

            //Assert
            Assert.NotNull(result);
        }

    }
}
