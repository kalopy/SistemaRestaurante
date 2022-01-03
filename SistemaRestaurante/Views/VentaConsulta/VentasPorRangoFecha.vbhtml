@Code
    ViewData("Title") = "VentasPorRangoFecha"
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code

<div class="container">
    <h2>Ventas por Rango de Fechas</h2>

    <div class="row">
        <label>Fecha</label>
        <select id="cboFechas" onchange="BuscarVentas()">
            @For Each fila In ViewData("fechas")
                @<option value="@fila("TransaccionID")">@fila("Fecha")</option>
            Next
        </select>
    </div>

    <div class="row">
        <table class="table">
            <thead>
                <tr>
                    <th>Transaccion</th>
                    <th>TipoOperacion</th>

                </tr>
            </thead>
            <tbody id="ventas"></tbody>
        </table>
    </div>

</div>

<script>
    function BuscarVentas()
    {
        $.ajax({
            url: 'http://localhost:57638/api/venta/getVentas',
            data: {
                id: $('#cboFechas').val()
            },
            type: 'GET',
            datetype: 'JSON',
            success: function (retorno) {
                //console.log(retorno);
                var row = "";
                for (i = 0; i < retorno.length; i++) {
                    row += "<tr>";
                    row += "<td>";
                    row += retorno[i].pTransaccionID;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pTipoOperacionID;
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

