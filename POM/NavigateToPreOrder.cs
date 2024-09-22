using AreejTest.WebDriver;
using OpenQA.Selenium;
using AreejTest.Helpers;
using AreejTest.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.POM
{
    public class NavigateToPreOrder
    {
        public string preProductName = "";
        public string preProductPrice = "";
        public string preProductQuantity = "";

        public string postProductName = "";
        public string postProductPrice = "";
        public string postProductQuantity = "";

        private IWebDriver _driver;

        public NavigateToPreOrder(IWebDriver driver)
        {
            _driver = driver;
        }
        /**/
        
        public void NavigateToPreOrders(){
        CommonMethods.NavigateToURL("https://localhost:44349");
            Thread.Sleep(5000);
            IWebElement loginLink = ManageDriver.driver.FindElement(By.CssSelector("a[href='/Auth/Login']"));
        loginLink.Click();
            Thread.Sleep(5000);
            UserLogin UserLogin = new UserLogin(ManageDriver.driver);
        UserLogin.EnterEmail("areegfouad12751@gmail.com");
            UserLogin.EnterPassword("Areej12344@");
            UserLogin.ClickSubmitButton();
            Thread.Sleep(5000);

            IWebElement shopLink = ManageDriver.driver.FindElement(By.CssSelector("a[href='/User/ShoppingCart']"));
        shopLink.Click();
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 700);");
            IWebElement preOrderLink = ManageDriver.driver.FindElement(By.CssSelector(".btn.btn-info.mt-2"));
            Thread.Sleep(2000);
            //((IJavaScriptExecutor) ManageDriver.driver).ExecuteScript("arguments[0].scrollIntoView(true);", preOrderLink);
        preOrderLink.Click();
            Thread.Sleep(2000);   
        }
        public void NavigateToPreOrdersWithValues()
        {
            CommonMethods.NavigateToURL("https://localhost:44349");
            Thread.Sleep(5000);
            IWebElement loginLink = ManageDriver.driver.FindElement(By.CssSelector("a[href='/Auth/Login']"));
            loginLink.Click();
            Thread.Sleep(5000);
            UserLogin UserLogin = new UserLogin(ManageDriver.driver);
            UserLogin.EnterEmail("areegfouad12751@gmail.com");
            UserLogin.EnterPassword("Areej12344@");
            UserLogin.ClickSubmitButton();
            Thread.Sleep(5000);

            IWebElement shopLink = ManageDriver.driver.FindElement(By.CssSelector("a[href='/User/ShoppingCart']"));
            shopLink.Click();
            Thread.Sleep(5000);
            /* This to get the values before checkout */
             preProductName = _driver.FindElement(By.CssSelector(".d-block.text-dark")).Text;
             preProductPrice    = _driver.FindElement(By.CssSelector("span[style='color:blue;']")).Text;
            IWebElement quantityElement = _driver.FindElement(By.Name("newQuantity"));
             preProductQuantity = quantityElement.GetAttribute("value");
            /* This to get the values before checkout*/
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 700);");
            IWebElement preOrderLink = ManageDriver.driver.FindElement(By.CssSelector(".btn.btn-info.mt-2"));
            Thread.Sleep(2000);
            //((IJavaScriptExecutor) ManageDriver.driver).ExecuteScript("arguments[0].scrollIntoView(true);", preOrderLink);
            preOrderLink.Click();
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("window.scrollBy(0, 300);");
            /* This to get the values after checkout */
            postProductName = _driver.FindElement(By.XPath("(//div[@class='col-6']//label[@class='form-label'])[2]")).Text;
            postProductQuantity = _driver.FindElement(By.XPath("(//div[@class='col-3'])[3]//span")).Text;
            postProductPrice = _driver.FindElement(By.XPath("(//div[@class='col-3'])[4]//span")).Text;
            /* This to get the values after checkout*/
        }
    }
}