using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace MessageManager
{
    public static class Config
    {
        // se instala Microsoft.Extensions.Configuration.Json
        private static IConfiguration configuration;
        static Config()
        {

            string basePath01 = System.AppContext.BaseDirectory;
            string basePath02 = Directory.GetCurrentDirectory();
            string basePath03 = System.IO.Directory.GetCurrentDirectory();
            string basePath04 = Environment.CurrentDirectory;
            string basePath05 = System.IO.Path.GetFullPath(@"..\..\..\");

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath05)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string Get(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }

        public static DirectoryInfo GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.AbsolutePath).Directory;
        }

        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.AbsolutePath).Directory.FullName;
        }
    }
}
