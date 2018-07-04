using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Crayons.Communication.Extensions
{
    public static class RabbitMqConfigurationExtension
    {
        private static string rabbitMqSectionName = "RawRabbit";
       
        public static IConfigurationSection GetRabbitMqConfigurationSection(this IConfiguration configuration)
        {
            var section = configuration.GetSection(rabbitMqSectionName);
            EnsureSpecificSectionExists(section, rabbitMqSectionName);
            
            return section;
        }

        private static void EnsureSpecificSectionExists(IConfigurationSection section, string sectionName)
        {
            if (!section.GetChildren().Any())
			{
				throw new ArgumentException($"Unable to configuration section '{sectionName}'. Make sure it exists in the provided configuration");
			}
        }
    }
}