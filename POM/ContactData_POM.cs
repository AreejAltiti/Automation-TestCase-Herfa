using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.POM
{
    public class ContactData_POM
    {
        IWebDriver _driver;
        public ContactData_POM(IWebDriver driver)
        {
            _driver = driver;
        }
        By fullName    = By.Name("Name");
        By email       = By.Name("Email");
        By phoneNumber = By.Name("Phonenumber");
        By subject     = By.Name("Subject");
        By message     = By.Name("Message");
        By isCopy      = By.Name("copy");
        By SubmitButton = By.XPath("//div/button[@type='submit']");

        public void EnterFullName(string value)
        {
            _driver.FindElement(fullName).SendKeys(value);
        }

        public void EnterEmail(string value)
        {
            _driver.FindElement(email).SendKeys(value);
        }

        public void EnterPhoneNumber(String value)
        {
            _driver.FindElement(phoneNumber).SendKeys(value);
        }

        public void EnterSubject(string value)
        {
            _driver.FindElement(subject).SendKeys(value);
        }

        public void EnterMessage(string value)
        {
            _driver.FindElement(message).SendKeys(value);
        }

        public void EnterIsCopy(string value)
        {
            _driver.FindElement(isCopy).SendKeys(value);
        }

        public void ClickSubmitButton()
        {
            _driver.FindElement(SubmitButton).Click();
        }
    }
}
