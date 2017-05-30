var idCategoria = 0;
var listaCategorias;

$(document).ready(function () {
    CargarCategorias();
});

function CargarCategorias() {
    var url = "/Categoria/ObtenerCategorias";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, mostrarDatosCategorias, datos, tipoDatos, tipo);
}

function mostrarDatosCategorias(datos) {
    if (datos.sucess) {
        listaCategorias = datos.listaCategorias;
        mostrarCategorias();
    } else {
        toastr.error(datos.mensaje);
    }
};

function mostrarCategorias() {
    limpiarTabla("tablaCategoria");
    $.each(listaCategorias, function (index, elemento) {
        var filaId = elemento.IdCategoria;
        var fila = $('<tr>').attr('id', filaId).attr('IdCategoria', elemento.IdCategoria);
        fila.append($('<td>').html(elemento.IdCategoria));
        fila.append($('<td>').html(elemento.Nombre));
        fila.append($('<td>').html(elemento.Descripcion));
        fila.append($('<td>').html(AccionColumna(function (e) { mostrarModalEditar(elemento) }, 'glyphicon glyphicon-edit')));
        fila.append($('<td>').html(AccionColumna(function (e) { mostrarModalEliminar(e, elemento) }, 'glyphicon glyphicon-remove')));
        $('#tablaCategoria tbody').append(fila);
    });
}

function limpiarAbmDatos() {
    $("#txtNombre").val("");
    $("#txtDescripcion").val("");
}

$("#btnAdicionar").click(function () {
    idCategoria = 0;
    var modal = '#agregarCategoria';
    limpiarAbmDatos();
    $(modal).find(".modal-title").html('Adicionar  Categoria');
    $(modal).find(".modal-body").css({ 'min-height': 130 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
});

$("#btnAbmGuardar").click(function () {
    var nombre = $("#txtNombre").val();
    var descripcion = $("#txtDescripcion").val();
    var url = "/Categoria/GuardarCategoria";
    var tipo = 'GET';
    var datos = { idCategoria: idCategoria, nombre: nombre};
    var tipoDatos = 'JSON';
    solicitudAjax(url, guardadoExitoso, datos, tipoDatos, tipo);
});

function guardadoExitoso(datos) {
    $("#agregarCategoria").modal("hide");
    if (datos.sucess) {
        if (idCategoria === 0) {
            var id = parseInt(datos.idCategoria);
            var pais = { IdCategoria: id, Nombre: $("#txtNombre").val() }
            listaCategorias.push(pais);
        } else {
            $.each(listaCategorias, function (index, elemento) {
                if (elemento.IdCategoria === idCategoria) {
                    elemento.Nombre = $("#txtNombre").val();
                   
                    return false;
                }
            });
        }
        mostrarCategorias();
        toastr.success("Se ha guardado satisfactoriamente ");
    } else {
        toastr.error(datos.Mensaje);
    }
};

function mostrarModalEditar(elemento) {
    idCategoria = elemento.IdCategoria;
    $("#txtNombre").val(elemento.Nombre);
    
    var modal = '#agregarCategoria';

    $(modal).find(".modal-title").html('Adicionar  Categoria');
    $(modal).find(".modal-body").css({ 'min-height': 130 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
}

function mostrarModalEliminar(e, elemento) {
    idCategoria = elemento.IdCategoria;
    var modal = '#eliminar';
    $(modal).find(".modal-title").html('Eliminar Categoria');
    $(modal).find(".text-mensaje-modal").html('Esta seguro que desea eliminar el Categoria  ' + "'" + elemento.Nombre + "'    ?");
    $(modal).find(".modal-body").css({ 'min-height': 100 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
    $("#btnConfirmarElim").unbind('click').click(function () {
        confirmarEliminar(e, elemento);
    });
}

function confirmarEliminar(e, elemento) {
    var url = "/Categoria/EliminarCategoria";
    var tipo = 'GET';
    var datos = { idCategoria: elemento.IdCategoria };
    var tipoDatos = 'JSON';
    solicitudAjax(url, eliminarExitoso, datos, tipoDatos, tipo);
}

function eliminarExitoso(datos) {
    $("#eliminar").modal("hide");
    if (datos.sucess) {
        $.each(listaCategorias, function (index, elemento) {
            if (elemento.IdCategoria === idCategoria) {
                listaCategorias.splice(index, 1);
                return false;
            }
        });

        mostrarCategorias();
        toastr.success("Se ha eliminado satisfactoriamente ");
    } else {
        toastr.error(datos.Mensaje);
    }
};
