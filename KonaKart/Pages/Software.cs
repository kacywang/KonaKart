using KonaKart.Global;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KonaKart.Pages
{
    class Software
    {
        public void SearchMicrosoft()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Software");
            Thread.Sleep(2000);
            // click software tab because search button is not working
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));
            Thread.Sleep(2000);
            // clcik Microsoft link
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));
            Thread.Sleep(2000);
        }

        public void VerifySearch()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Software");
            // count the number of search result
            IList sList = Driver.driver.FindElements(By.XPath("//*[@id='item-overview']/div[2]/ul/li/div/a"));
            int sCount = sList.Count;
            bool found = false;
            // use a loop to verify if it is able to see Windows 8
            for (int i = 1; i < sCount && found == false; i++)
            {
                if (Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(4, "Value") + i + ExcelLib.ReadData(4, "Value1"))).Text == ExcelLib.ReadData(2, "SearchResult"))
                {
                    found = true;
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Search successfully");
                    break;
                }

                else
                {
                    found = false;
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Search failed");
                    Thread.Sleep(2000);
                }
            }

        }

           
        }

    }


