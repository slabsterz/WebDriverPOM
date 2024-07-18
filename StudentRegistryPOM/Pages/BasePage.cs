using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public virtual string Url { get; }

        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[@href='/']"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.XPath("//a[@href='/students']"));
        public IWebElement AddStudentLink => driver.FindElement(By.XPath("//a[@href='/add-student']"));
        public IWebElement Header => driver.FindElement(By.TagName("h1"));


        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public bool IsOpen()
        {
            return driver.Url == this.Url;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return Header.Text;
        }
    }
}
