﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// substr(0, 10) - agarra los primeros 10 caracteres (1234-67-89)

document.getElementById('versus-img')?.setAttribute('draggable', false);


document.getElementById('versus-img2')?.setAttribute('draggable', false);
document.getElementById('imgl1')?.setAttribute('draggable', false);
document.getElementById('imgl2')?.setAttribute('draggable', false);

// TODAVÍA NO FUNCA
// let noDragElements = document.getElementsByClassName('no-drag')
// noDragElements.forEach(element => {
//     element?.setAttribute('draggable', false);
// });


// TOAST
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

//if (document.getElementById('btn-toast')) document.getElementById('btn-toast').click()
document.getElementById('btn-toast')?.click()
document.getElementById('btn-click')?.click()
function MostrarMensaje(){
    $(document).ready(function(){
        $("#toast-mensaje").toast("show");
    });
}

// RANDOM 
var antRandom
function randomIntFromInterval(min, max) { // min and max included 
    antRandom = Math.floor(Math.random() * (max - min + 1) + min) 
    return antRandom
}

function EstadisticasAleatorias() {
    $("#mod-IQ_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-IQ_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-Fuerza_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-Fuerza_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-Velocidad_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-Velocidad_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-Resistencia_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-Resistencia_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-BattleIQ_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-BattleIQ_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-PoderDestructivo_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-PoderDestructivo_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-Experiencia_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-Experiencia_max").attr("value", randomIntFromInterval(antRandom, 250))
    $("#mod-Transformaciones_min").attr("value", randomIntFromInterval(0, 250))
    $("#mod-Transformaciones_max").attr("value", randomIntFromInterval(antRandom, 250))
}

var myChart 
function DetalleLuchador(IdLuchador)
{
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: 'Home/DevolverLuchador',
            data:{IdLuchador: IdLuchador},
            success:
                function (response)
                {
                    $("#TituloDetalleLuchador").html("Detalles - " + response.nombre);

                    $("#Foto").attr("src", "/img/luchadores/" + response.foto + "?" + Math.round(Math.random()*10000))
                    $("#Victorias").html(response.victorias)
                    $("#FechaNacimiento").html(response.fechaNacimiento.split("T")[0].replace("-", "/").replace("-", "/"))

                    $("#IQ").html("<b>IQ:</b> " + response.iQ_min + " - " + response.iQ_max)
                    $("#Fuerza").html("<b>Fuerza:</b> " + response.fuerza_min + " - " + response.fuerza_max)
                    $("#Velocidad").html("<b>Velocidad:</b> " + response.velocidad_min + " - " + response.velocidad_max)
                    $("#Resistencia").html("<b>Resistencia:</b> " + response.resistencia_min + " - " + response.resistencia_max)
                    $("#BattleIQ").html("<b>Battle IQ:</b> " + response.battleIQ_min + " - " + response.battleIQ_max)
                    $("#PoderDestructivo").html("<b>Poder Destructivo:</b> " + response.poderDestructivo_min + " - " + response.poderDestructivo_max)
                    $("#Experiencia").html("<b>Experiencia:</b> " + response.experiencia_min + " - " + response.experiencia_max)
                    $("#Transformaciones").html("<b>Transformaciones:</b> " + response.transformaciones_min + " - " + response.transformaciones_max)
                    
                    var labels = [
                        'IQ',
                        'Fuerza',
                        'Velocidad',
                        'Resistencia',
                        'BattleIQ',
                        'PoderDestructivo',
                        'Experiencia',
                        'Transformaciones',
                    ];
                    var data = {
                    labels: labels,
                    datasets: [{
                        label: 'Estadísticas',
                        data: [Math.round((response.iQ_min + response.iQ_max) / 2), Math.round((response.fuerza_min + response.fuerza_max) / 2), Math.round((response.velocidad_min + response.velocidad_max) / 2), Math.round((response.resistencia_min + response.resistencia_max) / 2), Math.round((response.battleIQ_min + response.battleIQ_max) / 2), Math.round((response.poderDestructivo_min + response.poderDestructivo_max) / 2), Math.round((response.experiencia_min + response.experiencia_max) / 2), Math.round((response.transformaciones_min + response.transformaciones_max) / 2), 250],
                        backgroundColor: [

                        'rgba(75, 192, 192, 0.5)',
                        'rgba(54, 162, 235, 0.5)',
                        'rgba(70, 82, 255, 0.5)',
                        'rgba(153, 102, 255, 0.5)',
                        'rgba(255, 102, 235, 0.5)',
                        'rgba(255, 99, 132, 0.5)',
                        'rgba(255, 159, 64, 0.5)',
                        'rgba(255, 205, 86, 0.5)',
                        'rgba(121, 235, 93, 0.5)',
                        ],
                        borderColor: [
                        'rgb(75, 192, 192)',
                        'rgb(54, 162, 235)',
                        'rgb(70, 82, 255)',
                        'rgb(153, 102, 255)',
                        'rgb(255, 102, 235)',
                        'rgb(255, 99, 132)',
                        'rgb(255, 159, 64)',
                        'rgb(255, 205, 86)',
                        'rgb(121, 235, 93)',
                        ],
                        borderWidth: 1
                        
                    }]
                    };
                    var config = {
                        type: 'bar',
                        data: data,
                        options: {
                            responsive: true,
                          indexAxis: 'x', // cambiar a 'y' para que se vea horizontal
                          scales: {
                            y: {
                                beginAtZero: true
                            },
                          }
                        },
                      };
                    if (myChart) myChart.destroy()
                    myChart = new Chart(document.getElementById('myChart'),config);
                } 
        }
    );
}

