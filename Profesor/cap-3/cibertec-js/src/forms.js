window.addEventListener("load", function () {
    var btn = document.getElementById("btn");
    var txtNombre = document.getElementById("nombre");
    var selPais = document.getElementById("pais");

    obtenerDataPaises(selPais);

    btn.addEventListener("click", function (event) {
        // para evitar que la página se actualice
        event.preventDefault();
        console.log("Se presionó el botón");

        // capturar los valores de los inputs
        var objPersona = {
            nombre: txtNombre.value,
            paisValue: selPais.value,
            paisText: selPais.options[selPais.selectedIndex],
        }

        console.log("objeto", objPersona);
    })
})

function obtenerDataPaises(selPais) {
    // obtener información de un servicio
    fetch("https://restcountries.eu/rest/v2/all")
        .then(function (response) {
            console.log("raw response", response);
            return response.json();
        })
        .then(function (data) {
            // la data ya está cargada y formateada
            console.log("formatted response", data);
            // insertar las opciones dentro del select

            for(var pais of data){
                console.log(pais.name);
                console.log(pais.alpha2Code);
                var html = `<option value='${pais.alpha2Code}'>${pais.name}</option>`
                // html = "<option value='" + pais.alpha2Code + "'>" + pais.name + "</option>"
                selPais.innerHTML+=html;
            }
        })
    
    
}
