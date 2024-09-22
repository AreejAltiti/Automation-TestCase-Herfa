using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.POM
{
    public class paymentInfo
    {
        IWebDriver _driver;
        public paymentInfo(IWebDriver driver)
        {
            _driver = driver;
        }
        By CardName   = By.Name("cardholderame");
        By CardNumber = By.Name("cardNumber");
        By CardCvv    = By.Name("cvv");
        By CardExp    = By.Name("expire");
        //By SubmitButton = ;//By.XPath("//div/button[@type='submit']");
        public void EnterCardName(string value)
        {
            _driver.FindElement(CardName).SendKeys(value);
        }
        public void EnterCardNumber(string value)
        {
            _driver.FindElement(CardNumber).SendKeys(value);
        }
        public void EnterCardCvv(string value)
        {
            _driver.FindElement(CardCvv).SendKeys(value);
        }
        public void EnterCardExp(string value)
        {
            _driver.FindElement(CardExp).SendKeys(value);

            if (!(value.Length == 4 && int.TryParse(value, out int year)))
            {
                _driver.FindElement(CardExp).SendKeys(Keys.Tab);
            }
        }
        public void ClickSubmitButton()
        {
            IWebElement submitButton = _driver.FindElement(By.XPath("//button[@type='submit']"));
            submitButton.Click();
        }
    }
}
