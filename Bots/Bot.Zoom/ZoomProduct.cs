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
            string rooUrl = "https://www.zoom.com.br";
            string searchUrl = @"/search?q=" + productName + "";
            string url = string.Format("{0}{1}", rooUrl, searchUrl);
            string markup;

            using (WebClient client = new WebClient())
            {
                markup = client.DownloadString(url);
            }

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(markup);

            var divs = html.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("SearchPage_SearchList__HL7RI col")).ToList();

            foreach (var div in divs)
            {
                var divProducts = div.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("card card--prod")).ToList();

                foreach (var divProduct in divProducts)
                {
                    product.urlProductWebSite = string.Format("{0}{1}", rooUrl, divProduct.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value);
                    product.imageUrl = divProduct.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value;

                    GetPriceProduct(divProduct, product);

                }
            }

            return await Task.FromResult(product);
        }

        private static void GetPriceProduct(HtmlNode products, Product product)
        {
            var divCardInfo = products.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "").Equals("cardInfo")).ToList();

            foreach (var priceProduct in divCardInfo)
            {
                product.Price = priceProduct.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("customValue")).FirstOrDefault().InnerText;
            }
        }
    }
}
