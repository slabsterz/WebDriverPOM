using OpenQA.Selenium;
using System.Text;

namespace WebDriverPOM
{
    public class SumNumbersPage
    {
        public static readonly string Url = "https://41b68512-6216-4e69-9c7a-446e51ffb237-00-297pyj4m4p8p4.spock.replit.dev/";

        private IWebDriver driver;

        public IWebElement Number1 => driver.FindElement(By.XPath("//input[@name='number1']"));
        public IWebElement Number2 => driver.FindElement(By.XPath("//input[@name='number2']"));
        public IWebElement CalcButton => driver.FindElement(By.XPath("//input[@id='calcButton']"));
        public IWebElement ResetButton => driver.FindElement(By.XPath("//input[@id='resetButton']"));
        public IWebElement ResultDiv => driver.FindElement(By.XPath("//div[@id='result']"));

        public SumNumbersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void AddNumbers(string num1, string num2)
        {
            Number1.SendKeys(num1);
            Number2.SendKeys(num2);
            CalcButton.Click();
        }

        public void ResetForm()
        {
            ResetButton.Click();
        }

        public bool IsFormEmpty()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(Number1.Text, Number2.Text, ResultDiv.Text);

            if(stringBuilder.Length != 0)
            {
                return false;
            }

            return true;
        }
    }
}
