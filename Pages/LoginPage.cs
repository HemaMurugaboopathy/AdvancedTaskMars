using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class LoginPage: CommonDriver   
    { 
        //Find Element by ID
        public IWebElement signInbutton => driver.FindElement(By.XPath("//a[@class='item' and text()='Sign In']"));
        public IWebElement emailTextbox => driver.FindElement(By.XPath("//input[@name=\"email\"]"));
        public IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[@name=\"password\"]"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));

        public void LoginActions()
        {
           //Navigate to sign in
            signInbutton.Click();

            //Enter email
            emailTextbox.SendKeys("h.prabhaharan@gmail.com");

            //Enter password
            passwordTextbox.SendKeys("123456");

            //Click login to enter
            loginButton.Click();
        }
    }
}
