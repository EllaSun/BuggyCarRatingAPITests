using Microsoft.Extensions.Configuration;
using System;

namespace BuggyCarRating.APItests
{
    public static class ConfigHelper
    {
        /// <summary>
        /// Return value of given key in appsetting.json file
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        /// <exception cref="Exception">No appsetting file</exception>
        public static string GetAppSetting(string key)
        {
            if (key == null) return "";

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            if (config == null) throw new Exception("Cannot find config file : appsettings.json!");

            string url = config.GetSection("BaseUrl").Value;
            return url;
          
           
        }
    }

}

