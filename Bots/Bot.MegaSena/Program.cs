using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace Bot.MegaSena
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add competition number: ");
            string competitionNUmber = Console.ReadLine();
            string finalNumbers = string.Empty;

            string url = string.Format("http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage//p=concurso={0}?timestampAjax=1623475384093", competitionNUmber);
            string json;

            using (WebClient client = new WebClient())
            {
                client.Headers["Cookie"] = "security=true";
                json = client.DownloadString(url);
            }

            var competitionResult = JsonConvert.DeserializeObject<Game>(json);

            foreach (var number in competitionResult.ListaDezenas)
            {
                string processedNumber = number.Length > 2 ? number.Substring(1, 2) : number;
                finalNumbers += string.Concat(processedNumber, " ");
            }

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine(string.Format("Result: {0}", finalNumbers));

            Console.ReadKey();
        }
    }
}
