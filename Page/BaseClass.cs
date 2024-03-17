using Allure.Net.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
        options.AddArguments("--headless=new");
        options.AddArguments("--window-size=1024,768");
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--allow-running-insecure-content");
        options.AddArgument("--user-agent='Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36'");
        driver = new ChromeDriver(options);
        string url = "https://www.flexera.com/flexera-one/business-value-calculator";

        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl(url);

        VerifyBusinessValueCalculatorPageIsLaunched();
        RejectCookieAlert();
        PageDown();

    }

    public void CleanUpAllureReports()
    {
        AllureLifecycle.Instance.CleanupResultDirectory(); // clears up previous allure files
    }

    public void RejectCookieAlert()
    {
        IWebElement cookieReject = driver.FindElement(By.Id("cookiescript_reject"));
        cookieReject.Click();
    }

    public void VerifyBusinessValueCalculatorPageIsLaunched()
    {
        string actualTitle = driver.Title;
        string expectedTitle = "Technology ROI Calculator";
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        Console.WriteLine("******** inside title assertion ************");
        
    }
    public void CloseBrowser()
    {
        TakeScreenshotUponFailure();
        driver.Close();
    }

    public void TakeScreenshotUponFailure()
    {
        if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        {
            byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            AllureApi.AddAttachment("Failed Screenshot", "image/png",content);
        }
    }
    public void PageDown()
    {
        IWebElement iframe = driver.FindElement(By.XPath("//*[@id=\"vroi\"]"));
        //Switch to the frame
        driver.SwitchTo().Frame(iframe);
        Actions action = new Actions(driver);
        action.SendKeys(Keys.PageDown);
        action.Build().Perform();

    }

}
