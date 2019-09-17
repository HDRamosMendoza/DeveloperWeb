using Cibertec.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Hubs
{
    public class ProductsHub : Hub
    {
        public async Task ModificarProducto(Product product)
        {
            await Clients.All.SendAsync("actualizarLista", product);
        }
    }
}
