// var [calcular, calcular2] = require("./utils.js");

function pruebas() {
    console.log("Factorial de 10", calcular(10));

    // importar la función de otro archivo

    console.log("Hola Mundo!");

    console.log("Prueba multiplicación", 3 * "2");
    console.log("Prueba multiplicación alt", "2" * "aaa");

    console.log("concatenar", 2 + "2");

    console.log("interpolación de caracteres", `El resultado de 2*3 = ${2 * 3}`);

    // variables
    const pi = 3.14;

    console.log("El valor de pi es", pi)

    let a = 3;
    a = 4;

    var b = 1;
    b = [1, 2, 3, "4"]

    console.log("valor de b", b)

    // pi = 4;

    {
        var a1 = 8;
    }

    console.log(a1);

    console.log(`Pi es igual a 3.14? ${pi === 3.14 ? "Sí" : "No"}`)

    var hola = null;

    if (hola)
        console.log("Existe la variable hola");
    else
        console.log("No existe la variable hola");

}

function incializarPagina(){
    const elemento = document.body;
    elemento.innerHTML += "<div>Hola desde JS</div>";    

    // obtener elementos por su ID
    const lista = document.getElementById("lista-personas");
    lista.style.backgroundColor = "#ff0000";

    // obtienes el h1
    const h1 = document.getElementsByTagName("h1");
    h1[0].insertAdjacentHTML("afterend","<div>Insertado entre elementos</div>")
}

incializarPagina();