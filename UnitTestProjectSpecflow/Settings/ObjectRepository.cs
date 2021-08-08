using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSpecflow.Interfaces;

namespace UnitTestProjectSpecflow.Settings
{
    class ObjectRepository
    {
        public static Iconfig Config { get; set; }
        public static IWebDriver driver { get; set; }
        
    }
}
