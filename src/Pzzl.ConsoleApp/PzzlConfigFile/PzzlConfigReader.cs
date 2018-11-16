using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Pzzl.ConsoleApp.PzzlConfigFile
{
    public class PzzlConfigReader
    {
        public static PlzzConfig Read(string path)
        {
            var content = File.ReadAllText(path);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            return deserializer.Deserialize<PlzzConfig>(content);
        }
    }
}