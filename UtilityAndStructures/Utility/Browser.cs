using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace UtilityAndStructures.Utility
{
    /// <summary>
    ///Common browser related function
    /// </summary>
    public class Browser
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        public static IWebDriver driver;
        /// <summary>
        /// Constructor to initialize browser
        /// </summary>
        public Browser()
        { InitBrowser(); }

        /// <summary>
        ///  initialize browser
        /// </summary>
        private void InitBrowser()
        {
            try
            {
                string browserName = ConfigurationManager.AppSettings["BROWSER"];
                string downloadFilePath = ConfigurationManager.AppSettings["FileDownloadPath"];

                switch (browserName)
                {
                    case "Chrome":
                        if (driver == null)
                        {
                            ChromeOptions options = new ChromeOptions();
                            options.AddArgument("--disable-extensions");
                            options.AddUserProfilePreference("download.default_directory", downloadFilePath);
                            options.AddUserProfilePreference("disable-popup-blocking", "true");
                            driver = new ChromeDriver(options);
                            driverSettings(ref driver);
                            Drivers.Add("Chrome", driver);
                        }
                        //For future enhancement
                        //case "Firefox":
                        //    if (driver == null)
                        //    {
                        //        driver = new FirefoxDriver();
                        //        driverSettings(ref driver);
                        //        Drivers.Add("Firefox", driver);
                        //    }
                        break;
                }
            }
            catch (Exception e)
            {
                ExtentReport.LogTestSteps(RelevantCodes.ExtentReports.LogStatus.Fatal,"Initialization of browser failed "+ e.Message);
            }
        }

        /// <summary>
        /// Driver settings
        /// </summary>
        /// <param name="driver"></param>
        private void driverSettings(ref IWebDriver driver)
        {
            try
            {
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                driver.Manage().Window.Maximize();
                driver.Manage().Cookies.DeleteAllCookies();

            }
            catch (Exception e)
            {
                ExtentReport.LogTestSteps(RelevantCodes.ExtentReports.LogStatus.Fatal, "Driver Settings Failed"+e.Message);
            }
        }

        /// <summary>
        /// Increase window size
        /// </summary>
        public static void IncreaseWindowSize()
        {
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Load application
        /// </summary>
        public static void LoadApplication()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }
       
      /// <summary>
      /// Close driver
      /// </summary>
        public static void CloseAllDrivers()
        {
            try
            {
                Drivers.Clear();
                driver.Dispose();
                driver = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message,e);
            }
        }

    }
}