function ConfirmarEliminar(IdLuchador)
{
    
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: 'Home/DevolverLuchador',
            data:{IdLuchador: IdLuchador},
            success:
                function (response)
                {
                    $("#ce-titulo").html("<b>¡Está a punto de eliminar un luchador!<b>");
                    $("#ce-body").html("¿Está seguro de que quiere eliminar al luchador <b>" + response.nombre + "</b>?");
                    $("#ConfirmarEliminar").attr("href", "/Home/EliminarLuchador/?IdLuchador=" + response.idLuchador) //response.idLuchador +
                    
                }
        }
    );
}
function ConfirmarEliminarRegistro(IdRegistro)
{
    
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: '/Home/DevolverRegistro',
            data:{IdRegistro: IdRegistro},
            success:
                function (response)
                {
                    $("#ce-titulo").html("<b>¡Está a punto de eliminar un registro!<b>");
                    $("#ce-body").html("¿Está seguro de que quiere eliminar al registro #<b>" + IdRegistro + "</b>?");
                    $("#ConfirmarEliminar").attr("href", "/Home/EliminarRegistro/?IdRegistro=" + response.idRegistro)
                    
                }
        }
    );
}
function ModificarJugador(IdLuchador)
{
    
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: 'Home/DevolverLuchador',
            data:{IdLuchador: IdLuchador},
            success:
                function (response)
                {
                    $("#mod-id").attr("value", response.idLuchador);
                    
                    $("#mod-title").html("<b>Podés modificar lo que quieras!</b>")
                    $("#mod-Nombre").attr("value", response.nombre)
                    $("#mod-FechaNacimiento").attr("value", response.fechaNacimiento.split("T")[0])
                    $("#mod-MyFile").attr("value", response.foto)
                    $("#mod-IQ_min").attr("value", response.iQ_min)
                    $("#mod-IQ_max").attr("value", response.iQ_max)
                    $("#mod-Fuerza_min").attr("value", response.fuerza_min)
                    $("#mod-Fuerza_max").attr("value", response.fuerza_max)
                    $("#mod-Velocidad_min").attr("value", response.velocidad_min)
                    $("#mod-Velocidad_max").attr("value", response.velocidad_max)
                    $("#mod-Resistencia_min").attr("value", response.resistencia_min)
                    $("#mod-Resistencia_max").attr("value", response.resistencia_max)
                    $("#mod-BattleIQ_min").attr("value", response.battleIQ_min)
                    $("#mod-BattleIQ_max").attr("value", response.battleIQ_max)
                    $("#mod-PoderDestructivo_min").attr("value", response.poderDestructivo_min)
                    $("#mod-PoderDestructivo_max").attr("value", response.poderDestructivo_max)
                    $("#mod-Experiencia_min").attr("value", response.experiencia_min)
                    $("#mod-Experiencia_max").attr("value", response.experiencia_max)
                    $("#mod-Transformaciones_min").attr("value", response.transformaciones_min)
                    $("#mod-Transformaciones_max").attr("value", response.transformaciones_max)

                    $("#fj-submit").html("Actualizar");
                    $("#fj-form").attr("action", "/Home/ActualizarLuchador") 
                    $("#fj-submit").attr("href", "/Home/ActualizarLuchador/?luchador=" + response) // '@Url.Action("ActualizarLuchador", "Home", new {luchador=luchador,})'
                }
        }
    );
}
function AgregarJugador()
{
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: 'Home/DevolverLuchador',
            success:
                function (response)
                {
                    $("#mod-id").attr("value", null);

                    $("#mod-title").html("<b>A un paso de crear tu luchador personalizado!</b>")
                    $("#mod-Nombre").attr("value", null)
                    $("#mod-FechaNacimiento").attr("value", null)
                    $("#mod-MyFile").attr("value", null)
                    $("#mod-IQ_min").attr("value", null)
                    $("#mod-IQ_max").attr("value", null)
                    $("#mod-Fuerza_min").attr("value", null)
                    $("#mod-Fuerza_max").attr("value", null)
                    $("#mod-Velocidad_min").attr("value", null)
                    $("#mod-Velocidad_max").attr("value", null)
                    $("#mod-Resistencia_min").attr("value", null)
                    $("#mod-Resistencia_max").attr("value", null)
                    $("#mod-BattleIQ_min").attr("value", null)
                    $("#mod-BattleIQ_max").attr("value", null)
                    $("#mod-PoderDestructivo_min").attr("value", null)
                    $("#mod-PoderDestructivo_max").attr("value", null)
                    $("#mod-Experiencia_min").attr("value", null)
                    $("#mod-Experiencia_max").attr("value", null)
                    $("#mod-Transformaciones_min").attr("value", null)
                    $("#mod-Transformaciones_max").attr("value", null)

                    $("#fj-submit").html("Crear"); 
                    $("#fj-form").attr("action", "/Home/GuardarLuchador") // '@Url.Action("GuardarLuchador", "Home")'
                    $("#fj-submit").attr("href", "/Home/GuardarLuchador/?luchador=" + response) // '@Url.Action("GuardarLuchador", new {luchador=luchador, random=random})'
                }
        }
    );
}

