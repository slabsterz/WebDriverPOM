using NuGet.Frameworks;
using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PageTests
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public void HomePage_Content()
        {
            var page = new HomePage(driver);
            page.OpenPage();

            var pageTitle = page.GetPageTitle();
            var pageHeading = page.GetPageHeadingText();
            var studentCount = page.GetStudentsCount();

            Assert.Multiple(() =>
            {
                Assert.True(page.IsOpen());
                Assert.That(pageTitle, Is.EqualTo("MVC Example"));
                Assert.That(pageHeading, Is.EqualTo("Students Registry"));
                Assert.That(studentCount, Is.AtLeast(1));
            });
        }

        [Test]
        public void HomePage_Links_Test()
        {
            var page = new HomePage(driver);

            page.OpenPage();
            page.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.OpenPage();
            page.ViewStudentsLink.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            page.OpenPage();
            page.AddStudentLink.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
