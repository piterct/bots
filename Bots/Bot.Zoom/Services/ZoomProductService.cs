using Bot.Zoom.Models;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bot.Zoom.Services
{
    public static class ZoonmProductService
    {
        public async static ValueTask<List<Product>> GetProduct(string productName)
        {
            string rooUrl = "https://www.zoom.com.br";
            List<Product> products = new List<Product>();

            var html = await GetHtmlWebSite(rooUrl, productName);


            var divs = html.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("SearchPage_SearchList__HL7RI col")).ToList();

            foreach (var div in divs)
            {
                var divProducts = div.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("card card--prod")).ToList();

                if (divProducts.Count == 0)
                    divProducts = div.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "").Equals("card card--offer card--cpc")).ToList();

                foreach (var divProduct in divProducts)
                {
                    Product product = new Product();

                    product.NameProductSearch = productName;
                    product.urlProductWebSite = string.Format("{0}{1}", rooUrl, divProduct.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value);
                    product.Title = divProduct.Descendants("img").FirstOrDefault().ChildAttributes("title").FirstOrDefault().Value.Replace("&quot;", "'");
                    product.imageUrl = divProduct.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value;

                    GetPriceProduct(divProduct, product);

                    products.Add(product);
                }


            }

            return await Task.FromResult(products);
        }

        public async static ValueTask<HtmlDocument> GetHtmlWebSite(string url, string productName)
        {
            string searchUrl = @"/search?q=" + productName + "";
            string completeUrl = string.Format("{0}{1}", url, searchUrl);
            string markup;
           
            using (WebClient client = new WebClient())
            {
                markup = client.DownloadString(completeUrl);
            }

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(markup);

            return await Task.FromResult(html);
        }

        private static void GetPriceProduct(HtmlNode products, Product product)
        {
            string uselessCoin = "R$";
            var divCardInfo = products.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "").Equals("cardInfo")).ToList();

            foreach (var priceProduct in divCardInfo)
            {
                product.DescriptionPrice = priceProduct.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("customValue"))?.FirstOrDefault()?.InnerText;
                product.Price = product.DescriptionPrice == null ? 0.00M : Convert.ToDecimal(product.DescriptionPrice.Substring(uselessCoin.Length));
            }
        }
    }
}
