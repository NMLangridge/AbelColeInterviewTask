namespace HelloSeleniumTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class InterviewTask
{
    IWebDriver driver = null;
    [TestMethod]
    public void addRemoveProducts()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.abelandcole.co.uk/pantry/chocolate");
        driver.Manage().Window.Maximize();
        //Delete Cookies from previous run
        driver.Manage().Cookies.DeleteAllCookies();
        //Accept Cookies
        driver.FindElement(By.XPath("//button[@id='ccc-notify-accept']")).Click();

        //Verify empty basket
        driver.FindElement(By.XPath("//div[@class='basket menu-item icon-basket']")).Click();
        driver.FindElement(By.XPath("//div[@class='empty-basket ']//p[text()='Your basket is currently empty.']"));

        //Search for Honeycomb Caramel Truffles
        driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Honeycomb Caramel Truffles");
        driver.FindElement(By.XPath("//input[@id='search-btn']")).Click();
        //Add 2
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Honeycomb Caramel Truffles, Organic, Booja Booja (92g, pack of 8)']//..//..//div[@class='add cta-button']")).Click();
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Honeycomb Caramel Truffles, Organic, Booja Booja (92g, pack of 8)']//..//..//div[@class='add-sign plus']")).Click();
        
        //Verify added to basket message at top of page
        //Idea 1
        // driver.FindElement(By.XPath("//span[@class='bold'][text()='Honeycomb Caramel Truffles, Organic, Booja Booja (92g, pack of 8)']"));

        //Idea 2
        // var addedToBasketMessage = driver.FindElement(By.XPath("//span[@class='text']//span[contains(text(),'Honeycomb Caramel Truffles, Organic, Booja Booja (92g, pack of 8)') and contains(text(),'added to your basket')]"));
        // Assert.IsTrue(addedToBasketMessage.Displayed);
        // Assert.AreEqual(addedToBasketMessage.Text.ToLower(), "Honeycomb Caramel Truffles, Organic, Booja Booja (92g, pack of 8)".ToLower());

        //Verify x in basket message underneath product
        // driver.FindElement(By.XPath("//span[@class='icon-basket basket-quantity']//a[text()='2 in basket']"));

        //Verify count on basket symbol
        // driver.FindElement(By.XPath("//span[@id='BasketCount'][text()='2']"));

        //Verify product exists in basket
        driver.FindElement(By.XPath("//div[@class='basket menu-item icon-basket']")).Click();
        var yourBasket1 = driver.FindElement(By.XPath("//div[@class='product-name'][text()='Honeycomb Caramel Truffles, Organic, Booja Booja (92g, pack of 8)']//..//div[@class='quantity-dropdown']//span[contains(text(),'2')]"));
        Assert.IsTrue(yourBasket1.Displayed);
        //Go back to home page
        driver.FindElement(By.XPath("//div[@class='logo']")).Click();

        //Search for Dark Chocolate Buttons
        driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Dark Chocolate Buttons");
        driver.FindElement(By.XPath("//input[@id='search-btn']")).Click();
        //Add 3
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Dark Chocolate Buttons, Organic, Cocoa Loco (100g)']//..//..//div[@class='add cta-button']")).Click();
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Dark Chocolate Buttons, Organic, Cocoa Loco (100g)']//..//..//div[@class='add-sign plus']")).Click();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Dark Chocolate Buttons, Organic, Cocoa Loco (100g)']//..//..//div[@class='add-sign plus']")).Click();

        //Verify product exists in basket
        driver.FindElement(By.XPath("//div[@class='basket menu-item icon-basket']")).Click();
        var yourBasket2 = driver.FindElement(By.XPath("//div[@class='product-name'][text()='Dark Chocolate Buttons, Organic, Cocoa Loco (100g)']//..//div[@class='quantity-dropdown']//span[contains(text(),'3')]"));
        Assert.IsTrue(yourBasket2.Displayed);
        //Go back to home page
        driver.FindElement(By.XPath("//div[@class='logo']")).Click();

        //Search for Mylk & Pink Salt Raw Chocolate
        driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Mylk & Pink Salt Raw Chocolate");
        driver.FindElement(By.XPath("//input[@id='search-btn']")).Click();
        //Scroll to product
        var product1 = driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Mylk & Pink Salt Raw Chocolate, Organic, Raw Halo (70g)']"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(product1);
        actions.Perform();
        //Add 1
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Mylk & Pink Salt Raw Chocolate, Organic, Raw Halo (70g)']//..//..//div[@class='add cta-button']")).Click();

        //Verify product exists in basket
        driver.FindElement(By.XPath("//div[@class='basket menu-item icon-basket']")).Click();
        var yourBasket3 = driver.FindElement(By.XPath("//div[@class='product-name'][text()='Mylk & Pink Salt Raw Chocolate, Organic, Raw Halo (70g)']//..//div[@class='quantity-dropdown']//span[contains(text(),'1')]"));
        Assert.IsTrue(yourBasket3.Displayed);
        //Go back to home page
        driver.FindElement(By.XPath("//div[@class='logo']")).Click();

        //Search for Mylk & Pink Salt Raw Chocolate
        driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Mylk & Pink Salt Raw Chocolate");
        driver.FindElement(By.XPath("//input[@id='search-btn']")).Click();
        //Scroll
        var product2 = driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Mylk & Pink Salt Raw Chocolate, Organic, Raw Halo (70g)']"));
        Actions actions2 = new Actions(driver);
        actions.MoveToElement(product2);
        actions.Perform();
        //Remove 1
        driver.FindElement(By.XPath("//div[@class='product-title']//a[text()='Mylk & Pink Salt Raw Chocolate, Organic, Raw Halo (70g)']//..//..//div[@class='add-sign minus']")).Click();

        //Verify product no longer exists in basket
        driver.FindElement(By.XPath("//div[@class='basket menu-item icon-basket']")).Click();
        var yourBasket4 = driver.FindElement(By.XPath("//div[@class='product-name'][text()='Mylk & Pink Salt Raw Chocolate, Organic, Raw Halo (70g)']//..//div[@class='quantity-dropdown']//span[contains(text(),'1')]"));
        Assert.IsFalse(yourBasket4.Displayed);

        driver.Quit();

        //Potential Additions:
        //Add, remove product on search suggestions dialog
        //Increase, decrease quantity on basket page via dropdown
        //Remove product on basket page via clicking red cross image
    }
}