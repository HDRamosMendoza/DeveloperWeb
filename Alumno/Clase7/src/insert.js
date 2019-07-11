import $ from "jquery";
import "./scss/app.scss";

$(function() {
    // Configurar el evento click del boton
    $("#btnGuardar").on("click", function() {
        var nuevoId = 0;
        // Crear un objeto para enviar la informacion al servicio web.
        var objetoGuardar = {
            nombre: $("#nombre").val(),
            edad: $("#edad").val(),
            grado: $("#grado").val()
        }

        // Enviar la data al servicio web para registrar
        $.ajax({
            method: "POST",
            url: "http://localhost:5970/api/alumnos",
            data: objetoGuardar
        })
        .done(function (response) {
            // Si se ejecuta esta funcion significa que se ha registrado
            // el alumno satisfactoriamente
            // Mostrar el nuevo ID en la alerta
            $("#alerta").html(`El ID del alumno es: ${response.Id}`);
            $("#alerta").show();
        })
    });
});