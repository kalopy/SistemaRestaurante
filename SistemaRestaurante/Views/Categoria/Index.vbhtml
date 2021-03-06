

@Code
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code


<div class="row">

    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
        <h3>
            <a href="Categoria/Create" class="btn btn-success">Nueva Categoria</a>
        </h3>
    </div>
</div>

<div class="row">

    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

        <div class="table-responsive">

            <table id="mi_tabla" class="table table-striped table-condensed table-hover">
                <thead>
                    <tr>
                        <td>Codigo</td>
                        <td>Descripcion</td>
                        <td>Esta Activo?</td>
                        <td></td>
                    </tr>
                </thead>
                <tbody>
                    @For Each item In ViewData("Categorias")
                        @<tr>
                            <td>@item("CategoriaID")</td>
                            <td>@item("Descripcion")</td>



                            <td>@item("Activo")</td>

                            <td>
                                <a href="Categoria/Edit/@item("CategoriaID")" class="btn btn-info">Modificar</a>
                                <a href="javascript:eliminar(@item("CategoriaID"))" class="btn btn-danger">Eliminar</a>
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
                url: '../Categoria/Eliminar',
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



