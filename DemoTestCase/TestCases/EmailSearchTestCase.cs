
using NUnit.Framework;
using UtilityAndStructures.Utility;
using System;
using BusinessObject;
using ActionLayer.ActionClasses;

namespace TestCases.DemoTestCases
{
    /// <summary>
    /// Test class to check Email Search functionality and related test cases
    /// </summary>
    public class EmailSearchTestCase : DemoTestCase.TestBase
    {
       
        HomePageBO HomeBO;
        /// <summary>
        /// Constructor 
        /// </summary>
        public EmailSearchTestCase()
        {
            SetExcelPath("TestData\\" + this.GetType().Name + ".xlsx");
            CloseConnection();
        }

        /// <summary>
        /// Test set up  
        /// </summary>
        [SetUp]
        public override void TestSetup()
        {
            BrowserInitialization();
            HomeBO = new HomePageBO();
          
            string TcName = TestContext.CurrentContext.Test.FullName;
            ExcelDriver.testcasename = TestContext.CurrentContext.Test.Name;
            ExcelDriver.excelpath = "TestData\\" + this.GetType().Name + ".xlsx";
            Screenshot.ScreenShotFileName(TestContext.CurrentContext.Test.Name);
        }

        /// <summary>
        /// Test end functionality
        /// </summary>
        [TearDown]
        public override void TestCaseEnd()
        {
            ExtentReport.EndTestAndGenerateLogFile();
            Browser.CloseAllDrivers();
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void CloseConnection()
        {
            ExcelDriver.CreateAndCloseConnection();
        }

        #region "TestCases"
        /// <summary>
        /// Verify that the user is able to Login to Gmail and Verify Home page loaded
        /// </summary>
        [Test]
        [Repeat(10)]
        [Description("Verify that the user is able to Login to Gmail and Verify Home page loaded")]
        public void TC01VerifyHomePage()
        {
            try
            {
                ExtentReport.StartReport("Verify that the user is able to Login to Gmail", "Verify that the user is able to Login to GMail and Verify home page loaded");
                result = LogIn(ExcelDriver.GetTestData("Login:0", "TestData1"), ExcelDriver.GetTestData("Login:1", "TestData1")); AssertTest();
                //result = HomeBO.ClickGMailIcon(); AssertTest();
                result = HomeBO.VerifyComposeButton();AssertTest();Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Verified Home Page Loaded Successfully for Gmail");
                //we can add more controls for verification as an enhancement
            }
            catch (Exception e)
            {
                if (!string.IsNullOrEmpty(result.Screenpath))
                    ExtentReport.LogTestStepsWithScreen(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message, result.Screenpath);
                else
                    ExtentReport.LogTestSteps(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message);
            }
            finally
            {
                //we can add Jira updates
            }
        }

        /// <summary>
        /// Verify that the user is able to Login to Gmail and launching specific searched Email
        /// </summary>
        [Repeat(10)]
        [Test]
        [Description("Verify that the user is able to Login to Gmail and launching specific searched Email")]
        public void TC02LaunchEMail()
        {
            try
            {
                ExtentReport.StartReport("Verify that the user is able to Login to Gmail and launching specific searched Email", "Verify that the user is able to Login to Gmail and launching specific searched Email");
                result = LogIn(ExcelDriver.GetTestData("Login:0", "TestData1"), ExcelDriver.GetTestData("Login:1", "TestData1")); AssertTest();
               // result = HomeBO.ClickGMailIcon();AssertTest();
                result = HomeBO.VerifyComposeButton(); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Verified Home Page Loaded Successfully for Gmail");
                string EmailToBeSearched = ExcelDriver.GetTestData("EMailSubject", "TestData1");
                result = HomeBO.EnterSearchText(EmailToBeSearched); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Entered Searched Text: "+EmailToBeSearched);
                result = HomeBO.PressEnter(); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Pressed Enter");
                result = HomeBO.LaunchEMail(EmailToBeSearched); AssertTest(); Report(RelevantCodes.ExtentReports.LogStatus.Pass, "Email Launched");
            }
            catch (Exception e)
            {
                if (!string.IsNullOrEmpty(result.Screenpath))
                    ExtentReport.LogTestStepsWithScreen(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message, result.Screenpath);
                else
                    ExtentReport.LogTestSteps(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message);
            }
            finally
            {
                //jira update
            }
        }
        #endregion
    }
}
