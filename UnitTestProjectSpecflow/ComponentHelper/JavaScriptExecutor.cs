using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProjectSpecflow.Settings;

namespace UnitTestProjectSpecflow.ComponentHelper
{
    class JavaScriptExecutor
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(JavaScriptExecutor));
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.driver);
            Logger.Info($" Execute Script @ {script}");
            return executor.ExecuteScript(script);

        }

        public static object ExecuteScript(string script, params object[] args)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.driver);
            return executor.ExecuteScript(script, args);
        }

        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToAndClick(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }


    }
}
