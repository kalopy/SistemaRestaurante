@Code
    ViewData("Title") = "VentaxFecha"
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code
<div class="container">
    <h2>VentasPorFecha</h2>

    @*<div class="row">
            <label>Categoria</label>
            <select id="cboCategoria" onchange="BuscarProductos()">
                @For Each fila In ViewData("categorias")
                    @<option value="@fila("CategoriaID")">@fila("Descripcion")</option>
                Next
            </select>
        </div>*@
    <div class="row">
        <div class="row">
            <label>Fecha Desde</label>
            <input type="date" id="fecha_desde" />
        </div>

        <div class="row">
            <label>Fecha Hasta</label>
            <input type="date" id="fecha_hasta" />
        </div>
        <button onclick="BuscarVentas()" >Buscar</button>
     </div>


        <div class="row">
            <table class="table">
                <thead>
                    <tr>
                        <th>Fecha</th>
                        <th>Monto</th>
                        <th>NroComprobante</th>

                    </tr>
                </thead>
                <tbody id="ventas"></tbody>
            </table>
        </div>

    </div>

    <script>
        function BuscarVentas() {
            $.ajax({
                url: 'http://localhost:57638/api/Venta/getVentas',
                data: {
                    fecha1: $('#fecha_desde').val(),
                    fecha2: $('#fecha_hasta').val()
                },
                type: 'GET',
                datetype: 'JSON',
                success: function (retorno) {
                    //console.log(retorno);
                    var row = "";
                    for (i = 0; i < retorno.length; i++) {
                        row += "<tr>";
                        row += "<td>";
                        row += retorno[i].pFecha;
                        row += "</td>";
                        row += "<td>";
                        row += retorno[i].pMonto;
                        row += "</td>";
                        row += "<td>";
                        row += retorno[i].pNroComprobante;
                        row += "</td>";
                        row += "</tr>";

                    }
                    $('#ventas').html(row);
                },
                error: function () {
                    $('#ventas').html("");
                    alert("No se ha encontrado productos para la categoria selccionada")
                }
            })
        }
    </script>

