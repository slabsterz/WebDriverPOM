using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {            
        }

        public override string Url => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";

        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//body//div"));
        public IWebElement InputNameField => driver.FindElement(By.XPath("//form//input[@id='name']"));
        public IWebElement InputEmailField => driver.FindElement(By.XPath("//form//input[@id='email']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public void AddStudent(string name, string email)
        {
            InputNameField.SendKeys(name);
            InputEmailField.SendKeys(email);
            AddButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
