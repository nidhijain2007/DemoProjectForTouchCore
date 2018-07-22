using System;
using UtilityAndStructures.Utility;
using OpenQA.Selenium;
using UtilityAndStructures.EnumsAndStructures;

namespace ActionLayer.ActionClasses
{
    /// <summary>
    /// Common Alert event on web pages
    /// </summary>
    public class AlertMessage
    {
        string path = string.Empty;
     /// <summary>
     /// Close Alert box
     /// </summary>
     /// <returns></returns>
        public ActionResult CloseAlertBox()
        {
            try
            {
                IAlert alert = Browser.driver.SwitchTo().Alert();
                alert.Dismiss();
                return new ActionResult { IsSuccess = true, ErrorMessage = string.Empty};
            }
            catch (Exception e)
            {
                if (Screenshot.BoolScreenShotOnException)
                   path= Screenshot.CaptureScreenWithCallStack();
                return new ActionResult { IsSuccess = false, ErrorMessage = e.Message, Screenpath = path };
            }
        }
    }
}
