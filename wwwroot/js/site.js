// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
                    $("#Victorias").html("Victorias - " + response.victorias) // div todo el ancho
                    $("#FechaNacimiento").html("Fecha de Nacimiento: " + response.fechaNacimiento.substr(0, 10)) //agarra los primeros 10 caracteres

                    $("#IQ").html("<b>IQ:</b> " + response.iq)
                    $("#Fuerza").html("<b>Fuerza:</b> " + response.fuerza)
                    $("#Velocidad").html("<b>Velocidad:</b> " + response.velocidad)
                    $("#Resistencia").html("<b>Resistencia:</b> " + response.resistencia)
                    $("#BattleIQ").html("<b>Battle IQ:</b> " + response.battleIQ)
                    $("#PoderDestructivo").html("<b>Poder Destructivo:</b> " + response.poderDestructivo)
                    $("#Experiencia").html("<b>Experiencia:</b> " + response.experiencia)
                    $("#Transformaciones").html("<b>Transformaciones:</b> " + response.transformaciones)
                    
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
