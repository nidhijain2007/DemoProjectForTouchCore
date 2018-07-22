using System;
using OpenQA.Selenium;
using UtilityAndStructures.EnumsAndStructures;
using UtilityAndStructures.Utility;

namespace ActionLayer.ActionClasses
{
    /// <summary>
    /// Verify Element on web pages
    /// </summary>
    public class VerifyElement
    {
        ElementVisibility ElementVisibility = new ElementVisibility();
        string screenPath = string.Empty;
        public ActionResult VerifyElementPresent(string path, Commonenums.ElementType value)
        {
            try
            {
                Boolean IsElementVisible = false;
                switch (value)
                {
                    case Commonenums.ElementType.xPath:
                        if (ElementVisibility.WaitForElementVisible(By.XPath(path)))
                            IsElementVisible = true;
                        else IsElementVisible = false;
                        break;
                    case Commonenums.ElementType.LinkText:
                        if (ElementVisibility.WaitForElementVisible(By.LinkText(path)))
                            IsElementVisible = true;
                        else IsElementVisible = false;
                        break;
                    case Commonenums.ElementType.IdPath:
                        if (ElementVisibility.WaitForElementVisible(By.Id(path)))
                            IsElementVisible = true;
                        else IsElementVisible = false;
                        break;
                    case Commonenums.ElementType.csspath:
                        if (ElementVisibility.WaitForElementVisible(By.CssSelector(path)))
                            IsElementVisible = true;
                        else IsElementVisible = false;
                        break;
                }
                return new ActionResult { IsSuccess = IsElementVisible, ErrorMessage = string.Empty };
            }
            catch (Exception e)
            {
                if (Screenshot.BoolScreenShotOnException)
                    screenPath = Screenshot.CaptureScreenWithCallStack();
                return new ActionResult { IsSuccess = false, ErrorMessage = e.Message, Screenpath = screenPath };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshWebPage()
        {
            try
            {
                Browser.driver.Navigate().Refresh();
                return new ActionResult { IsSuccess = true, ErrorMessage = string.Empty };
            }
            catch (Exception exp)
            {
                if (Screenshot.BoolScreenShotOnException)
                    screenPath = Screenshot.CaptureScreenWithCallStack();
                return new ActionResult { IsSuccess = false, ErrorMessage = exp.Message, Screenpath = screenPath };
            }
        }
    }
}
