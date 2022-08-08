using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestAutomationFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present exception"));
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
