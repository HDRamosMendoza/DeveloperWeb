import $ from "jquery"

$(function() {
    console.log("Hola Soy el EXITO");
    $.ajax("http://localhost:59760/api/alumno")
    .done(function(response){
        $("#payload").html(JSON.stringify(response));
    });
});

console.log("Hola desde webpack s2");