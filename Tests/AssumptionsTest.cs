using NUnit.Framework;

namespace selenium_tests;

[TestFixture]
public class AssumptionsTest:AssumptionsPage
{
    [SetUp]
    public void SetUp()
    {   
        Initialize();
    }

    [Test]   
    public void SaveAssumptions()
    {
        ClickOnSaveAssumptions();
    }

    [TearDown]
    public void TearDown()
    {
        CloseBrowser();
    }
}
