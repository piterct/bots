using Bot.Zoom.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bot.Zoom.Interfaces
{
    public interface IProductRepository
    {
        ValueTask<bool> InsertProducts(List<Product> products);
    }
}
