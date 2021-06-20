using Bot.Zoom.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Bot.Zoom.Settings
{
    public  class BotZoomSettings: IBotZoomSettings
    {
        private readonly IConfiguration _configuration;
        public BotZoomSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetValue<string>("BootZoomSettings:ConnectionString");
    }
}
