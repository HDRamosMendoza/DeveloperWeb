window.addEventListener("load", function () {
    // obtener los controles para su manipulación
    var txtId = document.getElementById("idNave");
    var btnConsultar = document.getElementById("btnConsulta");
    var spnNombre = document.getElementById("spnNombre");
    var spnModelo = document.getElementById("spnModelo");
    var ulFilms = document.getElementById("ulFilms");

    btnConsultar.addEventListener("click", function (event) {
        event.preventDefault();
        var idConsultar = txtId.value;
        
        // limpiar data
        ulFilms.innerHTML = "";
        spnModelo.innerHTML = "";
        spnNombre.innerHTML = "";

        fetch(`https://swapi.co/api/starships/${idConsultar}`)
            .then(function (response) {
                return response.json();
            })
            .then(function (data) {
                if (data) {
                    spnNombre.innerHTML = data.name;
                    spnModelo.innerHTML = data.model;
                    if (data.films && data.films.length > 0) {
                        for (var film of data.films) {
                            var html = `<li>${film}</li>`;
                            ulFilms.innerHTML += html;
                        }
                    }
                }
            })
    })
})