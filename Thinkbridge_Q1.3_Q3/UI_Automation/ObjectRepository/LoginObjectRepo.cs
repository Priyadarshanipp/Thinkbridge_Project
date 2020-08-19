using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Automation.ObjectRepository
{
    public class LoginObjectRepo
    {
        public static readonly By PageHeading = By.XPath("//h2//b[text()='Employer Login']");
        public static readonly By LanguageDropdown = By.CssSelector("div[name='language']");
        public static readonly By LangDDOptions = By.CssSelector("div[name='language']");
        //There is typo in id. Should be signUpEmail
        public static readonly By Email = By.CssSelector("input[id='singUpEmail']");
        public static readonly By Organization = By.CssSelector("input[name='orgName']");
        public static readonly By FullName = By.CssSelector("input[name='name']");
        public static readonly By TNCChenckbox = By.CssSelector("label.ui-checkbox>span");
        public static readonly By GetStarted = By.CssSelector("div>button[type='submit']");
        public static readonly By EmailVerificationMessage = By.XPath("//div/span[contains(text(),'welcome email')]");
    }
}