var myChart2
var myChartVictorias
function EstadisticasLuchadores()
{
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: '/Home/DevolverListaLuchadores',
            success:
                function (response)
                {
                    let labels = response.map(e=>e.nombre)
                    
                    let datasets_data = []
                    for (let luchador of response) {
                        let total = 0, count = 0
                        for(let p in luchador) {
                            if (p.includes("_min") || p.includes("_max")) {
                                count++
                                total+=luchador[p]
                            }
                        }
                        datasets_data.push(Math.round(total / count))
                    }
                    datasets_data.push(250)
                    // --------------------------------------
                    let datasets_iQ = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.iQ_min + luchador.iQ_max
                        datasets_iQ.push(Math.round(total / 2))
                    }
                    datasets_iQ.push(250)

                    let datasets_fuerza = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.fuerza_min + luchador.fuerza_max
                        datasets_fuerza.push(Math.round(total / 2))
                    }
                    datasets_fuerza.push(250)

                    let datasets_velocidad = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.velocidad_min + luchador.velocidad_max
                        datasets_velocidad.push(Math.round(total / 2))
                    }
                    datasets_velocidad.push(250)

                    let datasets_resistencia = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.resistencia_min + luchador.resistencia_max
                        datasets_resistencia.push(Math.round(total / 2))
                    }
                    datasets_resistencia.push(250)

                    let datasets_battleIQ = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.battleIQ_min + luchador.battleIQ_max
                        datasets_battleIQ.push(Math.round(total / 2))
                    }
                    datasets_battleIQ.push(250)

                    let datasets_poderDestructivo = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.poderDestructivo_min + luchador.poderDestructivo_max
                        datasets_poderDestructivo.push(Math.round(total / 2))
                    }
                    datasets_poderDestructivo.push(250)

                    let datasets_experiencia = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.experiencia_min + luchador.experiencia_max
                        datasets_experiencia.push(Math.round(total / 2))
                    }
                    datasets_experiencia.push(250)

                    let datasets_transformaciones = []
                    for (let luchador of response) {
                        let total = 0
                        total = luchador.transformaciones_min + luchador.transformaciones_max
                        datasets_transformaciones.push(Math.round(total / 2))
                    }
                    datasets_transformaciones.push(250)
                    // --------------------------------------
                    let data = {
                    labels: labels,
                    datasets: [{
                        label: 'PROMEDIO',
                        data: datasets_data,
                        backgroundColor: [
                        'rgba(75, 192, 192, 0.5)',
                        'rgba(54, 162, 235, 0.5)',
                        'rgba(70, 82, 255, 0.5)',
                        'rgba(153, 102, 255, 0.5)',
                        'rgba(255, 102, 235, 0.5)',
                        'rgba(255, 99, 132, 0.5)',
                        'rgba(255, 159, 64, 0.5)',
                        'rgba(255, 205, 86, 0.5)',
                        'rgba(121, 235, 93, 0.5)',
                        ],
                        borderColor: [
                        'rgb(75, 192, 192)',
                        'rgb(54, 162, 235)',
                        'rgb(70, 82, 255)',
                        'rgb(153, 102, 255)',
                        'rgb(255, 102, 235)',
                        'rgb(255, 99, 132)',
                        'rgb(255, 159, 64)',
                        'rgb(255, 205, 86)',
                        'rgb(121, 235, 93)',
                        ],
                        borderWidth: 1
                
                    },{
                        label: 'IQ',
                        hidden: true,
                        data: datasets_iQ,
                        backgroundColor: [
                        'rgba(255, 99, 132, 0.5)'
                        ],
                        borderColor: ['rgb(255, 99, 132)'],
                        borderWidth: 1
                
                    },{
                        label: 'Fuerza',
                        hidden: true,
                        data: datasets_fuerza,
                        backgroundColor: ['rgba(255, 159, 64, 0.5)'],
                        borderColor: ['rgb(255, 159, 64)'],
                        borderWidth: 1
                
                    },{
                        label: 'Velocidad',
                        hidden: true,
                        data: datasets_velocidad,
                        backgroundColor: ['rgba(255, 205, 86, 0.5)'],
                        borderColor: ['rgb(255, 205, 86)'],
                        borderWidth: 1
                
                    },{
                        label: 'Resistencia',
                        hidden: true,
                        data: datasets_resistencia,
                        backgroundColor: ['rgba(121, 235, 93, 0.5)'],
                        borderColor: ['rgb(121, 235, 93)'],
                        borderWidth: 1
                
                    },{
                        label: 'BattleIQ',
                        hidden: true,
                        data: datasets_battleIQ,
                        backgroundColor: ['rgba(75, 192, 192, 0.5)',],
                        borderColor: ['rgb(54, 162, 235)'],
                        borderWidth: 1
                
                    },{
                        label: 'PoderDestructivo',
                        hidden: true,
                        data: datasets_poderDestructivo,
                        backgroundColor: ['rgba(70, 82, 255, 0.5)'],
                        borderColor: ['rgb(70, 82, 255)',],
                        borderWidth: 1
                
                    },{
                        label: 'Experiencia',
                        hidden: true,
                        data: datasets_experiencia,
                        backgroundColor: ['rgba(153, 102, 255, 0.5)'],
                        borderColor: ['rgb(153, 102, 255)'],
                        borderWidth: 1
                
                    },{
                        label: 'Transformaciones',
                        hidden: true,
                        data: datasets_transformaciones,
                        backgroundColor: ['rgba(255, 102, 235, 0.5)'],
                        borderColor: ['rgb(255, 102, 235)'],
                        borderWidth: 1
                
                    }]
                    };
                    let config = {
                        type: 'bar',
                        data: data,
                        options: {
                            responsive: true,
                            indexAxis: 'y', // cambiar a 'y' para que se vea horizontal
                            scales: {
                                y: {
                                    beginAtZero: true
                                },
                            }
                        },
                      };
                    if (myChart2) myChart2.destroy()
                    myChart2 = new Chart(document.getElementById('myChart2'),config);

                    let datasets_victorias = []
                    for (let luchador of response) {
                        datasets_victorias.push(luchador.victorias)
                    }
                    datasets_victorias.push(10)

                    var dataVictorias = {
                    labels: labels,
                    datasets: [{
                        label: 'VICTORIAS',
                        hidden: false,
                        data: datasets_victorias,
                        backgroundColor: [
                        'rgba(255, 217, 0, 0.5)',
                        ],
                        borderColor: [
                        'rgb(255, 217, 0)',
                        ],
                        borderWidth: 1
                    }]
                    };
                    var configVictorias = {
                        type: 'bar',
                        data: dataVictorias,
                        options: {
                            responsive: true,
                            stepSize: 1,
                          indexAxis: 'y', // cambiar a 'y' para que se vea horizontal
                          scales: {
                            y: {
                                beginAtZero: true
                            },
                          }
                        },
                      };
                    if (myChartVictorias) myChartVictorias.destroy()
                    myChartVictorias = new Chart(document.getElementById('myChartVictorias'),configVictorias);


                },
                error : function(xhr, status){
                    console.log(xhr, status)
                }
        }
    );
}

