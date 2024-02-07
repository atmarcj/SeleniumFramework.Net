using NUnit.Framework;
using OpenQA.Selenium;
using plataforma_automatizada.pages;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.test
{
    class TestBase
    {
        protected ExtentManager extentManager;
        protected ExcelManager excelManager;
        protected static IWebDriver driver;
        protected Google google;

        [OneTimeSetUp]
        public void AntesDeTodosLosTest()
        {
            extentManager = new ExtentManager();
            excelManager = new ExcelManager();
        }

        [SetUp]
        public void AntesDeCadaTest()
        {
            driver = Utils.DriverConfiguration();
            google = new Google(driver);
        }

        [TearDown]
        public void DespuesDeCadaTest()
        {
            extentManager.AddTestResult(driver);
            extentManager.EndTest();
            google.CerrarNavegador();
        }

        [OneTimeTearDown]
        public void DespuesDeTodosLosTest()
        {
            excelManager.SaveAs();
        }
    }
}
