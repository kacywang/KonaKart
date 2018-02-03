using Excel.Log;
using KonaKart.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace KonaKart.Pages
{
    class Cart
    {
        public void AddItems()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Cart");
            Thread.Sleep(2000);
            // go to Games category
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));
            Thread.Sleep(4000);
            // scroll down to the first added item
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollBy(0,300)", "");
            Thread.Sleep(2000);

            // mouse hover on the first item
            IWebElement firstItem = Driver.driver.FindElement(By.LinkText(ExcelLib.ReadData(2, "Name1")));
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(firstItem).Build().Perform();
            Thread.Sleep(1000);
            // add the first item to cart
            Driver.driver.FindElement(By.LinkText("ADD TO CART")).Click();
            Thread.Sleep(2000);

            // go to DVD categor
            js.ExecuteScript("window.scrollBy(0,-300)", "");
            Thread.Sleep(2000);
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));
            Thread.Sleep(2000);

            // choose comedy menu
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "Value"));
            Thread.Sleep(2000);

            // add the second item to chart
            Thread.Sleep(2000);
            IWebElement secondItem = Driver.driver.FindElement(By.LinkText(ExcelLib.ReadData(2, "Name2")));
            Actions actionS = new Actions(Driver.driver);
            actionS.MoveToElement(secondItem).Build().Perform();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.LinkText("ADD TO CART")).Click();
            Thread.Sleep(2000);

            // go to Electronics
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "Value"));
            Thread.Sleep(2000);
            // choose phone menu
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"));
            Thread.Sleep(2000);
            // add the third item to chart
            Thread.Sleep(2000);
            IWebElement thirdItem = Driver.driver.FindElement(By.LinkText(ExcelLib.ReadData(2, "Name3")));
            Actions actionT = new Actions(Driver.driver);
            actionT.MoveToElement(thirdItem).Build().Perform();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.LinkText("ADD TO CART")).Click();
            Thread.Sleep(2000);

        }

        public void VerifyCart()
        {
            // go to shopping cart
            Thread.Sleep(2000);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Cart");
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));
            Thread.Sleep(2000);

            IList cList = Driver.driver.FindElements(By.XPath("//*[@id='form1']/table/tbody/tr/td[2]/a[1]"));
            int cCount = cList.Count;

            for (int i = 1; i <= cCount; i++)
            {
                // verify the line items
                if (Driver.GetTextValue(Driver.driver, ExcelLib.ReadData(8, "Locator"), ExcelLib.ReadData(8, "Value") + i + ExcelLib.ReadData(8, "Value1")).ToLower() == ExcelLib.ReadData(1 + i, "Item").ToLower())
                {
                    // verity the quantity
                    if (Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(9, "Value") + i + ExcelLib.ReadData(9, "Value1"))).GetAttribute("value") == "1")
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Quantity is correct");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quantity is incorrect");
                        Thread.Sleep(2000);
                    }

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Line items is correct");
                    Thread.Sleep(2000);
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Line item is incorrect");
                    Thread.Sleep(2000);
                }
            }
        }

        public void VerifyPrice()
        {
            Thread.Sleep(2000);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Cart");
            //Driver.ActionButton(Driver.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));
            Thread.Sleep(2000);

            IList cList = Driver.driver.FindElements(By.XPath("//*[@id='form1']/table/tbody/tr/td[2]/a[1]"));
            int cCount = cList.Count;

            // verify total price of single item 
            double sTotal = 0;
            string subTotal = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(12, "Value"))).Text;
            double subTotalP = Double.Parse(Regex.Replace(subTotal, "\\$", ""));

            for (int i = 1; i <= cCount; i++)
            {
                string price = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(10, "Value") + i + ExcelLib.ReadData(10, "Value1"))).Text;
                double iPrice = Double.Parse(Regex.Replace(price, "\\$", ""));
                Thread.Sleep(2000);
                string quantity = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(9, "Value") + i + ExcelLib.ReadData(9, "Value1"))).GetAttribute("value");
                int iQuantity = Int32.Parse(quantity);
                Thread.Sleep(2000);
                string tPrice = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(11, "Value") + i + ExcelLib.ReadData(11, "Value1"))).Text;
                double totalSingleP = Double.Parse(Regex.Replace(tPrice, "\\$", ""));
                Thread.Sleep(2000);

                if (iPrice * iQuantity == totalSingleP)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Single Total Price is correct");
                    Thread.Sleep(2000);
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Single Total Price is incorrect");
                    Thread.Sleep(2000);
                }
               // verify Sub-Total price
                sTotal = sTotal + totalSingleP;

                if (sTotal == subTotalP)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sub-Total Price is correct");
                    Thread.Sleep(2000);
                }   
            }

            string shipping = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(13, "Value"))).Text;
            double shipPrice = Double.Parse(Regex.Replace(shipping, "\\$", ""));
            string total = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(14, "Value"))).Text;
            double totalPrice = Double.Parse(Regex.Replace(total, "\\$", ""));

            if (subTotalP + shipPrice == totalPrice)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Total Price is correct");
                Thread.Sleep(2000);
            }
        }

        public void RemoveItem()
        {
            Thread.Sleep(2000);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Cart");
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));
            Thread.Sleep(2000);

            string subTotal = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(12, "Value"))).Text;
            double subTotalP = Double.Parse(Regex.Replace(subTotal, "\\$", ""));

            // get the price of removed item
            string removeP = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(15, "Value"))).Text;
            double removePrice = Double.Parse(Regex.Replace(removeP, "\\$", ""));

            // reomove the item
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
            Thread.Sleep(4000);

            string subTotalU = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(17, "Value"))).Text;
            double subTotalUpdate = Double.Parse(Regex.Replace(subTotalU, "\\$", ""));

            // verify value updated correclty 
            if (subTotalP-removePrice == subTotalUpdate)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Value updated correctly");
                Thread.Sleep(2000);
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Value updated incorrectly");
                Thread.Sleep(2000);
            }

        }

        public void UseCoupon()
        {
            Thread.Sleep(2000);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Cart");
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));
            Thread.Sleep(2000);

            // enter coupon code
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(18, "Locator"), ExcelLib.ReadData(18, "Value"),ExcelLib.ReadData(2,"Coupon"));
            Thread.Sleep(4000);
            // clcik update button
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(19, "Locator"), ExcelLib.ReadData(19, "Value"));
            Thread.Sleep(2000);
        }

        public void VerifyCoupon()
        {
            Thread.Sleep(2000);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Cart");

            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));
            Thread.Sleep(2000);

            // verify coupon is used
            string discount = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(20, "Value"))).Text;
            if(discount == "10% Discount:")
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Coupon is used successfully");
                Thread.Sleep(2000);
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Coupon is not used");
                Thread.Sleep(2000);
            }

            // verify 10% discount is correct
            string subTotal = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(12, "Value"))).Text;
            double subTotalP = Double.Parse(Regex.Replace(subTotal, "\\$", ""));
            string discountPrice = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(21, "Value"))).Text;
            double discountP = Double.Parse(discountPrice.Remove(0, 2));

            if(Math.Round(subTotalP*0.1,2) == discountP)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "10% Discount is correct");
                Thread.Sleep(2000);
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "10% Discount is incorrect");
                Thread.Sleep(2000);
            }

        }

    }

}
