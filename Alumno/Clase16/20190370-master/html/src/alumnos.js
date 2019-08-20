import $ from "jquery";
import "./scss/app.scss";

$(function () {
    // obtener el body de la tabla con jQuery
    var $tableBody = $("#tabla-alumnos tbody");

    // actualizar la tabla    
    actualizarTabla();

    // para que la función se llame a si misma:
    // (function(){})()

    function actualizarTabla() {
        // limpiar el tbody en caso tenga filas
        $tableBody.html("");

        // llamar al servicio para obtener la lista de alumnos
        $.ajax("http://localhost:59760/api/alumnos")
            .done(function (response) {
                console.table(response);
                // mostrar la información en la tabla            
                response.forEach(function (alumno) {
                    // por cada alumno se va a crear una fila
                    var filaHtml = `
            <tr>
                <td>${alumno.Id}</td>
                <td>${alumno.Nombre}</td>
                <td>${alumno.Edad}</td>
                <td>${alumno.Grado}</td>
                <td>${alumno.Seccion}</td>
                <td>${alumno.Foto ? alumno.Foto : "No Existe"}</td>
                <td>
                    <a class='link-editar' href='./edit.html?id=${alumno.Id}'>Editar</a>
                    <a class='link-eliminar' data-id=${alumno.Id} href='#'>Eliminar</a>
                </td>
            </tr>
        `
                    // agregamos la fila al body de la tabla
                    $tableBody.append(filaHtml);
                })
            });
    }

    // manejar el evento click de la tabla, pero SOLO para el link de eliminar
    $tableBody.on("click", ".link-eliminar", function () {
        // obtener el id del link al que se hizo click
        var id = $(this).data("id");

        // eliminar el registro mediante el servicio web
        $.ajax({
            url: `http://localhost:59760/api/alumnos/${id}`,
            method: "DELETE"
        }).done(function (response) {
            alert(`Se eliminó el alumno con ID: ${response.Id}`);

            // actualizar tabla
            actualizarTabla();
        })
    })
})