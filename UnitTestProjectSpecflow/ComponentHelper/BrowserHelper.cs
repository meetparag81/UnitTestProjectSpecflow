using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProjectSpecflow.Settings;

namespace UnitTestProjectSpecflow.ComponentHelper
{
     public class BrowserHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BrowserHelper));
        public static void BrowserMaximize()
        {
            ObjectRepository.driver.Manage().Window.Maximize();
            Logger.Info(" Browser Maximize ");
        }

        public static void GoBack()
        {
            ObjectRepository.driver.Navigate().Back();

        }

        public static void Forward()
        {
            ObjectRepository.driver.Navigate().Forward();
        }

        public static void RefreshPage()
        {
            ObjectRepository.driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index = 0)
        {
            Thread.Sleep(1000);
            ReadOnlyCollection<string> windows = ObjectRepository.driver.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }


            ObjectRepository.driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            BrowserMaximize();

        }


        public static void SwitchToParent()
        {
            var windowids = ObjectRepository.driver.WindowHandles;


            for (int i = windowids.Count - 1; i > 0;)
            {
                ObjectRepository.driver.Close();
                i = i - 1;
                Thread.Sleep(2000);
                ObjectRepository.driver.SwitchTo().Window(windowids[i]);
            }
            ObjectRepository.driver.SwitchTo().Window(windowids[0]);

        }

        public static void SwitchToFrame(By locatot)
        {
            ObjectRepository.driver.SwitchTo().Frame(ObjectRepository.driver.FindElement(locatot));
        }
    }
}
