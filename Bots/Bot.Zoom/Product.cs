namespace Bot.Zoom
{
    public class Product
    {
        public Product(string nameProduct)
        {
            NameProduct = nameProduct;
        }   
        public string NameProduct { get; set; }
        public string Title { get; set; }
        public string imageUrl { get; set; }
        public string urlProductWebSite { get; set; }
        public string Price { get; set; }

    }
}
