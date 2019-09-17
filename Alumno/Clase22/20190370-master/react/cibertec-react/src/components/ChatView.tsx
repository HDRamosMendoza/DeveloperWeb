import React from "react";
import * as SignalR from "@aspnet/signalr";

export const ChatView: React.FC = () => {
    const [hubConnection, setHubConnection] = React.useState<SignalR.HubConnection>();
    const [userName, setUserName] = React.useState();
    const [mensajes, setMensajes] = React.useState<{ name: string, mensaje: string }[]>([]);
    const [mensaje, setMensaje] = React.useState<{ name: string, mensaje: string }>();

    React.useEffect(() => {
        // clonando arreglo            
        const tmpArray = [...mensajes];
        // agregamos un elemento
        if (mensaje) {
            tmpArray.push(mensaje)
            setMensajes(tmpArray)
        }
    }, [mensaje])

    React.useEffect(() => {
        // instanciar conexión
        const newHubConnection = new SignalR.HubConnectionBuilder().withUrl("https://192.168.14.10:5001/chathub").build();

        // el código que se va a ejecutar cuando reciba un nuevo mensaje del hub
        newHubConnection.on("mensajeRecibido", function (mensaje: string, name: string) {
            console.log("Nuevo mensaje:", mensaje);
            console.log("Usuario:", name);
            console.log(mensajes)

            // console.log(tmpArray);
            setMensaje({ name, mensaje });
        })

        // el código que se va a ejecutar cuando un usuario se conecte al chat
        newHubConnection.on("nuevaConexion", function () {
            console.log("Nuevo usuario conectado");
        })

        // inicializar conexión
        newHubConnection.start().catch(error => console.error(error));

        // guardamos la conexión en el state de nuestro componente react
        setHubConnection(newHubConnection);

        // mostrar un prompt para pedir el nombre de usuario
        const name = prompt("Ingrese un nombre de usuario");
        setUserName(name);
    }, [])

    const mostrarMensajes = () => {
        const arregloMensajesView = mensajes.map((item, index) => {
            return <li key={index}><b>{item.name}</b>:{item.mensaje}</li>
        })

        return arregloMensajesView;
    }

    const handleSubmit = (e: any) => {
        e.preventDefault();
        const [messageInput] = e.target.elements;
        console.log("mensaje a enviar", messageInput.value);
        if (hubConnection) {
            hubConnection.send("enviarMensaje", messageInput.value, userName).then(() => messageInput.value = "");
        }
    }
    return (
        <div>
            <div>
                <h2>Mensajes</h2>
                <ul id="lista-mensajes">
                    {mostrarMensajes()}
                </ul>
            </div>
            <form action="" onSubmit={handleSubmit}>
                <div className="field">
                    <label className="label">Mensaje</label>
                    <div className="control">
                        <input className="input" type="text" placeholder="Ingrese un Mensaje" name="supplierId" required />
                    </div>
                </div>
                <div className="control">
                    <button className="button is-primary">Enviar</button>
                </div>
            </form>
        </div>
    )
}
