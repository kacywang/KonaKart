using KonaKart.Global;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using RelevantCodes.ExtentReports;

namespace KonaKart
{

    //[TestFixture]
    public abstract class Base
    {

        #region To access Path from resource file

        public static int Browser = Int32.Parse(Resource.Browser);
        public static String ExcelPath = Resource.ExcelPath;
        public static string ScreenshotPath = Resource.ScreenShotPath;
        public static string ReportPath = Resource.ReportPath;


        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();

                    break;
                case 2:
                    // Driver.driver = new ChromeDriver();
                    ////Driver.driver.Manage().Window.Maximize();
                    var options = new ChromeOptions();

                    options.AddArguments("--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    Driver.driver = new ChromeDriver(options);
                    break;

            }
            if (Resource.IsLogin == "true")
            {
                Login loginobj = new Login();
                loginobj.LoginSuccessfull();
            }
            else
            {
               
            }
            extent = new ExtentReports(ReportPath, false, DisplayOrder.OldestFirst);
            extent.LoadConfig(Resource.ReportXMLPath);
        }


        [TearDown]
        public void TearDown()
        {
          
            extent.EndTest(test);
            extent.Flush();
         
        }
        #endregion
    }
}

  #endregion