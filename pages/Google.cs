using OpenQA.Selenium;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.pages
{
    /// <summary>
    /// Clase encargada de manipular la interfaz de Google.
    /// </summary>
    class Google : BasePage
    {
        private readonly By q;
        private readonly By buttonSearch;
        private readonly By resultado;

        public Google(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(ParameterReader.GetEnvironment("UrlEnvironment"));
            q = By.Name(ParameterReader.GetScreenComponents("Google", "Q"));
            buttonSearch = By.Name(ParameterReader.GetScreenComponents("Google", "ButtonSearch"));
            resultado = By.XPath(ParameterReader.GetScreenComponents("Google", "Resultado"));
        }

        public void EscribirTexto(string text)
        {
            Click(q);
            Clear(q);
            SendKeys(q, text);
        }

        public void ClickBuscar()
        {
            Click(buttonSearch);
        }

        public void SeleccionarResultado()
        {
            Click(resultado);
        }

        public string OtenerTituloPagina()
        {
            return Title();
        }

        public void CerrarNavegador()
        {
            Quit();
        }
    }
}
