using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Automation
{
    public class SetupTeardown : IDisposable
    {
        public ChromeOptions chromeOptions;
        public IWebDriver browserDriver;
        public SetupTeardown()
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            browserDriver = new ChromeDriver("./", chromeOptions);
        }
        public void Dispose()
        {
            browserDriver.Quit();
        }
    }
}
