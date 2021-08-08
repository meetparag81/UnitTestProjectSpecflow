using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using UnitTestProjectSpecflow.ComponentHelper;
using UnitTestProjectSpecflow.Settings;

namespace UnitTestProjectSpecflow
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OpenURL()
        {

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

        }
        [TestMethod]
        public void Appconfig()
        {

            Console.WriteLine(ConfigurationManager.AppSettings.Get("Browser"));

        }
    }
}
