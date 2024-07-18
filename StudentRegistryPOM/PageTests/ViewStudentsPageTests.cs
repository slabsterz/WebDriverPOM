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

        }
    }
}
