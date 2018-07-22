
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace UtilityAndStructures.Utility
{
    /// <summary>
    ///Common Readwritefunctions of excel sheet
    /// </summary>
    public class ExcelDriver
    {
        static string sqlString = "SELECT * FROM [Sheet1$]";

        public static string excelpath { get; set; }

        public static string testcasename { get; set; }
        static System.Data.DataTable dt;
      
        /// <summary>
        /// Returns an OleDB connection
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        private static OleDbConnection GetConnection(string excelPath)
        {
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties=Excel 12.0;";
            return new OleDbConnection(connStr);
        }
              
        /// <summary>
        /// Close excel connection
        /// </summary>
        /// <param name="CloseConn"></param>
        private static void CloseExcelConnection(OleDbConnection CloseConn)
        {
            CloseConn.Close();
        }

        /// <summary>
        /// Create and close oledbconnection
        /// </summary>
        public static void CreateAndCloseConnection()
        {
            OleDbConnection conn = GetConnection(excelpath);
            OleDbCommand cmd = new OleDbCommand(sqlString, conn);
            conn.Open();
            dt = new System.Data.DataTable();
            dt.Load(cmd.ExecuteReader());
            CloseExcelConnection(conn);
        }

        /// <summary>
        /// split string
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private static Tuple<string, string> SplitString(string Value)
        {
            try
            {
                List<string> methodname = new List<string>();
                string factor;
                if (Value.Contains(':'))
                {
                    methodname = Value.Split(':').ToList();
                    factor = methodname[1];
                }
                else
                {
                    methodname.Add(Value);
                    factor = "0";
                }
                return new Tuple<string, string>(factor, methodname[0]);
            }
            catch (Exception ex)
            {
                ExtentReport.LogTestSteps(RelevantCodes.ExtentReports.LogStatus.Fail, "Check Test Data  " + ex.Message);
                return new Tuple<string,string>(string.Empty,string.Empty);
            }
        }
     
        /// <summary>
        /// Get Test data from excel
        /// </summary>
        /// <param name="MethodName"></param>
        /// <param name="TestData"></param>
        /// <returns></returns>
        public static string GetTestData(string MethodName, string TestData)
        {
            try
            {
                List<string> word = new List<string>();
                Tuple<string, string> Factor = SplitString(MethodName);
                if (Factor != null)
                {
                    String currentCellValue;
                    List<DataRow> rows = dt.Select("TestCaseName = '" + testcasename.Trim().ToLower() + "' AND " + "MethodName = '" + Factor.Item2.Trim().ToLower() + "'").ToList();
                    foreach (DataRow dr in rows)
                    {
                        currentCellValue = dr[TestData].ToString();
                        if (currentCellValue.Contains(";"))
                            word = currentCellValue.Split(';').ToList();
                        else
                            word.Add(currentCellValue);
                    }
                    return word[Int32.Parse(Factor.Item1)];
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                ExtentReport.LogTestSteps(RelevantCodes.ExtentReports.LogStatus.Fail, "Check Test Data  " + ex.Message);
                return string.Empty;
            }
        }
      
    }
}
