namespace Bot.Zoom
{
    public class Product
    {
        public Product(string nameProduct)
        {
            NameProduct = nameProduct;
        }   
        public string NameProduct { get; set; }
        public string IosAppName { get; set; }
        public string IosAppId { get; set; }
        public string IosUrl { get; set; }
        public string AndroidAppName { get; set; }
        public string AndroidAppId { get; set; }
        public string AndroidUrl { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
