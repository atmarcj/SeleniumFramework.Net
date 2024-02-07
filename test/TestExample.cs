using NUnit.Framework;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.test
{
    class TestExample : TestBase
    {
        [Description("Test de ejemplo.")]
        [TestCaseSource(typeof(ExcelManager), nameof(ExcelManager.GetExcelValues))]
        public void BuscarEnGoogle(string data1, string data2, string data3, string data4)
        {
            //Declaracion de variables
            string texto = ParameterReader.GetTestValues("TestExample", "Texto");
            string resultadoEsperado = ParameterReader.GetTestValues("TestExample", "ResultadoEsperado");

            //Creamos instancia de test para agregar al reporte HTML
            extentManager.CreateTest("Nombre del test", "Descripcion del test.");

            //Agregamos log al reporte HTML
            extentManager.AddLog(StatusTest.INFO, "Ingresamos a: " + ParameterReader.GetEnvironment("UrlEnvironment"));

            //Pasos del script
            google.EscribirTexto(texto);
            extentManager.AddLog(StatusTest.INFO, $"Ingreso de texto {texto}.");
            google.ClickBuscar();
            extentManager.AddLog(StatusTest.INFO, $"Click en buscar.");
            google.SeleccionarResultado();
            extentManager.AddLog(StatusTest.INFO, $"Seleccionamos resultado.");

            //Verificacion
            Assert.That(google.OtenerTituloPagina(), Is.EqualTo(resultadoEsperado));
            extentManager.AddLog(StatusTest.PASS, $"Verificamos correctamente el resultado esperado: {resultadoEsperado}.");

            //para agregar datos al excel
            excelManager.AddData(new string[] { data1, data2, data3, data4 });
        }
    }
}
