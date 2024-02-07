using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace plataforma_automatizada.utils
{
    /// <summary>
    /// Contiene metodos para auxiliar a las pruebas.
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Configura y retorna un IWebDriver.
        /// </summary>
        /// <returns>Driver configurado.</returns>
        public static IWebDriver DriverConfiguration()
        {
            ChromeOptions options1 = new ChromeOptions();
            options1.AddArguments("start-maximized");
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            IWebDriver driverRetorno = new ChromeDriver(options1);
            driverRetorno.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driverRetorno;
        }

        /// <summary>
        /// Toma una captura de pantalla.
        /// </summary>
        /// <param name="driver">Driver previamente configurado.</param>
        /// <returns>Captura codificada en Base64.</returns>
        public static string GetScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}