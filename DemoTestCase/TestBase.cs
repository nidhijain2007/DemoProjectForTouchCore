
using BusinessObject;
using NUnit.Framework;
using System;
using UtilityAndStructures.EnumsAndStructures;
using UtilityAndStructures.Utility;

namespace DemoTestCase
{
    /// <summary>
    /// Test base class 
    /// </summary>
    public abstract class TestBase
    {
        protected ActionResult result = new ActionResult();
        public abstract void TestSetup();
        public abstract void TestCaseEnd();
        LogInPageObjectBO login = new LogInPageObjectBO();
        /// <summary>
        /// Browser initialization
        /// </summary>
        protected void BrowserInitialization()
        {
            Browser browser = new Browser();
            Browser.LoadApplication();
        }
        /// <summary>
        /// Set excel path
        /// </summary>
        /// <param name="path"></param>
        protected void SetExcelPath(string path)
        {
            ExcelDriver.excelpath = AppDomain.CurrentDomain.BaseDirectory + path;
        }
        /// <summary>
        /// AssertTest
        /// </summary>
        protected void AssertTest()
        {
            Assert.AreEqual(true, result.IsSuccess, result.ErrorMessage);
        }
        /// <summary>
        /// Log steps in report
        /// </summary>
        /// <param name="result"></param>
        /// <param name="Message"></param>
        protected void Report(RelevantCodes.ExtentReports.LogStatus result, string Message)
        {
            ExtentReport.LogTestSteps(result, Message);
        }

        /// <summary>
        /// Log In function
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        protected ActionResult LogIn(string User, string Password)
        {
            try
            {
                result = login.EnterUserId(User); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "UserId Entered for Gmail " + User);
                result = login.ClickNext(); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Clicked On Next");
                result = login.EnterPassword(Password); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Password Entered for Gmail");
                result = login.ClickNext(); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Clicked On Next");
                return result;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                return result;
            }
        }
    }
}
