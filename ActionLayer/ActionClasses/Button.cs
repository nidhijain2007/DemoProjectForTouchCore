using System;
using OpenQA.Selenium;
using UtilityAndStructures.Utility;
using UtilityAndStructures.EnumsAndStructures;

namespace ActionLayer.ActionClasses
{
    /// <summary>
    /// CommonButton event on web pages
    /// </summary>
    public class Button
    {
        ElementVisibility ElementVisibility = new ElementVisibility();
        string screenPath = string.Empty;
        /// <summary>
        /// Click button using javascript
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ActionResult ClickButtonByLocation(string path, Commonenums.ElementType value)
        {
            try
            {
                IWebElement element;
                switch (value)
                {
                    case Commonenums.ElementType.xPath:
                        if (ElementVisibility.WaitForElementVisible(By.XPath(path)))
                        {
                            element = Browser.driver.FindElement(By.XPath(path));
                            if (element.Displayed && element.Enabled)
                            {
                                IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
                                jse.ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
                                element.Click();
                            }
                        }
                        else
                            return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not found" };
                        break;
                    case Commonenums.ElementType.csspath:
                        if (ElementVisibility.WaitForElementVisible(By.CssSelector(path)))
                        {
                            element = Browser.driver.FindElement(By.CssSelector(path));
                            if (element.Displayed && element.Enabled)
                            {
                                IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
                                jse.ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
                                element.Click();
                            }
                        }
                        else
                            return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not found" };
                        break;
                    case Commonenums.ElementType.IdPath:
                        if (ElementVisibility.WaitForElementVisible(By.Id(path)))
                        {
                            element = Browser.driver.FindElement(By.Id(path));
                            if (element.Displayed && element.Enabled)
                            {
                                IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
                                jse.ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
                                element.Click();
                            }
                        }
                        else
                            return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not found" };
                        break;
                }
                return new ActionResult { IsSuccess = true, ErrorMessage = string.Empty };
            }
            catch (Exception e)
            {
                if (Screenshot.BoolScreenShotOnException)
                    screenPath = Screenshot.CaptureScreenWithCallStack();
                return new ActionResult { IsSuccess = false, ErrorMessage = e.Message, Screenpath = screenPath };
            }
        }

        /// <summary>
        /// Click button
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ActionResult ClickButton(string path, Commonenums.ElementType value)
        {
            try
            {
                IWebElement element;
                switch (value)
                {
                    case Commonenums.ElementType.xPath:
                        if (ElementVisibility.WaitForElementVisible(By.XPath(path)))
                        {
                            element = Browser.driver.FindElement(By.XPath(path));
                            if (element.Displayed && element.Enabled)
                                element.Click();
                        }
                        else
                            return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not found" };
                        break;
                    case Commonenums.ElementType.csspath:
                        if (ElementVisibility.WaitForElementVisible(By.CssSelector(path)))
                        {
                            element = Browser.driver.FindElement(By.CssSelector(path));
                            if (element.Displayed && element.Enabled)
                                element.Click();
                        }
                        else
                            return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not found" };
                        break;
                    case Commonenums.ElementType.IdPath:
                        if (ElementVisibility.WaitForElementVisible(By.Id(path)))
                        {
                            element = Browser.driver.FindElement(By.Id(path));
                            if (element.Displayed && element.Enabled)
                                element.Click();
                        }
                        else
                            return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not found" };
                        break;
                }
                return new ActionResult { IsSuccess = true, ErrorMessage = string.Empty };
            }
            catch (Exception e)
            {
                if (Screenshot.BoolScreenShotOnException)
                    screenPath = Screenshot.CaptureScreenWithCallStack();
                return new ActionResult { IsSuccess = false, ErrorMessage = e.Message, Screenpath = screenPath };
            }
        }
    }
}
