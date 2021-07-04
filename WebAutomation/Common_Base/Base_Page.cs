using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace WebAutomation.BaseTest
{
    public class Base_Page
    {
        protected RemoteWebDriver webDriver;
        protected WebDriverWait wait;

        public Base_Page(RemoteWebDriver driver) {
            webDriver = driver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        //find element by their respective indicators
        public IWebElement FindElementBy(By element)
        {
            try
            {
                return webDriver.FindElement(element);
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //find elements by their respective indicators
        public ReadOnlyCollection<IWebElement> FindElementsBy(By elements)
        {
            try
            {
                return webDriver.FindElements(elements);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //find element by their respective text
        public IWebElement FindElementByText(string elementText)
        {
            By selector = By.XPath("//*[text()='" + elementText + "']");

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(selector));
                return webDriver.FindElement(selector);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //check if an element is being displayed
        public Boolean IsDisplayed(By element)
        {
            if (FindElementBy(element) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //check if an element is being displayed
        public Boolean IsDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        //get the text or value from an element
        public string GetText(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            if (FindElementBy(element).GetAttribute("value") != null)
            {
                //if the element has a value we will return it
                return FindElementBy(element).GetAttribute("value");
            }
            else
            {
                //if the element doesn't have a value we return the text
                return FindElementBy(element).Text;
            }
        }

        //perform a click action to an element
        public void Click(By element)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                FindElementBy(element).Click();
            } catch(Exception)
            {
                try
                {
                    //if element is not visible try to scroll the page to the element
                    PerformScrollToElement(element);
                    FindElementBy(element).Click();
                } catch(Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //perform a click action to an element
        public void Click(IWebElement element)
        {
            element.Click();
        }

        //send text into an input field
        public void SendKeys(By element, string keys)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                FindElementBy(element).SendKeys(keys);
            } catch(Exception)
            {
                try
                {
                    //if element is not visible try to scroll the page to the element
                    PerformScrollToElement(element);
                    FindElementBy(element).SendKeys(keys);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //get alert message
        public string GetAlertMessage()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                var alertWindow = webDriver.SwitchTo().Alert();
                string alertMessage = alertWindow.Text;
                alertWindow.Accept();
                return alertMessage;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
        }

        //perform an scroll until an element is visible
        public void PerformScrollToElement(By element) {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(FindElementBy(element));
            actions.Perform();
        }
    }
}
