using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSpecflow.CustomExceptions;
using UnitTestProjectSpecflow.Interfaces;
using UnitTestProjectSpecflow.Settings;

namespace UnitTestProjectSpecflow.Configuration
{
    public class AppConfigReader : Iconfig
    {



        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.url);
        }

        public BrowserType GetBrowser()
        {
            string browsername = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browsername);
            }
            catch
            {
                throw new NoSuitableDriverFound("Driver is not found :" + ObjectRepository.Config.GetBrowser().ToString());
            }
        }
    }
}
