using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ovchinn
{
    class Logger
    {
        public void LoggerStart()
        {
           
            var builder = new ConfigurationBuilder();
            IConfiguration configuration = BuildConfig(builder);
            
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
            
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

       

        static IConfiguration BuildConfig(IConfigurationBuilder builder)
        {
            return
            builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appconfig.json", optional: false, reloadOnChange: true)
            .Build();
        }

       
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception unhandledException = (Exception)e.ExceptionObject;
            Log.Error(unhandledException, "Необработанное исключение");
        }
    }
}
