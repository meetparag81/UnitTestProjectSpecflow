using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject2.BaseClass;

namespace UnitTestProject2.Pages
{
    public class HomePage : TestBase
    {
        [FindsBy(How = How.PartialLinkText, Using = "passwd")]
        private IWebElement forgotpasswordlink;

        private IWebDriver Driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
        }


        public bool Isforgotfasswordlink()
        {
            return forgotpasswordlink.Displayed;
            
        }
    }
}
