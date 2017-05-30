var idPais = 0;
var listaPaises;

$(document).ready(function () {
    CargarPaises();
});

function CargarPaises() {
    var url = "/Pais/ObtenerPaises";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, mostrarDatosPaises, datos, tipoDatos, tipo);
}

function mostrarDatosPaises(datos) {
    if (datos.sucess) {
        listaPaises = datos.listaPaises;
        mostrarPaises();
    } else {
        toastr.error(datos.mensaje);
    }
};

function mostrarPaises() {
    limpiarTabla("tablaPais");
    $.each(listaPaises, function (index, elemento) {
        var filaId = elemento.IdPais;
        var fila = $('<tr>').attr('id', filaId).attr('IdPais', elemento.IdPais);
        fila.append($('<td>').html(elemento.IdPais));
        fila.append($('<td>').html(elemento.Nombre));
        fila.append($('<td>').html(elemento.Descripcion));
        fila.append($('<td>').html(AccionColumna(function (e) { mostrarModalEditar(elemento) }, 'glyphicon glyphicon-edit')));
        fila.append($('<td>').html(AccionColumna(function (e) { mostrarModalEliminar(e, elemento) }, 'glyphicon glyphicon-remove')));
        $('#tablaPais tbody').append(fila);
    });
}

function limpiarAbmDatos() {
    $("#txtNombre").val("");
    $("#txtDescripcion").val("");
}

$("#btnAdicionar").click(function () {
    idPais = 0;
    var modal = '#agregarPais';
    limpiarAbmDatos();
    $(modal).find(".modal-title").html('Adicionar  Pais');
    $(modal).find(".modal-body").css({ 'min-height': 130 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
});

$("#btnAbmGuardar").click(function () {
    var nombre = $("#txtNombre").val();
    var descripcion = $("#txtDescripcion").val();
    var url = "/Pais/GuardarPais";
    var tipo = 'GET';
    var datos = { idPais: idPais, nombre: nombre, descripcion: descripcion };
    var tipoDatos = 'JSON';
    solicitudAjax(url, guardadoExitoso, datos, tipoDatos, tipo);
});

function guardadoExitoso(datos) {
    $("#agregarPais").modal("hide");
    if (datos.sucess) {
        if (idPais === 0) {
            var id = parseInt(datos.idPais);
            var pais = { IdPais: id, Nombre: $("#txtNombre").val(), Descripcion: $("#txtDescripcion").val() }
            listaPaises.push(pais);
        } else {
            $.each(listaPaises, function (index, elemento) {
                if (elemento.IdPais === idPais) {
                    elemento.Nombre = $("#txtNombre").val();
                    elemento.Descripcion = $("#txtDescripcion").val();
                    return false;
                }
            });
        }
        mostrarPaises();
        toastr.success("Se ha guardado satisfactoriamente ");
    } else {
        toastr.error(datos.Mensaje);
    }
};

function mostrarModalEditar(elemento) {
    idPais = elemento.IdPais;
    $("#txtNombre").val(elemento.Nombre);
    $("#txtDescripcion").val(elemento.Descripcion);
    var modal = '#agregarPais';

    $(modal).find(".modal-title").html('Adicionar  Pais');
    $(modal).find(".modal-body").css({ 'min-height': 130 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
}

function mostrarModalEliminar(e, elemento) {
    idPais = elemento.IdPais;
    var modal = '#eliminar';
    $(modal).find(".modal-title").html('Eliminar Pais');
    $(modal).find(".text-mensaje-modal").html('Esta seguro que desea eliminar el Pais  ' + "'" + elemento.Nombre + "'    ?");
    $(modal).find(".modal-body").css({ 'min-height': 100 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
    $("#btnConfirmarElim").unbind('click').click(function () {
        confirmarEliminar(e, elemento);
    });
}

function confirmarEliminar(e, elemento) {
    var url = "/Pais/EliminarPais";
    var tipo = 'GET';
    var datos = { idPais: elemento.IdPais };
    var tipoDatos = 'JSON';
    solicitudAjax(url, eliminarExitoso, datos, tipoDatos, tipo);
}

function eliminarExitoso(datos) {
    $("#eliminar").modal("hide");
    if (datos.sucess) {
        $.each(listaPaises, function (index, elemento) {
            if (elemento.IdPais === idPais) {
                listaPaises.splice(index,1);
                return false;
            }
        });

        mostrarPaises();
        toastr.success("Se ha eliminado satisfactoriamente ");
    } else {
        toastr.error(datos.Mensaje);
    }
};
