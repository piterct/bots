using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;

namespace Bot.Instagram.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"D:\Meus Documentos\Documentos\Repositorios\bots\Bots\Driver");

            webDriver.LoadPage(TimeSpan.FromSeconds(10), "https://www.google.com.br");

            Console.ReadKey();
        }
    }
}
