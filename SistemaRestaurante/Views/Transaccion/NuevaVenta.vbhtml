@Code
    ViewData("Title") = "NuevaCompra"
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code

@*agregamos la accion en el formulario*@
@*Se envia todos los datos ingresados a la accion NuevaCompra*@
<form action="NuevaVenta" method="post">
    <div class="row">
        <div class="col-lg-6 col-sm-6 col-md-12 col-xs-12">
            <div class="form-group">
                <label for="nro_comprobante"> Nro. Comprobante </label>
                <input type="text" name="nro_comprobante" required class="form-control"
                       placeholder="Nro. Comprobante..." />
            </div>
        </div>

        <div class="col-lg-4 col-sm-4 col-md-4 col-xs-12">
            <div class="form-group">
                <label for="fecha_compra"> Fecha </label>
                <input type="date" name="fecha" required class="form-control" />
            </div>
        </div>


    </div>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body">
                <div class="col-lg-4 col-sm-4 col-md-4 col-xs-12">
                    <div class="form-group">
                        <label> Articulo </label>
                        <select name="pidarticulo" class="form-control" id="pidarticulo">
                            @*Mostramos en una lista los productos para seleccionar*@
                            @for Each row In ViewData("productos")
                                @<option value="@row("ProductoID")"> @row("Nombre") </option>
                            Next
                        </select>
                    </div>
                </div>

                <div class="col-lg-2 col-sm-2 col-md-2 col-xs-12">
                    <div class="form-group">
                        <label for="cantidad"> Cantidad </label>
                        <input type="number" name="pcantidad" id="pcantidad" class="form-control" placeholder="cantidad" />
                    </div>
                </div>

                <div class="col-lg-2 col-sm-2 col-md-2 col-xs-12">
                    <div class="form-group">
                        <label for="precio"> Precio </label>
                        <input type="number" name="pprecio" id="pprecio" class="form-control" placeholder="precio" />
                    </div>
                </div>

                <div class="col-lg-2 col-sm-2 col-md-2 col-xs-12">
                    <div class="form-group">
                        <button type="button" name="bt_add" id="bt_add" onclick="agregar()" class="btn btn-primary">
                            <i class="fa fa-plus" aria-hidden="true"></i>
                        </button>
                    </div>
                </div>

                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                    <table id="detalles" class="table table-striped table-bordered table-condedsed table-hover">
                        <thead style="background-color:#A9D0F5">
                            <tr>
                                <th> Opciones </th>
                                <th> Articulo </th>
                                <th> Cantidad </th>
                                <th> Precio </th>
                                <th> SubTotal </th>
                            </tr>
                        </thead>

                        <tbody></tbody>
                        <tfoot>
                            <tr>
                                <th> TOTAL </th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th> <h4 id="total"> G / .0.00 </h4></th>
                            </tr>
                        </tfoot>
                    </table>
                </div>

            </div>

        </div>

        <div class="col-lg-6 col-sm-6 col-md-6 col-xs-12" id="guardar">

            <div class="form-group">
                <button class="btn btn-primary" type="submit"> Guardar </button>
                <button class="btn btn-danger" type="reset"> Cancelar </button>
            </div>
        </div>

    </div>
</form>

<script type="text/javascript">
    var cont = 0;
    var total = 0;
    subtotal = [];

    function agregar() {
        idarticulo = $("#pidarticulo").val();
        articulo = $("#pidarticulo option:selected").text();
        cantidad = $("#pcantidad").val();
        precio = $("#pprecio").val();

        if (idarticulo != "" && cantidad != "" && cantidad > 0 && precio != "") {
            subtotal[cont] = (cantidad * precio);

            total = total + subtotal[cont];

            var fila = '<tr class="selected" id="fila"' + cont + '"><td><button type="button" class= btn bn-warning" onclick=eliminar('
                + cont + ');" >X</button></td><td><input type="hidden" name="idarticulo" value="' + idarticulo
            + '">' + articulo + '</td><td><input type="number" name="cantidad" value="' + cantidad + '"></td><td><input type="number" name="precio" value="' + precio + '"></td><td>'
            + subtotal[cont] + '</td></tr>';
            cont++;

            limpiar();
            $("#total").html("G/. " + total);

            $("#detalles").append(fila);
        }
        else {
            alert("Error al ingresar el detalle del ingreso, revise los datos del articulo");

            }
        

        //if (articulo != "" || cantidad < 0) {
        //    alert("El producto que selecciona no existe o es menor a la cantidad vendida")
            
        //}

        //if (articulo = "" || cantidad > 0) {
        //     Si no se cumple la condicion...
        //    alert('[ERROR] El producto que ha seleccionado no existe o es menor a la cantidad vendida');
        //    return false;
        //}
    }

    function eliminar(index) {
        total = total - subtotal[index];
        $("#total").html("G/." + total);
        $("#fila" + index).remove();
        evaluar();
    }

    function limpiar() {
        $("#pcantidad").val("");
        $("#pprecio").val("");
    }
</script>

