using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UtilityAndStructures.Utility;

namespace ActionLayer.ActionClasses
{
    /// <summary>
    /// Common element related functions
    /// </summary>
    public class ElementVisibility
    {
        string screenPath = string.Empty;
        /// <summary>
        /// Wait for element to be visible
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool WaitForElementVisible(By selector, uint timeout = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(timeout));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
                return true;
            }
            catch (Exception ex)
            {
                if (Screenshot.BoolScreenShotOnException)
                 screenPath=   Screenshot.CaptureScreenWithCallStack();
                if (!string.IsNullOrEmpty(screenPath))
                    ExtentReport.LogTestStepsWithScreen(RelevantCodes.ExtentReports.LogStatus.Info, ex.Message+"Element: "+ selector, screenPath);
                return false;
            }
        }
    }
}
