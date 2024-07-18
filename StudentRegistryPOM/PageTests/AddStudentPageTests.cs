using NuGet.Frameworks;
using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PageTests
{
    public class AddStudentPageTests : BaseTest
    {
        [Test]
        public void AddStudentPage_Content()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            var title = addStudentPage.GetPageTitle();
            var header = addStudentPage.GetPageHeadingText();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(addStudentPage.IsOpen());
                Assert.That(title, Is.EqualTo("Add Student"));
                Assert.That(header, Is.EqualTo("Register New Student"));
            });

            var inputNameField = addStudentPage.InputNameField.Text;
            var inputEmailField = addStudentPage.InputEmailField.Text;

            Assert.Multiple(() =>
            {
                Assert.That(inputEmailField, Is.Empty);
                Assert.That(inputNameField, Is.Empty);
                Assert.That(addStudentPage.AddButton.Text, Is.EqualTo("Add"));
            });
        }

        [Test]
        public void AddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            addStudentPage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.OpenPage();
            addStudentPage.ViewStudentsLink.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            addStudentPage.OpenPage();
            addStudentPage.AddStudentLink.Click();
            Assert.IsTrue(addStudentPage.IsOpen());
        }

        [Test]
        public void AddStudentPage_AddValidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            addStudentPage.AddStudent(GenerateRandomName(), GenerateRandomEmail());

            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            var allStudents = new ViewStudentsPage(driver).GetStudentsList();

            Assert.IsTrue(allStudents.Any(x => x.Contains("Pesho")));
        }

        [Test]
        public void AddStudentPage_AddInvalidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            addStudentPage.AddStudent(string.Empty, GenerateRandomEmail());
            Assert.IsTrue(addStudentPage.IsOpen());

            var errorMessage = addStudentPage.GetErrorMessage();
            Assert.That(errorMessage, Does.Contain("Cannot add student. Name and email fields are required!"));
        }
    }
}
