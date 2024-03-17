using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;


namespace selenium_tests;

[TestFixture]
[AllureNUnit]
[AllureSuite("Business Value Calculator")]
[AllureFeature("Business Value Calculator")]
[AllureEpic("Flexera - Business Value Calculator")]
public class BusinessValueCalculatorTest:BusinessValueCalculatorPage
{
    [OneTimeSetUp]
    public void OneTimeSetUpSetUp()
    {   
        CleanUpAllureReports();
    }

    [SetUp]
    public void SetUp()
    {   
        Initialize();
    }

    [Test(Description ="Verify the page title after the page is launched")]
    public void VerifyPageTitle()
    {
        VerifyBusinessValueCalculatorPageIsLaunched(); 
    }

    [Test(Description ="Verify the text in the Business Value Section")]   
    public void AssertTextInVROI()
    {
        VerifyTextInBVCSection();
    }

    [Test(Description ="Select France from the Organisation Headquarters drop down list")]
    [TestCase("France")]   
    public void EnterHQ(string hq)
    {
        SelectOrganisationHeadquarters(hq);
    }

    [Test(Description ="Select 3 years from the Analysis Years drop down list")]
    [TestCase("3 years")]   
    public void EnterAnalysisYears(string years)
    {
        SelectNumberOfYears(years);
    }

    [Test(Description ="Click on the Modify Assumptions button")]   
    public void ClickOnModifyAssumptions()
    {
        ClickOnModifyAssumptionsButton();
    }

    [Test(Description ="Uncheck the checkbox - IT Visibility if it is already checked ")]   
    public void UncheckITVisibilityCheckboxIfItIsChecked()
    {
        UncheckITVisibilityCheckbox();
    }

    [TearDown]
    public void TearDown()
    {
        CloseBrowser();
    }
}