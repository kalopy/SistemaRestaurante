@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code

<div class="row">
    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
        <h3>
            @*<a href="Producto/Create" class="btn btn-success"> <span class="glyphicon glyphicon-plus"></span> Nuevo Producto</a>*@
            @*<a href="Producto/Create" class="btn btn-success">Nuevo Producto</a>*@
            <a href="Producto/Create" class="btn btn-success">
                <i class="fa fa-plus" aria-hidden="true">
                </i> Nuevo Producto
            </a>
        </h3>
    </div>
</div>

<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"">
        <div class="table-responsive">
            <table id="mi_tabla" class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <td>Codigo</td>
                        <td>Nombre</td>
                       
                        <td>Costo</td>

                        <td>Precio Venta</td>
                        <td>Unidad Medida</td>
                        <td>Categoria</td>
                       
                        <td>Existencia</td>
                        <td>Estado</td>
                        <td></td>
                    </tr>
                </thead>
                <tbody>
                    @for Each item In ViewData("productos")
                        @<tr>
                            <td>@item("Codigo")</td>
                            <td>@item("Nombre")</td>
                            
                            <td>@item("Costo")</td>
                            <td>@item("PrecioVenta")</td>
                            
                            <td>@item("UnidadMedida")</td>
                            <td>@item("Categoria")</td>
                            
                            <td>@item("Existencia")</td>
                            <td>@item("Activo")</td>
                            <td>
                                <a href="Producto/Edit/@item("ProductoID")" class="btn btn-info">Modificar</a>

                                <a href="javascript:eliminar(@item("ProductoID"))" class="btn btn-danger">Eliminar</a>
                            </td>

                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    </div>
</div>

<script type="text/javascript">
    function eliminar(id) {
        //Solicita confirmacion del ususario
        if (confirm('¿Esta seguro de querer eliminar el registro?')) {
            //Definimos el parametro para la funcion ajax
            var parametros = {
                id: id
            };
            //Creamos la funcion ajax para llamar a la accion del controlador para eliminar
            $.ajax({
                url: '../Producto/Delete',
                data: parametros,
                type: 'post',
                cache: false,
                success: function (retorno) {
                    //Volvemos a cargar la pagina
                    location.reload()
                },
                error: function () {
                    alert('Se ha producido un error');
                }
            });
        }
    }

</script>