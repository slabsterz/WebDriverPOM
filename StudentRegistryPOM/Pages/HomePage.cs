using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public override string Url => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/";

        IWebElement RegisteredStudentsCount => driver.FindElement(By.TagName("b"));

        public int GetStudentsCount()
        {
            return int.Parse(RegisteredStudentsCount.Text);
        }
    }
}
