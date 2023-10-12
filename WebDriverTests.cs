using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace SeleniumWebDriverWaitExample
{
    public class WebDriverTests
    {

        private WebDriver driver;
        private WebDriverWait wait;
        private const string BaseUrl = "https://www.derwesten.de/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
        }

        [OneTimeTearDown] 
        public void TearDown() 
        {
            driver.Quit();
        }
        

        [Test]
        public void Test_Wait_ThreadSleep()
        {
            

            var cityLink = driver.FindElement(By.LinkText("DUISBURG"));
            cityLink.Click();

            Thread.Sleep(1000); 

            var berlinLink = driver.FindElement(By.LinkText("Berlin-Live.de – Nachrichten für Berlin"));
            berlinLink.Click();

            Thread.Sleep(3000);

            var derwestenLink = driver.FindElement(By.LinkText("DerWesten.de – Nachrichten für den Westen")).Text;

            Assert.That(derwestenLink.Contains("Nachrichten für den Westen"));


        }

        [Test]
        public void Test_Wait_ImplicitWaitExample()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var allowLink = driver.FindElement(By.CssSelector("a.cmpboxbtn.cmpboxbtnyes.cmptxt_btn_yes"));
            allowLink.Click();

            var cityLink = driver.FindElement(By.LinkText("DUISBURG"));
            cityLink.Click();

            var berlinLink = driver.FindElement(By.LinkText("Berlin-Live.de – Nachrichten für Berlin"));
            berlinLink.Click();

            var derwestenLink = driver.FindElement(By.LinkText("DerWesten.de – Nachrichten für den Westen")).Text;

            Assert.That(derwestenLink.Contains("Nachrichten für den Westen"));


        }

        


    }


    }