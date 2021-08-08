
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSpecflow.ComponentHelper;
using UnitTestProjectSpecflow.Configuration;
using UnitTestProjectSpecflow.CustomExceptions;
using UnitTestProjectSpecflow.Settings;

namespace UnitTestProjectSpecflow.BaseClasses
{
    [TestClass]
    class BaseClass
    {
        private static readonly bool headless = true;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        private static ChromeOptions GetChromeOption()
        {
            ChromeOptions opts = new ChromeOptions();
            if (headless == false)
            {
                opts.AddArgument("--headless");
            }
            opts.AddArgument("start-maximized");

            return opts;
        }

        private static InternetExplorerOptions GetInternetExplorerOption()
        {
            InternetExplorerOptions opts = new InternetExplorerOptions();
            opts.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            opts.IgnoreZoomLevel = true;
            opts.EnsureCleanSession = true;


            return opts;
        }
        private static FirefoxProfile FirefoxProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("default");


            return profile;
        }

        private static IWebDriver GetChromedriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOption());
            return driver;
        }

        private static IWebDriver GetFirefoxdriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }

        private static IWebDriver GetInternetExplorerdriver()
        {
            IWebDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver(GetInternetExplorerOption());
            return driver;
        }
        [AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)

        {
            ObjectRepository.Config = new AppConfigReader();
            //Reporter.GetReportManager();
            //Reporter.AddTestCaseMetadataToHtmlReport(tc);
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.driver = GetFirefoxDriver();
                    Logger.Info(" Using Firefox Driver  ");

                    break;

                case BrowserType.Chrome:
                    ObjectRepository.driver = GetChromeDriver();
                    Logger.Info(" Using Chrome Driver  ");
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.driver = GetIEDriver();
                    Logger.Info(" Using Internet Explorer Driver  ");
                    break;                

                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.driver.Manage()
                .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            BrowserHelper.BrowserMaximize();
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }
       
        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless");
            //option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
            Logger.Info(" Using Chrome Options ");
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            Logger.Info(" Using Internet Explorer Options ");
            return options;
        }
        private static FirefoxOptions GetFirefoxptions()
        {
            FirefoxOptions opts = new FirefoxOptions();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            //profile = manager.GetProfile("default");
            Logger.Info(" Using Firefox Profile ");
            return opts;
        }


        




        [AssemblyCleanup]
        public static void Teardown()
        {
            ObjectRepository.driver.Quit();
        }

    }
}
