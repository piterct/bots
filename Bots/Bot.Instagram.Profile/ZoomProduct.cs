using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bot.Zoom
{
    public static class ZoonmProduct
    {
        public async static ValueTask<Product> GetProduct(string productName)
        {
            var product = new Product(productName);
            string url = @"https://www.zoom.com.br/search?q=" + productName + "";
            string markup;

            using (WebClient client = new WebClient())
            {
                markup = client.DownloadString(url);
            }

           HtmlDocument html = new HtmlDocument();
           html.LoadHtml(markup);

            var divs = html.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("SearchPage_SearchList__HL7RI col")).ToList();

            foreach(var div in divs)
            {
               // var divProducts = div.Descendants("div").ToList();

                var divProducts = div.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("card card--prod")).ToList();

                foreach (var divProduct in divProducts)
                {
                    var cardBody = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                    var imageUrl = div.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value;
                    var title = div.Descendants("img").FirstOrDefault().ChildAttributes("title").FirstOrDefault().Value;
                }
            }

            return await Task.FromResult(product);
        }
    }
}
