﻿using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Configuration;
using System.Threading;

namespace Bot.Instagram.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"D:\Meus Documentos\Documentos\Repositorios\bots\Bots\Driver");

            string userName = ConfigurationManager.AppSettings["UserName"];
            string passWord = ConfigurationManager.AppSettings["Password"];


            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(5), "https://www.instagram.com");
                webDriver.WaitFindElement(By.Name("username"));
                webDriver.SetText(By.Name("username"), userName);
                webDriver.SetText(By.Name("password"), passWord);
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
