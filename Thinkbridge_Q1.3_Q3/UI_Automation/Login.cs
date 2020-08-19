using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;
using static UI_Automation.ObjectRepository.LoginObjectRepo;

namespace UI_Automation
{
    public class Login:IClassFixture<SetupTeardown>
    {
        IWebDriver _browserDriver;
        ChromeOptions _chromeOptions;
        public Login(SetupTeardown setUp)
        {
            _browserDriver = setUp.browserDriver;
            _chromeOptions = setUp.chromeOptions;
            _browserDriver.Manage().Window.Maximize();
        }
        [Fact]
        public void Should_SignUp_And_Receive_Mail()
        {
            try
            {
                //Wait for Launching browser
                WebDriverWait wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(5));
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_browserDriver);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                //Navigate to Url
                _browserDriver.Navigate().GoToUrl("http://jt-dev.azurewebsites.net/#/SignUp");
                //Entering name, organization and email
                var name = _browserDriver.FindElement(FullName);
                name.SendKeys("Priyadarshani");
                var organization = _browserDriver.FindElement(Organization);
                organization.SendKeys("Priyadarshani");
                var email = _browserDriver.FindElement(Email);
                email.SendKeys("priyapppp123456@gmail.com");
                var checkbox = _browserDriver.FindElement(TNCChenckbox);
                checkbox.Click();
                var signUp = _browserDriver.FindElement(GetStarted);
                signUp.Click();
                //Wait until confirmation message appears
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(EmailVerificationMessage));
                Assert.True(CheckForEmail());
            }
            catch(Exception e)
            {
                throw new Exception("Exception occured while execution "+e.Message);
            }
            
        }
        private bool CheckForEmail()
        {
            bool isMailPresent = false;
            using (var client= new ImapClient())
            {
                    client.Connect("imap.gmail.com", 993,true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("dummymail@gmail.com", "dummyPwd");
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    //Query to search respective mail
                    var query = SearchQuery.DeliveredOn(DateTime.Today)
                    .And(SearchQuery.SubjectContains("Please Complete JabaTalks Account"));
                    if (inbox.Search(query).Count > 0)
                        isMailPresent= true;
                    return isMailPresent;
            }
        }
    }
}
