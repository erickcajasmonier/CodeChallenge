# Challenge Demoblaze

NuGet Packages used for this project:
- Microsoft.NET.Test.Sdk
- NUnit
- NUnit3TestAdapter
- Selenium.Support
- Selenium.WebDriver
- DotNetSeleniumExtras.WaitHelpers (This package was used to manage waits using ExpectedConditions).
- Selenium.InternetExplorer.WebDriver
- Selenium.WebDriver.ChromeDriver
- Selenium.WebDriver.GeckoDriver

Supported browser versions:
- Google Chrome v89.0.4389.128
- Firefox v78.0.2
- Microsoft Edge v17.17134
- Internet Explorer v11.0

***To run the test you only need to click on the "Run All Tests" from the Test Explorer window (Visual Studio > View > Test Explorer).***

To have in mind:
- All tests consume random generated data, there is nothing to change/insert.
- There are API vs UI validations for the products per category.
- If you are ***using another version of the browser***, please update them in the ***Nuget Package Manager***.

## What would I do differently if I had more time?
- I would have made my Base_Page more robust.
- Test that the purchase has been made successful (not just in the UI) in a DB (that is registered).
- Test when you log in the account, it keeps the items already added to the cart (in the login session).
- Implement an API call to add products (for this the cookies are required), this way we can save time from adding them manually in other steps.
- Test sending the full billing information for purchase and validate that the date is correct (updated).
- Add a custom report for a better visualization.
- I would have implemented BDD.
- I would have asked the developers to add more ids (in some locators I'm using xpath and cssSelector).
- Add the posibility to test the web application in mobile (configuring the view).
- I would have covered the out of scope scenarios like:
  - Account creation (Duplicated user).
  - Login (User does not exist).
  - Play About Us video (Validate that if you click on the video the pause button is shown).
- Cover any other non-happy path scenario.

## Result example
![TestReportExample](/TestReportExample.PNG?raw=true "Nunit Visual Studio results")