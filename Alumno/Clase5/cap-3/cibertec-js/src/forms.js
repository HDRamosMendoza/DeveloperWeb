// document.addEventListener("DOMContent");
window.addEventListener("load", function(event) {
    let btnGuardar = document.getElementById("btnGuardar");
    let txtNombre = document.getElementById("txtNombre");
    let cbxPais = document.getElementById("cbxPais");

    obtenerDataPaises(cbxPais);

    btnGuardar.addEventListener("click", function(e) {
        e.preventDefault();
        var objPersona = {
            nombre : txtNombre.value,
            paisValue : cbxPais.value,
            paisText : cbxPais.options[cbxPais.selectedIndex].text,
        }
        console.log("Objeto", objPersona);

    });

    function obtenerDataPaises(selPais) {
        fetch("http://restcountries.eu/rest/v2/all")
            .then(function (response){
                console.log("raw response", response);
                return response.json();
            }
            .then(function (data) {
                console.log("formatted response", data);

                for(var pais of data) {
                    console.log(pais.name);
                    console.log(pais.alpha2Code);

                    var html = `<option value='${pais.alpha2Code}'>${pais.name}</option>`
                    // html = "<option>"
                    // Falta agregar codigo del TEACHER 
                    selPais.innerHTML += html;
                }

            })
            

    }
});