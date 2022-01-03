@Code
    ViewData("Title") = "ProductosPorCategoria"
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code
<div class="container">
    <h2>ProductosPorCategoria</h2>

    <div class="row">
        <label>Categoria</label>
        <select id="cboCategoria" onchange="BuscarProductos()">
            @For Each fila In ViewData("categorias")
                @<option value="@fila("CategoriaID")">@fila("Descripcion")</option>
            Next
        </select>
    </div>

    <div class="row">
        <table class="table">
            <thead>
                <tr>
                    <th>Codigo</th>
                    <th>Descripcion</th>
                    
                </tr>
            </thead>
            <tbody id="productos"></tbody>
        </table>
    </div>

</div>

<script>
    function BuscarProductos()
    {
        $.ajax({
            url: 'http://localhost:57638/api/producto/getProductos',
            data: {
                id: $('#cboCategoria').val()
            },
            type: 'GET',
            datetype: 'JSON',
            success: function (retorno) {
                //console.log(retorno);
                var row = "";
                for (i = 0; i < retorno.length; i++) {
                    row += "<tr>";
                    row += "<td>";
                    row += retorno[i].pProductoID;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pNombre;
                    row += "</td>";
                    row += "</tr>";

                }
                $('#productos').html(row);
            },
            error: function () {
                $('#prodcutos').html("");
                alert("No se ha encontrado productos para la categoria selccionada")
            }
        })
    }
</script>


