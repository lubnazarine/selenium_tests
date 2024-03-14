using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.CSS;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace selenium_tests;

public class BusinessValueCalculatorPage:BaseClass
{

    public void Initialize()
    {
        BrowserSetUp();
    }

    public void VerifyBusinessValueCalculatorPageIsLaunched()
    {
        string actualTitle = driver.Title;
        string expectedTitle = "Technology ROI Calculator";
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        
    }
    public void VerifyTextInBVCSection()
    {
        //Verifying Text of BVC Section
        string expectedHeading = "Tell us about your organization";
        IWebElement actualHeading = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[1]/label"));
        Assert.That(actualHeading.Text.Contains(expectedHeading));

        string expectedAnnualReviewText = "What’s your organization’s annual revenue?";
        IWebElement actualAnnualReviewText = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[2]/label"));
        Assert.That(actualAnnualReviewText.Text.Contains(expectedAnnualReviewText));

        string expectedOrgHeadquatersText = "Where’s your organization’s headquarters?";
        IWebElement actualOrgHeadquatersText = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[3]/label"));
        Assert.That(actualOrgHeadquatersText.Text.Contains(expectedOrgHeadquatersText));

        string expectedEmployeeCountText = "How many employees are in your organization?";
        IWebElement actualEmployeeCountText = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[4]/label"));
        Assert.That(actualEmployeeCountText.Text.Contains(expectedEmployeeCountText));

        string expectedBudgetText = "What’s your organization’s annual IT budget?";
        IWebElement actualBudgetText = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[5]/label"));
        Assert.That(actualBudgetText.Text.Contains(expectedBudgetText));
        
        string expectedAnalysisYearsText = "Number of years for the analysis?";
        IWebElement actualnalysisYearsText = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[6]/label"));
        Assert.That(actualnalysisYearsText.Text.Contains(expectedAnalysisYearsText));
        
    }

    public void SelectOrganisationHeadquarters(string headquarter)
    {
        IWebElement hqLocations = driver.FindElement(By.XPath("//*[@id=\"Headquarters_Country\"]"));
        SelectElement element = new SelectElement(hqLocations);
        element.SelectByText(headquarter);
    }

    public void SelectNumberOfYears(string years)
    {
        IWebElement analysisYears = driver.FindElement(By.XPath("//*[@id=\"Number_of_Years\"]"));
        SelectElement element = new SelectElement(analysisYears);
        element.SelectByText(years);
    }

    public void ClickOnModifyAssumptionsButton()
    {
        IWebElement modifyAssumptionsButton = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[2]/div[1]/div[1]/div/button"));
        modifyAssumptionsButton.Click();
    }

    public void UncheckITVisibilityCheckbox()
    {
        IWebElement iTVisibilityCheckbox = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[8]/span"));
        IWebElement iTVisibilityCheckboxAttribute = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[1]/div/div[8]/span"));
        string valueAttribute = iTVisibilityCheckboxAttribute.GetAttribute("value");
        //string uncheckedValueAttribute = "0";
        if (valueAttribute == "1")
            iTVisibilityCheckbox.Click();
        //Assert.That(valueAttribute.Contains(uncheckedValueAttribute));
    }

}
