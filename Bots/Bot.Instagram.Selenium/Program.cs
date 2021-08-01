using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bot.Instagram.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"D:\Meus Documentos\Documentos\Repositorios\bots\Bots\Driver");


            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(5), "https://www.instagram.com");
                webDriver.WaitFindElement(By.Name("username"));
                webDriver.SetText(By.Name("username"), "michael");
                webDriver.SetText(By.Name("password"), "mypassword");
                webDriver.Submit(By.TagName("button"));

                Thread.Sleep(TimeSpan.FromSeconds(3));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
