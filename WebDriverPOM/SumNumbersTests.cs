using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverPOM
{
    public class SumNumbersTests
    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(SumNumbersPage.Url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Add_TwoValidNumbers()
        {
            var page = new SumNumbersPage(driver);

            page.AddNumbers("12", "15");

            var result = page.ResultDiv.Text;

            Assert.That(result, Does.Contain("27"));
        }

        [Test]
        public void Add_InvalidNumbers()
        {
            var page = new SumNumbersPage(driver);

            page.AddNumbers("invalid", "5");

            var result = page.ResultDiv.Text;

            Assert.That(result, Is.EqualTo("Sum: invalid input"));
        }

        [Test]
        public void Rest_Functionality()
        {
            var page = new SumNumbersPage(driver);
            page.AddNumbers("12", "15");
            page.ResetForm();

            var result = page.ResultDiv.Text;
            Assert.That(result, Is.Empty);

        }
    }
}