using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PageTests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomEmail()
        {
            var random = new Random();
            var email = $"pesho-{random.Next(1, 2000)}@email.com";
            return email;
        }

        public string GenerateRandomName()
        {
            var names = new string[] { "Peter", "Vlad", "Ivane", "Dessy", "Liland" };
            var random = new Random();
            return $"{names[random.Next(0, names.Length)]}";
        }

    }
}
