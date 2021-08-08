using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject2.BaseClass;
using UnitTestProject2.Pages;


namespace UnitTestProject2.PagesObjects
{
    public class LoginPage:TestBase



    {
        private IWebDriver driver;
        [FindsBy(How = How.Id, Using = "email")]
        private  IWebElement Username;
        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement Password;
        
        [FindsBy(How = How.PartialLinkText, Using = "Sign in")]
        private IWebElement LoginLink;
        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement loginbutton;
        

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        

        public HomePage LoginToPage(string username,string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            loginbutton.Click();
            return new HomePage(driver);
        }
        public void ClickonTheLogin()
        {
            LoginLink.Click();
        }


        

    
    }
}
