using System;
using OpenQA.Selenium;
using UtilityAndStructures.Utility;
using UtilityAndStructures.EnumsAndStructures;

namespace ActionLayer.ActionClasses
{
    /// <summary>
    /// Common text box event on web pages
    /// </summary>
    public class TextBox
    {
        ElementVisibility ElementVisibility = new ElementVisibility();
        string screenPath = string.Empty;
        /// <summary>
        /// Set text
        /// </summary>
        /// <param name="path"></param>
        /// <param name="textvalue"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ActionResult SetText(string path, string textvalue, Commonenums.ElementType value)
        {
            try
            {
                IWebElement textboxobject;
                switch (value)
                {
                    case Commonenums.ElementType.xPath:
                        if (ElementVisibility.WaitForElementVisible(By.XPath(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.XPath(path));
                            textboxobject.SendKeys(textvalue);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" }; ;
                        break;
                    case Commonenums.ElementType.csspath:
                        if (ElementVisibility.WaitForElementVisible(By.CssSelector(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.CssSelector(path));
                            textboxobject.SendKeys(textvalue);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.LinkText:
                        if (ElementVisibility.WaitForElementVisible(By.LinkText(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.LinkText(path));
                            textboxobject.SendKeys(textvalue);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.IdPath:
                        if (ElementVisibility.WaitForElementVisible(By.Id(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.Id(path));
                            textboxobject.SendKeys(textvalue);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.className:
                        if (ElementVisibility.WaitForElementVisible(By.ClassName(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.ClassName(path));
                            textboxobject.SendKeys(textvalue);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.Name:
                        if (ElementVisibility.WaitForElementVisible(By.Name(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.Name(path));
                            textboxobject.SendKeys(textvalue);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                }
               
                return new ActionResult { IsSuccess = true, ErrorMessage = "" };
            }
            catch (StaleElementReferenceException exception)
            {
                IWebElement textboxobject= Browser.driver.FindElement(By.Id(path));
                textboxobject.SendKeys(textvalue);
                return new ActionResult { IsSuccess = true, ErrorMessage = exception.Message };
            }
            catch (Exception e)
            {
                if (Screenshot.BoolScreenShotOnException)
                screenPath=   Screenshot.CaptureScreenWithCallStack();
                return new ActionResult { IsSuccess = false, ErrorMessage = e.Message, Screenpath = screenPath };
            }
         
        }
       /// <summary>
       /// Press Enter
       /// </summary>
       /// <param name="path"></param>
       /// <param name="value"></param>
       /// <returns></returns>
        public ActionResult PressEnter(string path, Commonenums.ElementType value)
        {
            try
            {
                IWebElement textboxobject;
                switch (value)
                {
                    case Commonenums.ElementType.xPath:
                        if (ElementVisibility.WaitForElementVisible(By.XPath(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.XPath(path));
                            textboxobject.SendKeys(Keys.Enter);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.csspath:
                        if (ElementVisibility.WaitForElementVisible(By.CssSelector(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.CssSelector(path));
                            textboxobject.SendKeys(Keys.Enter);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.LinkText:
                        if (ElementVisibility.WaitForElementVisible(By.LinkText(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.LinkText(path));
                            textboxobject.SendKeys(Keys.Enter);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                    case Commonenums.ElementType.IdPath:
                        if (ElementVisibility.WaitForElementVisible(By.Id(path)))
                        {
                            textboxobject = Browser.driver.FindElement(By.Id(path));
                            textboxobject.SendKeys(Keys.Enter);
                        }
                        else return new ActionResult { IsSuccess = false, ErrorMessage = "Element Not Found" };
                        break;
                }
                return new ActionResult { IsSuccess = true, ErrorMessage =string.Empty};
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
