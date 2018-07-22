using System;
using RelevantCodes.ExtentReports;
using System.Configuration;

namespace UtilityAndStructures.Utility
{
    /// <summary>
    /// To generate execution log in html format fileExtentReport
    /// </summary>

    public class ExtentReport
    {
        public static ExtentReports extent;
        public static ExtentTest testResult;
        private static string reportDirectoryPath = ConfigurationManager.AppSettings["Reports"] + DateTime.Now.ToLongDateString();
        private static string reportFilePath = reportDirectoryPath + @"\ExecutionReport" + DateTime.Now.ToLongDateString() + ".html";
        private static string Application = ConfigurationManager.AppSettings["Application"];
        /// <summary>
        /// Extent Report constructor to create directory if not exists
        /// </summary>
        static ExtentReport()
        {
            if (!System.IO.Directory.Exists(reportFilePath))
                System.IO.Directory.CreateDirectory(reportDirectoryPath);
        }
        /// <summary>
        /// Report details on second tab
        /// </summary>
        /// <param name="testTitle"></param>
        /// <param name="testDescription"></param>
        public static void StartReport(string testTitle, string testDescription)
        {
            extent = new ExtentReports(reportFilePath, false, DisplayOrder.OldestFirst);
            extent.AssignProject("GMail Website");
            extent.AddSystemInfo("URL", ConfigurationManager.AppSettings["URL"]);
            testResult = extent.StartTest(testTitle, testDescription);
        }

        /// <summary>
        /// Log Test steps in report
        /// </summary>
        /// <param name="status"></param>
        /// <param name="StepName"></param>
        public static void LogTestSteps(LogStatus status,string StepName)
        {
            testResult.Log(status ,StepName);
        }

        /// <summary>
        /// Log Test step with screen shot
        /// </summary>
        /// <param name="status"></param>
        /// <param name="StepName"></param>
        /// <param name="Path"></param>
        public static void LogTestStepsWithScreen(LogStatus status, string StepName, string Path)
        {
            testResult.Log(status, StepName + testResult.AddScreenCapture(Path));
        }

        /// <summary>
        /// Add screen
        /// </summary>
        /// <param name="status"></param>
        /// <param name="Path"></param>
        public static void AddScreen(LogStatus status,string Path)
        {
            testResult.Log(status, testResult.AddScreenCapture(Path));
        }
            
        /// <summary>
        /// Close the report
        /// </summary>
        public static void EndTestAndGenerateLogFile()
        {
            try
            {
                extent.EndTest(testResult);
                extent.Flush();
                extent.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }             
    }
}
