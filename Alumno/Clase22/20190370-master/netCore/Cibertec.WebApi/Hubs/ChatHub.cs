using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            // cuando un usuario se conecte, vamos a transmitir un evento a los demas usuarios para que se enteren
            await Clients.Others.SendAsync("nuevaConexion");
            await base.OnConnectedAsync();
        }
        public async Task EnviarMensaje(string mensaje, string userName)
        {
            // cada vez que alguien invoque esta función vamos a transmitirlo (broadcast) a todos los demás clientes conectados a este hub
            await Clients.All.SendAsync("mensajeRecibido", mensaje, userName);
        }
    }
}
