****Flexera - Business Value Calculator****

**This Automation suite performs the following tests:**
1. Launch the Flexera website and verifies the page title
2. Assert some text on the Business Valur Calculator Section
3. Select an option from the drop down list for Headquarters
4. Select an option from the drop down list for Analysis years
5. Click on Modify assumptions button

**Implementation**:
Created a UI automation suite with the above mentioned test cases in C# - selenium
Created Nunit test cases
Created a GitHub Actions pipeline
Failured test cases configured to be having a screenshot in an Allure report

**Instructions to clone repository:**
Clone project from GitHub
Add the following dependencies from Nuget.org

**Dependencies:**
1. Allure.Nunit
2. Microsoft.NET.Test.Sdk
3. Nunit
4. Nunit3TestAdapter
5. Selenium.Support
6. Selenium.WebDriver
7. Selenium.WebDriver.ChromeDriver

**Build project:**
dotnet build

**Run tests:**
dotnet test

**Generate allure report:**
allure generate allure-results --clean -o allure-report

**Open report as html:**
allure open

**Github implementations:**
Main branch called test.
Code is in the test branch.
gh-pages is the branch where the CI reports are uploaded.
The workflow instructions is in the test_deploy.yml file.
Everytime there is a new code pushed or edited on github it triggers the pipeline.
