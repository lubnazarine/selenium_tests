using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace selenium_tests;

public class AssumptionsPage:BaseClass
{
    public void Initialize()
    {
        BrowserSetUp();
        SwitchWindowtoAssumptions();
    }
    public void ClickOnModifyAssumptionsButton()
    {
        IWebElement modifyAssumptionsButton = driver.FindElement(By.XPath("//*[@id=\"app_user_form\"]/div[1]/div[1]/div[2]/div[1]/div[1]/div/button"));
        modifyAssumptionsButton.Click();
    }

    public void VerifyAssumptionsPopUpPageIsLaunched()
    {

        IWebElement actualHeadingText = driver.FindElement(By.XPath("//*[@id=\"exampleModalLabel\"]"));
        string expectedHeadingText= "Assumptions";
        Assert.That(actualHeadingText.Text.Contains(expectedHeadingText));
    }

    public void ClickOnSaveAssumptions()
    {
        IWebElement saveAssumptionsButton = driver.FindElement(By.XPath("//*[@id=\"exampleModal\"]/div/div/div[2]/div[24]/button[2]"));
        saveAssumptionsButton.Click();
    }

    public void SwitchWindowtoAssumptions()
    {
        ClickOnModifyAssumptionsButton();

        driver.SwitchTo().ActiveElement();
    
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(c => c.FindElement(By.XPath("//*[@id=\"exampleModalLabel\"]")));

        //VerifyAssumptionsPopUpPageIsLaunched();
  
    }

}
