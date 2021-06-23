using Bot.Zoom.Interfaces;

namespace Bot.Zoom.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBotZoomSettings _botZoomSettings;
        public ProductRepository(IBotZoomSettings botZoomSettings)
        {
            _botZoomSettings = botZoomSettings;
        }
    }
}
