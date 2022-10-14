// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// substr(0, 10) - agarra los primeros 10 caracteres (1234-67-89)
// document.getElementById('no-drag').setAttribute('draggable', false);

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
                    $("#TituloDetalleLuchador").html(response.nombre);

                    $("#Foto").attr("src", "/img/luchadores/" + response.foto)
                    $("#Victorias").html("Victorias - " + response.victorias)
                    $("#FechaNacimiento").html("Fecha de Nacimiento: " + response.fechaNacimiento.substr(0, 10))

                    $("#IQ").html("<b>IQ:</b> " + response.iQ_min + " - " + response.iQ_max)
                    $("#Fuerza").html("<b>Fuerza:</b> " + response.fuerza_min + " - " + response.fuerza_max)
                    $("#Velocidad").html("<b>Velocidad:</b> " + response.velocidad_min + " - " + response.velocidad_max)
                    $("#Resistencia").html("<b>Resistencia:</b> " + response.resistencia_min + " - " + response.resistencia_max)
                    $("#BattleIQ").html("<b>Battle IQ:</b> " + response.battleIQ_min + " - " + response.battleIQ_max)
                    $("#PoderDestructivo").html("<b>Poder Destructivo:</b> " + response.poderDestructivo_min + " - " + response.poderDestructivo_max)
                    $("#Experiencia").html("<b>Experiencia:</b> " + response.experiencia_min + " - " + response.experiencia_max)
                    $("#Transformaciones").html("<b>Transformaciones:</b> " + response.transformaciones_min + " - " + response.transformaciones_max)
                    
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
                    $("#mod-title").html("<b>Podés modificar lo que quieras!</b>")
                    $("#mod-Nombre").attr("value", response.nombre)
                    $("#mod-FechaNacimiento").attr("value", response.fechaNacimiento)
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
                    let a = '@Url.Action("ActualizarLuchador", "Home")'
                    console.log(a)
                    console.log($("#fj-form").attr("action"))
                    //$("#fj-form").attr("action", a)
                    $("#fj-submit").attr("href", '@Url.Action("ActualizarLuchador", "Home", new {luchador=luchador})')
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
                    //$("#fj-form").attr("action", '@Url.Action("GuardarLuchador", "Home")')
                    $("#fj-submit").attr("href", '@Url.Action("GuardarLuchador", new {luchador=luchador})')
                }
        }
    );
}