document.getElementById('btn-toast2')?.click()
var myChart3
var myChart4
function DetalleLuchadorEnfrentamiento(IdLuchador, chartId)
{
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: 'DevolverLuchador',
            data:{IdLuchador: IdLuchador},
            success:
                function (response)
                {
                    var labels = [
                        'IQ',
                        'Fuerza',
                        'Velocidad',
                        'Resistencia',
                        'BattleIQ',
                        'PoderDestructivo',
                        'Experiencia',
                        'Transformaciones',
                    ];
                    var data = {
                    labels: labels,
                    datasets: [{
                        label: 'Estadísticas',
                        data: [Math.round((response.iQ_min + response.iQ_max) / 2), Math.round((response.fuerza_min + response.fuerza_max) / 2), Math.round((response.velocidad_min + response.velocidad_max) / 2), Math.round((response.resistencia_min + response.resistencia_max) / 2), Math.round((response.battleIQ_min + response.battleIQ_max) / 2), Math.round((response.poderDestructivo_min + response.poderDestructivo_max) / 2), Math.round((response.experiencia_min + response.experiencia_max) / 2), Math.round((response.transformaciones_min + response.transformaciones_max) / 2), 250],
                        backgroundColor: [
                        'rgba(75, 192, 192, 0.8)',
                        'rgba(54, 162, 235, 0.8)',
                        'rgba(70, 82, 255, 0.8)',
                        'rgba(153, 102, 255, 0.8)',
                        'rgba(255, 102, 235, 0.8)',
                        'rgba(255, 99, 132, 0.8)',
                        'rgba(255, 159, 64, 0.8)',
                        'rgba(255, 205, 86, 0.8)',
                        'rgba(121, 235, 93, 0.8)',
                        ],
                        borderColor: [
                        'rgb(75, 192, 192)',
                        'rgb(54, 162, 235)',
                        'rgb(70, 82, 255)',
                        'rgb(153, 102, 255)',
                        'rgb(255, 102, 235)',
                        'rgb(255, 99, 132)',
                        'rgb(255, 159, 64)',
                        'rgb(255, 205, 86)',
                        'rgb(121, 235, 93)',
                        ],
                        borderWidth: 1
                        
                    }]
                    };
                    var config = {
                        type: 'bar',
                        data: data,
                        options: {
                            responsive: true,
                            indexAxis: 'y', // cambiar a 'y' para que se vea horizontal
                            scales: {
                                y: {
                                    beginAtZero: true
                                },
                            },
                        },
                      };
                    if (chartId == 3){
                        if (myChart3) myChart3.destroy()
                        myChart3 = new Chart(document.getElementById('myChart3'), config);
                    }
                    if (chartId == 4){
                        if (myChart4) myChart4.destroy()
                        myChart4 = new Chart(document.getElementById('myChart4'), config);
                    }
                } 
        }
    );
}



