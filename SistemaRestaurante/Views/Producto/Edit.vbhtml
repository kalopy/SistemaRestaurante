@Modeltype ClaseRestaurante.Producto
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code

<div class="row">
    <div class="col-lg-4 col-md-7 col-sm-7 col-xs-12">
        <h1>
            <span class="glyphicon glyphicon-edit"></span>
            Modificar Producto
        </h1>
    </div>
</div>

<form action="Edit" method="post" class="form-horizontal">
    <input type="hidden" name="productoid" value="@Model.pProductoID" />
    <div class="well">
        <fieldset>
            <div class="form-group">
                <label for="codigo" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Codigo</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="text" class="form-control" required value="@Model.pCodigo" name="codigo" />
                </div>
            </div>

            <div class="form-group">
                <label for="nombre" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Nombre</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="text" class="form-control" value="@Model.pNombre" required name="nombre" />
                </div>
            </div>

            <div class="form-group">
                <label for="preparacion" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Preparacion</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="text" class="form-control" value="@Model.pPreparacion" required name="preparacion" />
                </div>
            </div>

            <div class="form-group">
                <label for="costo" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Costo</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="text" class="form-control" value="@Model.pCosto" required name="costo" />
                </div>
            </div>

            <div class="form-group">
                <label for="precio_venta" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Precio Venta</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="text" class="form-control" value="@Model.pPrecioVenta" required name="precio_venta" />
                </div>
            </div>

            <div class="form-group">
                <label for="categoria" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Categorias</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <select name="categoriaid" class="form-control">
                        @for Each row_categoria In ViewData("categorias")
                            @<option value="@row_categoria("CategoriaID")" @IIf(Model.pCategoriaID = row_categoria("CategoriaID"),"Selected","") >
                            @row_categoria("Descripcion")</option>
                        Next
                    </select>
                </div>
            </div>

            <div class="form-group">
                <label for="unidad_medida" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Unidad Medida</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <select name="unidad_medidaid" class="form-control">
                        @for Each row_unidad_medida In ViewData("unidades_medida")
                            @<option value="@row_unidad_medida("UnidadMedidaID")" @IIf(Model.pUnidadMedidaID = row_unidad_medida("UnidadMedidaID"), "Selected", "")>@row_unidad_medida("Descripcion")</option>
                        Next
                    </select>
                </div>
            </div>

            <div class="form-group">
                <label for="presentacion" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Presentacion</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="text" class="form-control" value="@Model.pPresentacion" required name="presentacion" />
                </div>
            </div>

            <div class="form-group">
                <label for="usa_ingrediente" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Usa Ingredientes</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

                    <label class="radio-inline">
                        <input type="radio" name="usa_ingrediente" @IIf(Model.pUsaIngrediente = "S", "Checked", "") value="S" />Si
                    </label>

                    <label class="radio-inline">
                        <input type="radio" name="usa_ingrediente" @IIf(Model.pUsaIngrediente = "N", "Checked", "") value="N" />No
                    </label>

                </div>
            </div>

            <div class="form-group">
                <label for="estado" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Activo?</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

                    <label class="radio-inline">
                        <input type="radio" name="estado" @IIf(Model.pActivo = "S", "Checked", "") value="S" />Si
                    </label>

                    <label class="radio-inline">
                        <input type="radio" name="estado" @IIf(Model.pActivo = "N", "Checked", "") value="N" />No
                    </label>

                </div>
            </div>

            <div class="form-group">
                <label for="existencia" class="col-lg-2 col-md-2 col-sm-3 col-xs-12">Existencia</label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <input type="number" class="form-control" value="@Model.pExistencia" required name="existencia" />
                </div>
            </div>

        </fieldset>

        <footer>
            <input type="submit" value="Guardar" class="btn btn-success" />
            <input type="reset" value="Limpiar" class="btn btn-warning" />
        </footer>

    </div>
</form>

