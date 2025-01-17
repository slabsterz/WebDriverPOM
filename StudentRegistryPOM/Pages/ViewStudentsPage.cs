﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {            
        }

        public override string Url => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/students";
        public IReadOnlyCollection<IWebElement> AllStudents => driver.FindElements(By.XPath("//body//ul//li"));

        public List<string> GetStudentsList()
        {
            //return AllStudents.Select(x => x.Text).ToArray();

            List<string> sting = new List<string>();

            foreach(var student in AllStudents)
            {
                sting.Add(student.Text);
            }

            return sting;
        }
    }
}
