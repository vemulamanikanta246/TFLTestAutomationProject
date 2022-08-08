using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using TestAutomationFramework.Base;

namespace TestAutomationFramework.Extensions
{
    public static class WebDriverExtensions
    {

        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitFor_ElementTobe_Visible(this IWebDriver driver, string element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(element)));
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            LoopingWait(obj, timeOut, execute, stopWatch);

            static void LoopingWait<T>(T obj, int timeOut, Func<T, bool> execute, Stopwatch stopWatch)
            {
                while (stopWatch.ElapsedMilliseconds < timeOut)
                {
                    if (execute(obj))
                    {
                        break;
                    }
                }
            }
        }
    }
}
