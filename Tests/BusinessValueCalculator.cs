using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace selenium_tests;

public class BusinessValueCalculator
{


    IWebDriver Driver = new ChromeDriver();
    
    //By AnnualReview = By.XPath("//*[@id=\"AnnualRevenue\"]");
    //By OrganizationHeadquarter = By.XPath("//*[@id=\"Headquarters_Country\"]");
    //By NoOfEmployeesInOrganisation = By.XPath("//*[@id=\"NumberofEmployees\"]");

    [SetUp]
    public void SetUp()
    {   
        string url = "https://www.flexera.com/flexera-one/business-value-calculator";

        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Driver.Navigate().GoToUrl(url);
        // Thread.Sleep(3000);
        IWebElement closeCookie = Driver.FindElement(By.XPath("//*[@id=\"cookiescript_close\"]"));
        closeCookie.Click();
        // Thread.Sleep(3000);

    }

    [Test]
    public void VerifyBusinessValueCalculatorPageIsLaunched()
    {
        string actualTitle = Driver.Title;
        string expectedTitle = "Technology ROI Calculator";
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        
    }
   
    [Test]   
    public void VerifyTextInBVCSection()
    {
        ScrollToVroi();

        //Verifying Heading of BVC Section
        string expectedHeading = "Tell us about your organization";
        IWebElement actualHeading = Driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[1]/label"));
        Assert.That(actualHeading.Text.Contains(expectedHeading));

        string expectedAnnualReviewText = "What’s your organization’s annual revenue?";
        IWebElement actualAnnualReviewText = Driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[2]/label"));
        Assert.That(actualAnnualReviewText.Text.Contains(expectedAnnualReviewText));
        
        // IWebElement annualReview = Driver.FindElement(By.XPath("//*[@id=\"AnnualRevenue\"]"));
        // annualReview.SendKeys("20000");

        // IWebElement annualReview = Driver.FindElement(By.XPath("//*[@id=\"AnnualRevenue\"]"));
        // annualReview.Click();
        // annualReview.SendKeys("20000");
        
    }

 

    public void ScrollToVroi()
    {
        
        IWebElement iframe = Driver.FindElement(By.XPath("//*[@id=\"vroi\"]"));
        //Switch to the frame
        Driver.SwitchTo().Frame(iframe);
        Actions action = new Actions(Driver);
        action.SendKeys(Keys.PageDown);
        action.Build().Perform();


        // IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

        // IWebElement numberOfYears = Driver.FindElement(By.XPath("//*[@id=\"Number_of_Years\"]"));
        // js.ExecuteScript("arguments[0].scrollIntoView(true);", numberOfYears);
        
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}