﻿
$(document).ready(function () {
    var idRegistro = 0;
    var idR = 0;
    $("#btnNuevo").click(function () {
        window.location.href = '/Agregar.cshtml';
        return false;
    });

    $("#btnEditar").click(function () {
        if (idRegistro > 0)
            window.location.href = '/editar.cshtml?id=' + idRegistro;
        else
            alert('Debe seleccionar el registro que desea modificar');

        return false;
    });

    $("#btnEliminar").click(function () {
        $.confirm({
            title: 'Confirmación',
            content: '¿Está seguro(a) de borrar el registro?',
            buttons: {
                Aceptar: function () {
                    if (idRegistro > 0)
                        window.location.href = '/eliminar.cshtml?id=' + idRegistro;
                    else
                        $.alert('Debe seleccionar el registro que desea eliminar');
                },
                Cancelar: function () {
                    //$.alert('cancelada la eliminacion');
                    var x = 0;
                }
            }
        });

        return false;
    });

    $("tr").click(function () {
        $(this).closest("tr").siblings().removeClass("highlighted");
        $(this).toggleClass("highlighted");
        idR = $(this).find("td").eq(0).html();
        if (idR === idRegistro) {
            idRegistro = 0;
            $("#btnEditar").attr("disabled", "disabled");
            $("#btnEliminar").attr("disabled", "disabled");
            $("#btnNuevo").removeAttr("disabled", "disabled");
        }
        else {
            idRegistro = idR;
            $("#btnEditar").removeAttr("disabled", "disabled");
            $("#btnEliminar").removeAttr("disabled", "disabled");
            $("#btnNuevo").attr("disabled", "disabled");
        }
    })

    //function validaFecha() {
    //    var x = $('#fecha').val();
    //    $.alert(x);
    //}

//    var startDt = document.getElementById("startDateId").value;
//    var endDt = document.getElementById("endDateId").value;

//    if ((new Date(startDt).getTime() > new Date(endDt).getTime())) {
//        ----------------------------------
//}
    

 });

