using System.Collections.Generic;

namespace Birds.Models
{
    public sealed class Configuration
    {
        private readonly Dictionary<string, string> connectionStrings;

        public Configuration()
        {
            connectionStrings = new Dictionary<string, string>
            {
                {
                    "BirdsDb",
                    "mongodb://localhost:27017"
                }
            };
        }

        public string GetConnectionString(string name)
        {
            return connectionStrings[name];
        }
    }
}