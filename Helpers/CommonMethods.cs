using AreejTest.Data;
using AreejTest.WebDriver;
using Bytescout.Spreadsheet;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AreejTest.Helpers
{
    public class CommonMethods
    {
        public static void NavigateToURL(string url)
        {
            ManageDriver.driver.Navigate().GoToUrl(url);
        }

        public static bool CheckIfRequired(string FieldName) {
            bool isRequired = ManageDriver.driver.FindElement(By.Name(FieldName)).GetAttribute("required") != null;
            return isRequired;
        }

        public static string GetMaxLength(string FieldName)
        {
            string maxLen = ManageDriver.driver.FindElement(By.Name(FieldName)).GetAttribute("maxlength");
            return maxLen;
        }
        public static string CheckEmail(string FieldName)
        {
            string Email = ManageDriver.driver.FindElement(By.Name(FieldName)).GetAttribute("type");
            return Email;
        }
        public static string CheckPhonenumber(string FieldName)
        {
            string Phonenumber = ManageDriver.driver.FindElement(By.Name(FieldName)).GetAttribute("type");
            return Phonenumber;
        }
        public static string TakeScreenShot()
        {
            // Cast the driver to ITakesScreenshot to enable screenshot functionality
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;

            // Capture the screenshot using the driver
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            // Define the path where the screenshot will be saved
            string path = "C:\\Project\\ScreenShots";

            // Generate a unique image name using a GUID to avoid filename collisions
            string imageName = Guid.NewGuid().ToString() + "_image.png";

            // Combine the path and image name to create the full file path for the screenshot
            string fullPath = Path.Combine(path + $"\\{imageName}"); // E.g., C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestReport\\xxxxxxxxxxxxxxxxx_image.png

            // Save the screenshot to the specified path
            screenshot.SaveAsFile(fullPath);

            // Return the full path of the saved screenshot
            return fullPath;
        }
        public static Worksheet ReadExcel(string sheetName)
        {
            // Create a new instance of the Spreadsheet class
            Spreadsheet Excel = new Spreadsheet();

            // Load the Excel file from the specified path in GlobalConstants
            Excel.LoadFromFile(GlobalConstants.TestDataPath);

            // Retrieve the worksheet by its name from the loaded workbook
            Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);

            // Return the retrieved worksheet
            return worksheet;
        }
    }
}
