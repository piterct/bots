using Bot.Zoom.Interfaces;
using Bot.Zoom.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Bot.Zoom.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBotZoomSettings _botZoomSettings;
        public ProductRepository(IBotZoomSettings botZoomSettings)
        {
            _botZoomSettings = botZoomSettings;
        }

        public async ValueTask<bool> InsertProducts(List<Product> products)
        {
            int rows = 0;

            using (var connection = new SqlConnection(_botZoomSettings.ConnectionString))
            {
                foreach (var product in products)
                {

                    rows = await connection.ExecuteAsync(@"INSERT INTO Product VALUES (@Title, @NameProductSearch, @ImageUrl, @UrlProductWebSite, @DescriptionPrice, @Price)",
                           new { product.Title, product.NameProductSearch, product.ImageUrl, product.UrlProductWebSite, product.DescriptionPrice, product.Price });
                }

            }


            return rows > 0;
        }
    }
}
