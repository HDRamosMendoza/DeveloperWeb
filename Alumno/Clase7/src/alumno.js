import $ from "jquery";
import "./scss/app.scss";

$(function() {
    console.log("Hola Soy el EXITO");
    $.ajax("http://localhost:59760/api/alumno")
    .done(function(response){
        $("#payload").html(JSON.stringify(response));



    });
});

console.log("Hola desde webpack s2");

/*
    // Manejar el evento click de la tabla, pero 
    // SOLO para el link de eliminar.
    $tableBody.on("click", ".link-eliminar", function() {
        // Obtener el ID del link al que se hizo click
        var id = $(this).data("id");

        // Eliminar el registro mediante el servicio web.
        $.ajax({
            url: `http://localhost:59760/api/alumnos/${id}`,
            method: "DELETE"
        }).done(function (response) {
            alert(`Se eliminó el alumno con ID: ${response.Id}`);

            // Actulizar tabla
            actualizarTabla();
        });
    });

*/