function Enfrentar(IdGanador, IdPerdedor, puntosGanador, puntosPerdedor){
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: 'DevolverGanadorPerdedor',
            data:{IdGanador: IdGanador, IdPerdedor: IdPerdedor},
            success:
                function (response)
                {
                    // @Url.Action("AñadirRegistro", new{ganador = ${response[0]}, perdedor = ${response[1]}, puntosGanador = ${puntosGanador}, puntosPerdedor = ${puntosPerdedor}}
                    document.getElementById('col-enfrentar').innerHTML = `<button class="btn btn-secondary" style="width: 50%;" id="enfrentar" onclick="location.href='/Home/AñadirRegistro?IdGanador=${response[0].idLuchador}&IdPerdedor=${response[1].idLuchador}&puntosGanador=${puntosGanador}&puntosPerdedor=${puntosPerdedor}'"><b>Volver y guardar registro</b></button>`
                    let muestraGanador = document.getElementById('ganador')

                    var directorio = "/img/luchadores/"
                    if (response[0].foto == "foto_empate.jfif" && response[0].nombre == "Empate!") directorio = "/img/"

                    muestraGanador.innerHTML = `
                    <img style="width: 30rem; margin: auto" src="/img/Victoria.png">
                    <h1> GANADOR: ${response[0].nombre} </h1>
                    <img style="width: 18rem; margin: auto" src="${directorio}${response[0].foto}">`

                    MostrarConfeti()
                } 
        }
    );
}

function MostrarConfeti(){
    var end = Date.now() + (15 * 1000);

    var colors = ['#ffd60a', '#0a2472'];

    confetti({
        particleCount: 700,
        angle: 60,
        spread: 100,
        origin: { x: 0 },
        colors: colors
    });
    confetti({
        particleCount: 700,
        angle: 120,
        spread: 100,
        origin: { x: 1 },
        colors: colors
    });
    confetti({
        particleCount: 700,
        angle: 90,
        spread: 100,
        origin: { x: 0.5 , y:1},
        colors: colors
    });

    // if (Date.now() < end) {
    //     requestAnimationFrame(frame);
    // }
}

