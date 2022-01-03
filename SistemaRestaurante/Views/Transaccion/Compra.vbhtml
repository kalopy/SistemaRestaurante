@Code
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code

<div class="row">
    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
        <h2>
            Compras
            <a href="NuevaCompra" class="btn btn-success">
                <i class="fa fa-plus" aria-hidden="true">
                </i> Nueva Compra
            </a>
        </h2>
    </div>
</div>

<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <table class="table table-striped table-bordered">
            <thead>
                <tr>
                    <td> Fecha </td>
                    <td> Usuario </td>
                    <td> Monto </td>
                    <td> Anulado </td>
                    <td> Acciones </td>
                </tr>
            </thead>
            <tbody>
                @*Mostramos la lista de compras en la vista*@
                @for Each item In ViewData("compras")
                    @<tr>
                        <td> @item("Fecha") </td>
                        <td> @item("NombreUsuario") </td>
                        <td> @item("Monto") </td>
                        <td> @item("Anulado") </td>
                        <td>
                            <a href="#" Class="btn btn-info">
                                <i Class="fa fa-print" aria-hidden="true">
                                </i> Imprimir
                            </a>
                            <a href="#" Class="btn btn-danger">
                                <i Class="fa fa-ban" aria-hidden="true">
                                </i> Eliminar
                            </a>
                        </td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
</div>



