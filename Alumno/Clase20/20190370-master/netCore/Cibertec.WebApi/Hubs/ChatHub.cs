using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Hubs
{
    public class ChatHub: Hub
    {
        public async Task EnviarMensaje(string mensaje)
        {
            // Cada vez que alquien invoque esta funcion vamos a transmitirlo
            // (broadcast) a todos los demas clientes conectados a este hub.
            await Clients.All.SendAsync("mensajeRecibido", mensaje);


        }

    }
}
