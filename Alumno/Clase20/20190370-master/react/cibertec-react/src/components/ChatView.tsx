import React from "react";

const ChatView: React.FC = ()=> {
    // Instanciar conexion
    const newHubConnection = new SingalR.HubConnectionBuilder().withUrl("https://localhost:5001/chathub").build();
    // El codigo que se va a ejecutar cuando reciba un nuevo mensaje del hub.
    newHubConnection.on("mensajeRecibido", function(mensaje:string){
        console.log("Nuevo mensaje", mensaje);
    });
    //const hand 
    return(
        <div>
            <div>
                <h2>Mensajes</h2>
                <ul id="lista-mensajes"></ul>
            </div>
            <form action="" onSubmit={}>
                <div className="field">
                    <label className="field"></label>
                    <div className="control">
                        <input className="input" type="text"
                            placeholder="Ingrese un mensaje"
                            name="supplierId"/>

                    </div>
                </div>
                <div className="control">
                    <button className="button is-primary">
                        Enviar
                    </button>
                </div>
            </form>
        </div>
    );
}