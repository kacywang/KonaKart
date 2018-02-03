
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using KonaKart.SpecFlow;

namespace KonaKart.Global
{
    class Login
    {

        internal void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");
            // Navigating to Login page using value from Excel
            Thread.Sleep(5000);
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            Thread.Sleep(5000);
            // Sending the username 
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"), ExcelLib.ReadData(2, "Email"));
            // Sending the password
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"), ExcelLib.ReadData(2, "Password"));
            // Clicking on the login button
            // loginButton.Click();
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "Value"));
        }

    }
}
