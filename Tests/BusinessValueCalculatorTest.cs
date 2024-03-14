using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Allure.Core;


namespace selenium_tests;

[TestFixture]

public class BusinessValueCalculatorTest:BusinessValueCalculatorPage
{

    [SetUp]
    public void SetUp()
    {   
        Initialize();
    }

    [Test]
    public void VerifyPageTitle()
    {
        VerifyBusinessValueCalculatorPageIsLaunched(); 
    }

    [Test]   
    public void AssertTextInVROI()
    {
        VerifyTextInBVCSection();
    }

    [TestCase("France")]   
    public void EnterHQ(string hq)
    {
        SelectOrganisationHeadquarters(hq);
    }

    [TestCase("3 years")]   
    public void EnterAnalysisYears(string years)
    {
        SelectNumberOfYears(years);
    }

    [Test]   
    public void ClickOnModifyAssumptions()
    {
        ClickOnModifyAssumptionsButton();
    }

    [Test]   
    public void UncheckITVisibilityCheckboxIfItIsChecked()
    {
        UncheckITVisibilityCheckbox();
        Thread.Sleep(3000);
    }

    [TearDown]
    public void TearDown()
    {
        CloseBrowser();
    }
}