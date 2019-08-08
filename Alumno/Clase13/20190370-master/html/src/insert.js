import $ from "jquery";
import "./scss/app.scss";

$(function(){
    var $btn = $("#btnGuardar");
    // configurar el evento click del botón
    $btn.on("click",function(){
        var nuevoId = 0;
        
        // crear un objeto para enviar la información al servicio web
        var objetoGuardar = {
            nombre: $("#nombre").val(),
            edad: $("#edad").val(),
            grado: $("#grado").val()
        }

        // enviar la data al servicio web para registrar
        $.ajax({
            method: "POST",
            url: "http://localhost:59760/api/alumnos",
            data: objetoGuardar
        })
        .done(function(response){
            // si se ejecuta esta función significa que se ha registrado el alumno satsifactoriamente

            // mostrar el nuevo ID en la alerta
            $("#alerta").html(`El ID del alumno es: ${response.Id}`);
            $("#alerta").removeClass("d-none");            
        })
    })
})