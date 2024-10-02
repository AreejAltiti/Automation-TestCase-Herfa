using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AreejTest.WebDriver;
using AreejTest.Helpers;
using AreejTest.Data;
using AreejTest.dsada;
using System.Runtime.Intrinsics.X86;
using AreejTest.POM;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using AventStack.ExtentReports.Model;
using static System.Net.Mime.MediaTypeNames;

namespace AreejTest.TestMethod
{
    [TestClass]
    public class Contact_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();

        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Project\\Report");

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();
        }
        public static void ClassCleanup()
        {
            extentReports.Flush();
            //ManageDriver.CloseDriver();
        }
        [TestMethod]
        public void TestContectSuccess() {
            var test = extentReports.CreateTest("TestSuccessContacat", "verify that on passing valid data to register form, the data added correctly");

            try {
                /*I Make Full Test Using Excle*/
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_Data ContactData_Data = ContactData_AssistantMethods.ReadContactDataFromExcel(1);
                ContactData_AssistantMethods.FillRegisterForm(ContactData_Data);
                Thread.Sleep(2000);
                Assert.IsTrue(ContactData_AssistantMethods.CheckSuccessContact(ContactData_Data.email));
                
                Assert.AreEqual(true, ContactData_AssistantMethods.CheckSuccessContact(ContactData_Data.email), "The Contact request is not saved in database");
                Console.WriteLine("TC1 Completed Successfully"+"    " + ContactData_AssistantMethods.CheckSuccessContact(ContactData_Data.email));
                test.Pass("TC1 Completed Successfully");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally
            {
                extentReports.Flush();
            }
        }
        [TestMethod]
        public void TestContectFullName()
        {
            var test = extentReports.CreateTest("TestContectFullName", "The Field Not required OR Non Alphabetic input OR More Than 100 characters");
            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);
                /*Check Field Max Length*/
                ContactData_POM.EnterFullName("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
                ContactData_POM.ClickSubmitButton();
                bool errorMessage2 = ManageDriver.driver.FindElement(By.Name("Name")).Displayed;
                Assert.AreEqual(true, errorMessage2, "You Can not put more than 100 characters");
                /*Check Field Max Length*/

                /*Check if the field is requierd*/
                 bool result = CommonMethods.CheckIfRequired("Name");
                 Assert.AreEqual(true, result, "The field Not Required");
                /*Check if the field is requierd*/

                /*Check alphabetic*/
                ContactData_POM.EnterFullName("123@!");
                bool errorMessage = ManageDriver.driver.FindElement(By.Name("Name")).Displayed;
                Assert.AreEqual(true, errorMessage, "You Can not put non alphabetic input");
                /*Check alphabetic*/
                Console.WriteLine("TC2 Completed Successfully");
                test.Pass("TC2 Completed Successfully");

            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally
            {
                extentReports.Flush();
            }
        }
        [TestMethod]
        public void TestContectEmail()
        {
            var test = extentReports.CreateTest("TestContectFullName", "The Field Not required OR Non Alphabetic input OR More Than 100 characters");

            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);
                /*Check if the field is requierd*/
                bool result = CommonMethods.CheckIfRequired("Email");
                Assert.AreEqual(true, result, "The field Not Required");
                /*Check if the field is requierd*/

                /*Check Filed Type If It's Email*/
                string checkEmail = CommonMethods.CheckEmail("Email");
                Assert.AreEqual("email", checkEmail,"The Field not support the email format");
                /*Check Filed Type If It's Email*/
                Console.WriteLine("TC3 Completed Successfully");
                test.Pass("TC3 Completed Successfully");

            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally
            {
                extentReports.Flush();
            }
        }
        [TestMethod]
        public void TestContectPhone()
        {
            var test = extentReports.CreateTest("TestContectFullName", "The Field Not required OR Non Alphabetic input OR More Than 100 characters");

            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);
                /*Check if the field is requierd*/
                bool result = CommonMethods.CheckIfRequired("Phonenumber");
                Assert.AreEqual(true, result, "The field Not Required");
                /*Check if the field is requierd*/

                /*Check Filed Type If It's Number*/
                string CheckPhonenumber = CommonMethods.CheckPhonenumber("Phonenumber");
                Assert.AreEqual("number", CheckPhonenumber, "The Field is accpted String");
               /*Check Filed Type If It's Number*/
                Console.WriteLine("TC4 Completed Successfully");
                test.Pass("TC4 Completed Successfully");

            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally
            {
                extentReports.Flush();
            }
        }
        [TestMethod]
        public void TestContectSubject()
        {
            var test = extentReports.CreateTest("TestContectFullName", "The Field Not required OR Non Alphabetic input OR More Than 100 characters");

            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);
                /*Check Filed Type If It's Number*/
                string maxLength = CommonMethods.GetMaxLength("Subject");
                Assert.AreEqual(255, maxLength, "The Field is not exceed 255 characters.");
                /*Check Filed Type If It's Number*/
                Console.WriteLine("TC5 Completed Successfully");
                test.Pass("TC5 Completed Successfully");

            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally
            {
                extentReports.Flush();
            }
        }

        [TestMethod]
        public void TestContectMessage()
        {
            var test = extentReports.CreateTest("TestContectMessage", "The Field count limit of 500 characters.");
            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);
                ContactData_POM.EnterMessage("");
                Thread.Sleep(2000);
                /*Check if the field is requierd*/
                bool result = CommonMethods.CheckIfRequired("Message");
                Assert.AreEqual(true, result, "The field Not Required");
                /*Check if the field is requierd*/

                /*Check Filed Type If It's Number*/
                string maxLength = CommonMethods.GetMaxLength("Message");
                Assert.AreEqual(500, maxLength, "The Field count limit of 500 characters.");
                /*Check Filed Type If It's Number*/
                Console.WriteLine("TC6 Completed Successfully");
                test.Pass("TC6 Completed Successfully");

            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally {
                extentReports.Flush();
            }
        }
        [TestMethod]
        public void TestContectSubmit()
        {
            var test = extentReports.CreateTest("TestContectFullName", "The Field Not required OR Non Alphabetic input OR More Than 100 characters");

            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Thread.Sleep(4000);
                ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);
                ContactData_POM.EnterFullName("Test");
                ContactData_POM.EnterEmail("email@gmail.com");
                ContactData_POM.EnterPhoneNumber("1231231235");
                ContactData_POM.EnterSubject("sunject");
                ContactData_POM.EnterMessage("Test");

                string Name        = ManageDriver.driver.FindElement(By.Name("Name")).GetAttribute("value");
                string Email       = ManageDriver.driver.FindElement(By.Name("Email")).GetAttribute("value");
                string Phonenumber = ManageDriver.driver.FindElement(By.Name("Phonenumber")).GetAttribute("type");
                string Message     = ManageDriver.driver.FindElement(By.Name("Message")).GetAttribute("type");

                if (Name != null && Email != null && Phonenumber != null && Message != null)
                {
                    ContactData_POM.ClickSubmitButton();
                    Thread.Sleep(2000);
                    Assert.AreEqual(true, ContactData_AssistantMethods.CheckSuccessContact(Email), "The data not saved in the database");
                }
                else {
                    Assert.Fail("There is a required field not entered");
                }
                Console.WriteLine("TC7 Completed Successfully");
                test.Pass("TC7 Completed Successfully");

            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();

                test.AddScreenCaptureFromPath(screenShotPath);

            }
            finally
            {
                extentReports.Flush();
            }
        }
    }
}
