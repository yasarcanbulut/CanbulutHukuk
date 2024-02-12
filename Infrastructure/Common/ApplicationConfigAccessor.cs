using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace CanbulutHukuk.Infrastructure.Common
{
    public static class ApplicationConfigAccessor
    {
        public static ApplicationConfig config;

        public static void Initialize(ApplicationConfig cfg)
        {
            config = cfg;
        }

        public static void Initialize(string filename)
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);

            string file = directory + "\\" + filename;
            if (File.Exists(file))
            {
                string sJson = File.ReadAllText(file, Encoding.UTF8);
                config = JsonConvert.DeserializeObject<ApplicationConfig>(sJson);
            }
        }
    }
}
