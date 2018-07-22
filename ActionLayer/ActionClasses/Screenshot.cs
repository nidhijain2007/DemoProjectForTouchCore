using System;
using System.Text;
using OpenQA.Selenium;
using UtilityAndStructures.Utility;
using System.Configuration;
using System.Diagnostics;
namespace ActionLayer.ActionClasses
{
    /// <summary>
    /// Generic functions to take screenshots
    /// </summary>
    public class Screenshot
    {
        private static string screenShotPath= ConfigurationManager.AppSettings["ScreenShotPath"] + DateTime.Now.ToLongDateString();
        static string ScreenShotOnException = ConfigurationManager.AppSettings["ScreenShotOnException"];
        public static bool BoolScreenShotOnException ;
        /// <summary>
        /// Constructor
        /// </summary>
        static Screenshot()
        {
            SetBoolValues();
            if(!CheckFolderExists(screenShotPath))
                System.IO.Directory.CreateDirectory(screenShotPath);
        }

        /// <summary>
        /// Setbool values
        /// </summary>
        private static void SetBoolValues()
        {
            if (ScreenShotOnException == "True")
                BoolScreenShotOnException = true;
            else
                BoolScreenShotOnException = false;
        }

        /// <summary>
        /// Check folder exists
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        private static bool CheckFolderExists(string Path)
        {
            if (System.IO.Directory.Exists(Path))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Screen shot file name
        /// </summary>
        /// <param name="TcName"></param>
        public static void ScreenShotFileName(string TcName)
        {
            screenShotPath = ConfigurationManager.AppSettings["ScreenShotPath"] + DateTime.Now.ToLongDateString();
            string filename = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            screenShotPath = screenShotPath +"\\\\" + "_" + TcName + "_" + filename.Replace(":", "_") + ".png";
        }

        /// <summary>
        /// Capture screen
        /// </summary>
        /// <returns></returns>
        public static string CaptureScreen()
        {
            try
            {
                ITakesScreenshot ssdriver = Browser.driver as ITakesScreenshot;
                OpenQA.Selenium.Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile(screenShotPath);
                return screenShotPath;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// capture screen with screen shot
        /// </summary>
        /// <returns></returns>
        public static string CaptureScreenWithCallStack()
        {
            try
            {
                if (BoolScreenShotOnException)
                {
                    screenShotPath = string.Empty;
                    screenShotPath = ConfigurationManager.AppSettings["ScreenShotPath"] + DateTime.Now.ToLongDateString();
                    string filename = DateTime.Now.ToString("HH:mm");

                    string CallStack = GetCallStack();
                    screenShotPath = screenShotPath + "\\\\" + "_" + CallStack + "_" + filename.Replace(":", "_") + ".png";
                    ITakesScreenshot ssdriver = Browser.driver as ITakesScreenshot;

                    OpenQA.Selenium.Screenshot screenshot = ssdriver.GetScreenshot();
                    screenshot.SaveAsFile(screenShotPath);
                    return screenShotPath;
                }
                else
                    return string.Empty;
            }
            catch (UnhandledAlertException ex)
            {
                AlertMessage Alert = new AlertMessage();
                Alert.CloseAlertBox();
                ITakesScreenshot ssdriver = Browser.driver as ITakesScreenshot;
                OpenQA.Selenium.Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile(screenShotPath);
                return screenShotPath;
            }
            catch (Exception e)
            {
                return screenShotPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCallStack()
        {
            StringBuilder Message = new StringBuilder();
            StackTrace stackTrace = new StackTrace();           // get call stack
            StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)
            for (int i = 2; i < 9; i++)
            {
                Message.Append(stackFrames[i].GetMethod().Name);
                Message.Append("_");
            }
            return Message.ToString();
        }
    }
}
