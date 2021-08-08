using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSpecflow.Settings;

namespace UnitTestProjectSpecflow.ComponentHelper
{
    class NavigationHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(NavigationHelper));
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.driver.Navigate().GoToUrl(Url);
            Logger.Info(" Navigate To Page " + Url);
        }
    }
}
