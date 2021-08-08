using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnitTestProject2.ComponentHelper;

namespace UnitTestProject2.BaseClass
{
   public  class TestBase




    {
        private  WebDriverWait wait;
        private  IWebDriver driver;

        public static string hireLastName { get; set; }
        public static string hirePerNer { get; set; }
        public static string compCode { get; set; }
        public static string env { get; set; }
       

        public TestBase(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constant.WEBDRIVER_TIMEOUT);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constant.WEBDRIVER_TIMEOUT));

        }

        [FindsBy(How = How.Id, Using = "sfLoadBlockerLayer")]
        public IWebElement Loader;


        public void SelectBox(IWebElement item)
        {
            WaitForClickable(item);
            if (!item.Selected)
            {
                item.Click();
            }
        }

        public void UnSelectBox(IWebElement item)
        {
            WaitForClickable(item);
            if (item.Selected)
            {
                item.Click();
            }
        }

        public void refreshbrowser()
        {
            driver.Navigate().Refresh();
            waitforPageLoad();
        }

        public void clickusingJavaScript(IWebElement element)

        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public Boolean IsElementExists(IWebElement element)
        {
            Boolean result = false; ;
            try
            {
                if (element.Displayed)
                    result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public Boolean IsElementEnabled(IWebElement element)
        {
            Boolean result = false; ;
            try
            {
                if (element.Enabled)
                    result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void HandleBox(IWebElement item, Boolean selected)
        {
            WaitForClickable(item);
            if (selected)
            {
                SelectBox(item);
            }
            else
            {
                UnSelectBox(item);
            }
        }

        public void SelectByText(IWebElement selElement, String text)
        {
            WaitForClickable(selElement);
            SelectElement item = new SelectElement(selElement);
            item.SelectByText(text);
        }



        public void SelectByValue(IWebElement selElement, String value)
        {
            WaitForClickable(selElement);
            SelectElement item = new SelectElement(selElement);
            item.SelectByValue(value);
        }

        public void EnterText(IWebElement input, String text)
        {
            try
            {
                if (text == null || text.Equals(""))
                    return;
                WaitForClickable(input);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value =''; ", input);
                //input.Clear();
                if (text.Equals("NULL"))
                    return;
                input.SendKeys(text);
            }
            catch (Exception)
            {
                input.SendKeys(text);
            }

        }

        public void Click(IWebElement elem)
        {
            WaitForClickable(elem);
            elem.Submit();

        }
        public void Clear(IWebElement elem)
        {
            WaitForClickable(elem);
            elem.Clear();
        }

        public void Close()
        {
            driver.Dispose();
        }

        public void ExecuteJavaScript(String scriptToExecute, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(scriptToExecute, element);
        }

        public void SpecialClick(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Click().Build().Perform();
        }

        public void hover(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
        }

        public void changeWait(int waitTime)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);
        }
        public void resetWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constant.WEBDRIVER_TIMEOUT);
        }

        public void WaitForClickable(IWebElement element)
        {

        }


        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public void waitforPageLoad()
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 2, 0));
            //wait.Until(driver => js.ExecuteScript("return document.readyState").ToString() == "complete");
            try
            {
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100.00));
                wait.IgnoreExceptionTypes(typeof(TimeoutException), typeof(StaleElementReferenceException));
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Task.Delay(500).Wait();
            }
        }

        public void SelectFromDropDown(IWebElement element, String sValue)
        {
            if (element != null && element.Enabled)
            {
                SelectElement dropdown = new SelectElement(element);
                String content = element.Text;
                if (!content.Equals(sValue))
                    dropdown.SelectByText(sValue);
            }
        }

        public String GetValueFromTextBox(IWebElement element)
        {
            string ActualText;
            if (element != null)
            {
                String content = element.GetAttribute("value");
                ActualText = content;
            }
            else
                ActualText = null;
            return ActualText;
        }

        public String GetTitle(IWebElement element)
        {
            string ActualText;
            if (element != null)
            {
                String content = element.GetAttribute("title");
                ActualText = content;
            }
            else
                ActualText = null;
            return ActualText;
        }


        public void SendKeyPressToElement(IWebElement elm, String Key)
        {
            if (elm != null)
            {
                WaitForClickable(elm);
                if (Key.Equals("ENTER"))
                {
                    try
                    {
                        elm.SendKeys(Keys.Enter);
                    }
                    catch (Exception e)
                    {
                        if (e is TargetInvocationException || e is WebDriverException)
                        {
                            Task.Delay(500).Wait();
                        }
                    }
                }
                else if (Key.Equals("TAB"))
                {
                    elm.SendKeys(Keys.Tab);
                }
                else if (Key.Equals("DOWN"))
                {
                    elm.SendKeys(Keys.Down);
                }
                else if (Key.Equals("DEL"))
                {
                    elm.SendKeys(Keys.Delete);
                }
                else if (Key.Equals("PGDN"))
                {
                    elm.SendKeys(Keys.PageDown);
                }
            }
        }

        public string GetText(IWebElement element)
        {
            string content = null;
            if (element != null)
                try
                {
                    content = element.Text;
                }
                catch (Exception e)
                {
                    if (e is TargetInvocationException || e is StaleElementReferenceException || e is NullReferenceException)
                    {
                        Task.Delay(1000).Wait();
                    }
                }
            return content;
        }

        public void selectElementfromDropDownContains(IWebElement element, string sValue)
        {
            IList<IWebElement> sOptions;
            string content = element.Text;
            SelectElement dropdown = new SelectElement(element);
            sOptions = dropdown.Options;
            foreach (IWebElement s in sOptions)
            {
                if (s.Text.Contains(sValue) && !sValue.Contains(content))
                {
                    dropdown.SelectByText(s.Text);
                    element.SendKeys(Keys.Enter);
                }
            }
        }

        public List<string> GetTableText(IWebElement element)
        {
            string rowText = "";
            List<String> sElementText = new List<string>();
            IList<IWebElement> child = FindChildren(element);
            if (child != null)
            {
                foreach (IWebElement webElement in child)
                {
                    rowText = webElement.Text.Trim();
                    if (rowText != null)
                    {
                        sElementText.Add(rowText);
                    }
                }
            }
            return sElementText;
        }

        public void setAttribute(IWebElement element, String attributeName, String attributeValue)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",
                    element, attributeName, attributeValue);
        }

        public IList<IWebElement> FindChildren(IWebElement element)
        {
            IList<IWebElement> children = element.FindElements(By.TagName("tr"));
            return children;
        }

        public IWebElement GetTableRow(IWebElement element, String expected)
        {
            string rowText = "";
            IWebElement tableObject = null;
            List<String> sElementText = new List<string>();
            IList<IWebElement> child = FindChildren(element);
            if (child != null)
            {
                foreach (IWebElement webElement in child)
                {
                    rowText = webElement.Text.Trim();
                    if (rowText.ToUpper().Contains(expected.Trim().ToUpper()))
                    {
                        tableObject = webElement;
                        break;
                    }
                }
            }
            return tableObject;
        }

        public IWebElement GetLastTableRow(IWebElement element)
        {
            IWebElement tableObject = null;
            List<String> sElementText = new List<string>();
            IList<IWebElement> child = FindChildren(element);
            if (child != null)
            {
                int size = child.Count;
                do
                {
                    size--;
                    tableObject = child[size];
                } while ((child[size].Text.Contains("Canceled")));

            }
            return tableObject;
        }

        public void acceptAlert()
        {
           
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }

        public void dismissAlert()
        {

        }

        public void VerifyTableText(IWebElement element, string sText)
        {
            string sElementText = null;
            sText = sText.Trim().ToUpper();
            bool bFound = false;
            IList<IWebElement> child = findChildren(element);
            if (child != null)
            {
                foreach (IWebElement webElement in child)
                {
                    sElementText = webElement.Text.Trim().ToUpper();
                    if (sElementText.Contains(sText.Trim()))
                    {
                        bFound = true;
                        break;
                    }
                }
            }
            Assert.IsTrue(bFound, "Expected text: " + sText + " Table contents: " + element.Text);
        }

        public IList<IWebElement> findChildren(IWebElement element)
        {

            IList<IWebElement> children = element.FindElements(By.TagName("tr"));
            return children;
        }

        public bool isAlertPresent()
        {
            return true;
        }

        public void VerifyreadOnly(IWebElement element)
        {
            Assert.AreEqual(element.GetAttribute("aria-readonly"), "true");
        }

        public void VerifyreadOnlywithreadonly(IWebElement element)
        {
            Assert.AreEqual(element.GetAttribute("readonly"), "true");
        }

        public void VerifyTextPresent(IWebElement elm, string sExpected)
        {
            //sExpected = sExpected.Trim().ToUpper();
            string sActual = GetText(elm);
            Assert.IsTrue(sActual.Contains(sExpected), "Verify Text '" + sActual + "' contains '" + sExpected + "'");
        }

        public void WaitForjQuerytoLoad()
        {
            //waitforPageLoad();
            /*working*/
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 20));
            //IWait<IWebDriver> wait = new WebDriverWait(driver, new TimeSpan(0, 1,20));
            try
            {
                wait.IgnoreExceptionTypes(typeof(TimeoutException), typeof(StaleElementReferenceException), typeof(WebDriverException));
                //wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
                wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return !!window.jQuery && window.jQuery.active == 0"));
                wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return !window.ajaxActive == true"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            /***************************/


            //wait.Until(driver => ((IJavaScriptExecutor) driver).ExecuteScript("return (jQuery.active == 0 && !window.ajaxActive == true)"));

            //var javaScriptExecutor = driver as IJavaScriptExecutor;

            //Func<IWebDriver, bool> readyCondition = webDriver => (bool)IJavaScriptExecutor.ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0) && (window.jQuery != null)");
            //wait.Until(readyCondition);

            /*try
            {
                int count = 0; 
                if ((Boolean)javaScriptExecutor.ExecuteScript("return window.jQuery != undefined")) 
                { 
                    while (!(Boolean)javaScriptExecutor.ExecuteScript("return jQuery.active == 0")) 
                    {
                        Task.Delay(2000).Wait();
                         if (count > 5) break; 
                         count++;
                        Thread.Sleep(1000);
                    } 
                }
            }
            catch (InvalidOperationException)
            {
                wait.Until(wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
            }*/

        }

        public void WaitForSpinnertodisappear()
        {
            //IWait<IWebDriver> wait = new WebDriverWait(driver, new TimeSpan(0, 1, 80));
            try
            {
                WaitForAjaxcall();

                /*if (driver.FindElement(By.XPath("//*[@class='sapMBusyIndicator']")).Displayed == true)
                {
                    Task.Delay(500).Wait();
                    new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.WEBDRIVER_TIMEOUT))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@class='sapMBusyIndicator']")));
                    Task.Delay(500).Wait();

                    //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@class='sapMBusyIndicator']")));
                    
                }*/

                /*                if (driver.FindElement(By.XPath("//*[@class='sapMBusyIndicator']")).Displayed == true)
                                {
                                    wait.Until(driver => !driver.FindElement(By.XPath("//*[@class='sapMBusyIndicator']")).Displayed);
                                    Task.Delay(1000).Wait();
                                }*/

            }
            catch (Exception e)
            {
                if (e is WebDriverException || e is StaleElementReferenceException || e is NoSuchElementException)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void WaitForAjaxcall()
        {
            //IWait<IWebDriver> wait = new WebDriverWait(driver, new TimeSpan(0, 1, 80));
            try
            {
                if (driver.FindElement(By.CssSelector("div[role=progressbar]")).Displayed == true)
                {

                }

            }
            catch (Exception e)
            {
                if (e is WebDriverException || e is StaleElementReferenceException || e is NoSuchElementException)
                {
                    Console.WriteLine(e);
                }
            }




        }


        public static IWebElement GetParent(IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }

    }
}


