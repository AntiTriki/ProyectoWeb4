var idUsuario = 0;
var listaUsuario;
var listaPaises;

$(document).ready(function () {
    CargarUsuario();
    //$("#txtFecha").datepicker();
    crearControlFecha("#txtFecha", true);
});

function CargarUsuario() {
    var url = "/Usuario/ObtenerUsuarios";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, mostrarDatosUsuario, datos, tipoDatos, tipo);
}

function mostrarDatosUsuario(datos) {
    if (datos.sucess) {
        listaUsuario = datos.listas.Usuarios;
        listaPaises = datos.listas.Paises;
        var prop = { id: 'IdPais', value: 'Nombre' };
        adicionarOpcionesCombo($("#cmbPais"), listaPaises, false, prop, false);
        mostrarUsuarios();
    } else {
        toastr.error(datos.mensaje);
    }
};

function mostrarUsuarios() {
    limpiarTabla("tablaUsuario");
    $.each(listaUsuario, function (index, elemento) {
        var filaId = elemento.IdUsuario;
        var fila = $('<tr>').attr('id', filaId).attr('IdUsuario', elemento.IdUsuario);
        fila.append($('<td>').html(elemento.Usuario));
        fila.append($('<td>').html(elemento.Nombre));
        fila.append($('<td>').html(elemento.Correo));
        fila.append($('<td>').html(elemento.Sexo));
        fila.append($('<td>').html(AccionColumna(function (e) { mostrarModalEditar(elemento) }, 'glyphicon glyphicon-edit')));
        fila.append($('<td>').html(AccionColumna(function (e) { mostrarModalEliminar(e, elemento) }, 'glyphicon glyphicon-remove')));
        $('#tablaUsuario tbody').append(fila);
    });
}

function limpiarAbmDatos() {
    $("#txtUsuario").val("");
    $("#txtNombre").val("");
    $("#txtCorreo").val("");
}

$("#btnAdicionar").click(function () {
    idUsuario= 0;
    var modal = '#agregarUsuario';
    limpiarAbmDatos();
    $(modal).find(".modal-title").html('Adicionar  Usuario');
    $(modal).find(".modal-body").css({ 'min-height': 130 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
});
