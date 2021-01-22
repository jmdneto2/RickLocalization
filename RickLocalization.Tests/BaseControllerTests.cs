using AutoMapper;
using RickLocalization.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RickLocalization.Tests
{
    public class BaseControllerTests
    {
        protected DbContextOptions<VendasContext> ContextOptions { get; }
        public IConfiguration Configuration { get; }
        private readonly ILogger<BaseControllerTests> _logger;
        public IMapper mapper;

        //public BaseControllerTests(ILogger<BaseControllerTests> logger, DbContextOptions<VendasContext> contextOptions, IWebHostEnvironment env)
        //public BaseControllerTests(DbContextOptions<VendasContext> contextOptions, IWebHostEnvironment env)
        public BaseControllerTests(DbContextOptions<VendasContext> contextOptions)
        {

            var builder = new ConfigurationBuilder()
                  //.SetBasePath(env.ContentRootPath)
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings.Development.json", optional: true)
                  .AddJsonFile($"appsettings.Production.json", optional: true)
                  .AddEnvironmentVariables();

            Configuration = builder.Build();
            ContextOptions = contextOptions;
            //mapper = _mapper;
        }
    }
}
