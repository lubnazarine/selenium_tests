using System.Security.Authentication.ExtendedProtection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace selenium_tests;

public class BaseClass
{
    public IWebDriver driver;
    public void BrowserSetUp()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--headless");
        driver = new ChromeDriver(options);
        string url = "https://www.flexera.com/flexera-one/business-value-calculator";

        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl(url);
        IWebElement cookieClose = driver.FindElement(By.XPath("//*[@id=\"cookiescript_close\"]"));
        cookieClose.Click();
        PageDown();
    }
    public void CloseBrowser()
    {
        driver.Close();
    }
    public void PageDown()
    {
        IWebElement iframe = driver.FindElement(By.XPath("//*[@id=\"vroi\"]"));
        //Switch to the frame
        driver.SwitchTo().Frame(iframe);
        Actions action = new Actions(driver);
        action.SendKeys(Keys.PageDown);
        action.Build().Perform();

        // IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        // IWebElement numberOfYears = Driver.FindElement(By.XPath("//*[@id=\"Number_of_Years\"]"));
        // js.ExecuteScript("arguments[0].scrollIntoView(true);", numberOfYears);
    }

    public void ScrollDownTo()
    {
        IWebElement iframe = driver.FindElement(By.XPath("//*[@id=\"vroi\"]"));
        //Switch to the frame
        driver.SwitchTo().Frame(iframe);
        Actions action = new Actions(driver);
        IWebElement element = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[7]/label"));
        if(element.Displayed.Equals(false))
            action.SendKeys(Keys.PageDown);
            action.Build().Perform();

        // IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        // IWebElement numberOfYears = Driver.FindElement(By.XPath("//*[@id=\"Number_of_Years\"]"));
        // js.ExecuteScript("arguments[0].scrollIntoView(true);", numberOfYears);
    }



}
