using System;
using OpenQA.Selenium;
using UnitTestProjectSpecflow.Settings;

namespace SeleniumWebdriver.ComponentHelper
{
    public class JavaScriptPopHelper
    {
        public static bool IsPopupPresent()
        {
            try
            {
                ObjectRepository.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopUpText()
        {
            if (!IsPopupPresent())
                return String.Empty;
            return ObjectRepository.driver.SwitchTo().Alert().Text;
        }

        public static void ClickOkOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.driver.SwitchTo().Alert().Accept();
        }

        public static void ClickCancelOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeys(string text)
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
