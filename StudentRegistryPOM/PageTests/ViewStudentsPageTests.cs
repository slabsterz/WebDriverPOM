using StudentRegistryPOM.Pages;

namespace StudentRegistryPOM.PageTests
{
    public class ViewStudentsPageTests : BaseTest
    {
        [Test]
        public void ViewStudentsPage_Content()
        {
            var studentsPage = new ViewStudentsPage(driver);

            studentsPage.OpenPage();

            var pageOpened = studentsPage.IsOpen();
            Assert.That(pageOpened, Is.True);

            var pageTitle = studentsPage.GetPageTitle();
            var pageHeading = studentsPage.GetPageHeadingText();

            Assert.Multiple(() =>
            {
                Assert.That(pageTitle, Is.EqualTo("Students"));
                Assert.That(pageHeading, Is.EqualTo("Registered Students"));
            });

            var studentList = studentsPage.GetStudentsList();

            Assert.That(studentList.Count, Is.AtLeast(1));
        }

        [Test]
        public void ViewStudentsPage_Links()
        {
            var studentsPage = new ViewStudentsPage(driver);

            studentsPage.OpenPage();
            studentsPage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            studentsPage.OpenPage();
            studentsPage.ViewStudentsLink.Click();
            Assert.IsTrue(studentsPage.IsOpen());

            studentsPage.OpenPage();
            studentsPage.AddStudentLink.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

        }
    }
}
