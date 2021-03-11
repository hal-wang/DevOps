using HTools;
using Microsoft.Extensions.Configuration;

namespace DevOps
{
    public class ConfigHelper
    {
        private IConfiguration _configuration;

        public void Init(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static ConfigHelper Instance { get; } = new ConfigHelper();

        public T Get<T>(string str)
        {
            return _configuration[str].GetValue<T>();
        }
    }
}
