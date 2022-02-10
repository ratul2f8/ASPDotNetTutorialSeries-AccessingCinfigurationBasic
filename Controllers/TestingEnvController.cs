using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tutorial2.Configs;

namespace Tutorial2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestingEnvController : ControllerBase
    {
       
        private readonly IConfiguration _configuration;
        private readonly IOptions<DbConfig> _dbConfig;

        public TestingEnvController(IConfiguration configuration, IOptions<DbConfig> dbConfig)
        {
            
            _configuration = configuration;
            _dbConfig = dbConfig;
        }


        [HttpGet("/getenv")]
        public async Task<String> GetEnv()
        {
            return _configuration["TestingEnv"];
        }
        [HttpGet("/getnestedenv")]
        public async Task<String> GetNestedEnv()
        {
            return _configuration["Tom:Milk:Brand"];
        }
        [HttpGet("/getbindedenv")]
        public async Task<DbConfig> GetBindedEnv()
        {
            DbConfig dbConfig = new DbConfig();
            _configuration.GetSection("Database").Bind(dbConfig);
            return dbConfig;
        }
        [HttpGet("/getinjected")]
        public async Task<DbConfig> GetInjectedEnv()
        {
            
            return _dbConfig.Value;
        }

    }
}