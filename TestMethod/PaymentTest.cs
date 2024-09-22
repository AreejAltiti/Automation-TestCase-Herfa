using AreejTest.Helpers;
using AreejTest.POM;
using AreejTest.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.TestMethod
{
    [TestClass]
    public class PaymentTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ManageDriver.MaximizeDriver();
        }


        //[ClassCleanup]
        // public static void ClassCleanup()
        /// {
        //     ManageDriver.CloseDriver();
        // }
        [TestMethod]
        public void TestSuccessPayment()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrders();

            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            paymentInfo paymentInfo = new paymentInfo(ManageDriver.driver);
            paymentInfo.EnterCardName("Nadil Mohammad");
            paymentInfo.EnterCardNumber("1234567812345678");
            paymentInfo.EnterCardCvv("844");
            paymentInfo.EnterCardExp("April");
            paymentInfo.EnterCardExp("2026");
            paymentInfo.ClickSubmitButton();

            var expectedURL = "https://localhost:44349/User/ShoppingCart";
            var actualURL = ManageDriver.driver.Url;
            Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC3");
            Console.WriteLine("TC1 Completed Successfully");
        }
        [TestMethod]
        public void TestFaildPayment_InvalidCardName()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrders();

            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            paymentInfo paymentInfo = new paymentInfo(ManageDriver.driver);
            paymentInfo.EnterCardName("Areej");
            paymentInfo.EnterCardNumber("1234567812345678");
            paymentInfo.EnterCardCvv("844");
            paymentInfo.EnterCardExp("April");
            paymentInfo.EnterCardExp("2026");
            paymentInfo.ClickSubmitButton();

            Thread.Sleep(2000);

            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            var errorMessageElement = ManageDriver.driver.FindElement(By.CssSelector("div.validation-summary-errors.alert-danger li"));
            string actualErrorMessage = errorMessageElement.Text;


            string expectedErrorMessage = "Card info is incorrect";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The error message is incorrect when an invalid cardholder name is entered.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC2 Completed Successfully with Invalid Card Name");
        }

        [TestMethod]
        public void TestFaildPayment_InvalidCardNumber()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrders();

            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            paymentInfo paymentInfo = new paymentInfo(ManageDriver.driver);
            paymentInfo.EnterCardName("Nadil Mohammad");
            paymentInfo.EnterCardNumber("1234567812345670"); //1234567812345678
            paymentInfo.EnterCardCvv("844");
            paymentInfo.EnterCardExp("April");
            paymentInfo.EnterCardExp("2026");
            paymentInfo.ClickSubmitButton();

            Thread.Sleep(2000);

            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            var errorMessageElement = ManageDriver.driver.FindElement(By.CssSelector("div.validation-summary-errors.alert-danger li"));
            string actualErrorMessage = errorMessageElement.Text;


            string expectedErrorMessage = "Card info is incorrect";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The error message is incorrect when an invalid card number is entered.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC3 Completed Successfully with Invalid Card Number");
        }

        [TestMethod]
        public void TestFaildPayment_InvalidCardCvv()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrders();

            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            paymentInfo paymentInfo = new paymentInfo(ManageDriver.driver);
            paymentInfo.EnterCardName("Nadil Mohammad");
            paymentInfo.EnterCardNumber("1234567812345678"); 
            paymentInfo.EnterCardCvv("840"); //844
            paymentInfo.EnterCardExp("April");
            paymentInfo.EnterCardExp("2026");
            paymentInfo.ClickSubmitButton();

            Thread.Sleep(2000);

            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            var errorMessageElement = ManageDriver.driver.FindElement(By.CssSelector("div.validation-summary-errors.alert-danger li"));
            string actualErrorMessage = errorMessageElement.Text;


            string expectedErrorMessage = "Card info is incorrect";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The error message is incorrect when an invalid cvv number is entered.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC4 Completed Successfully with Invalid cvv Number");
        }

        [TestMethod]
        public void TestFaildPayment_InvalidExpireMonth()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrders();

            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            paymentInfo paymentInfo = new paymentInfo(ManageDriver.driver);
            paymentInfo.EnterCardName("Nadil Mohammad");
            paymentInfo.EnterCardNumber("1234567812345678");
            paymentInfo.EnterCardCvv("844"); 
            paymentInfo.EnterCardExp("March");//April
            paymentInfo.EnterCardExp("2026");
            paymentInfo.ClickSubmitButton();

            Thread.Sleep(2000);

            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            var errorMessageElement = ManageDriver.driver.FindElement(By.CssSelector("div.validation-summary-errors.alert-danger li"));
            string actualErrorMessage = errorMessageElement.Text;

            string expectedErrorMessage = "Card info is incorrect";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The error message is incorrect when an invalid expire month is entered.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC5 Completed Successfully with Invalid expire month");
        }
       
        [TestMethod]
        public void TestFaildPayment_InvalidExpireYear()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrders();

            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            paymentInfo paymentInfo = new paymentInfo(ManageDriver.driver);
            paymentInfo.EnterCardName("Nadil Mohammad");
            paymentInfo.EnterCardNumber("1234567812345678");
            paymentInfo.EnterCardCvv("844");
            paymentInfo.EnterCardExp("April");
            paymentInfo.EnterCardExp("2024");//2026
            paymentInfo.ClickSubmitButton();

            Thread.Sleep(2000);

            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            var errorMessageElement = ManageDriver.driver.FindElement(By.CssSelector("div.validation-summary-errors.alert-danger li"));
            string actualErrorMessage = errorMessageElement.Text;

            string expectedErrorMessage = "Card info is incorrect";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The error message is incorrect when an invalid expire year is entered.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC7 Completed Successfully with Invalid expire year");
        }
        [TestMethod]
        public void TestProductNameSuccess()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrdersWithValues();

            //Thread.Sleep(5000);
            //((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");
            
            Assert.AreEqual(NavigateToPreOrder.preProductName, NavigateToPreOrder.postProductName, NavigateToPreOrder.postProductName +"The error message is incorrect when an invalid product name.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC8 Completed Successfully" + NavigateToPreOrder.preProductName + " " + NavigateToPreOrder.postProductName);
        }

        [TestMethod]
        public void TestProductPriceSuccess()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrdersWithValues();

            //Thread.Sleep(5000);
            //((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 800);");

            Assert.AreEqual(NavigateToPreOrder.preProductPrice, NavigateToPreOrder.postProductPrice, NavigateToPreOrder.postProductPrice + "The error message is incorrect when an invalid product name.");
            //Console.WriteLine("The failed payment test with an invalid cardholder name was successful.");
            Console.WriteLine("TC9 Completed Successfully" + NavigateToPreOrder.preProductPrice + " " + NavigateToPreOrder.postProductPrice);
        }

        [TestMethod]
        public void TestProductQuantitSuccess()
        {
            NavigateToPreOrder NavigateToPreOrder = new NavigateToPreOrder(ManageDriver.driver);
            NavigateToPreOrder.NavigateToPreOrdersWithValues();

            Assert.AreEqual(NavigateToPreOrder.preProductQuantity, NavigateToPreOrder.postProductQuantity, NavigateToPreOrder.postProductQuantity + "The error message is incorrect when an invalid product name.");
            Console.WriteLine("TC10 Completed Successfully" + NavigateToPreOrder.preProductQuantity + " " + NavigateToPreOrder.postProductQuantity);
        }
    }
}
