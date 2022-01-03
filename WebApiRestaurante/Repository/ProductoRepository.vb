Imports ClaseRestaurante
Public Class ProductoRepository
    'Vamos a crear una funcion para recuperar todos los productos por catagoria
    'Esta funcion va a ser utilizado por el controlador del servicio web, vamos a programar a continuacion...
    Public Function getProductos(id As Integer) As List(Of Producto)
        'Inicializamos la cadena de conexion a la BD mediante la clase Util
        Util.inicializaSesion("MSI", "RESTAURANTEXX", "Kalo", "1234")
        'Creamos un objeto de coleccion para guardar los productos
        Dim ListProductos As New List(Of Producto)
        'Creamos una tabla temporal para guardar el resultado del metodo de la clase
        Dim dt As New DataTable
        'Llamamos al metodo
        dt = Producto.RecuperarRegistrosPorCategoria(id)
        'Aqui verificamos si tiene filas la tabla
        If dt.Rows.Count > 0 Then
            'Recorremos toda la tabla temporal para crear el objeto de coleccion
            For f As Integer = 0 To dt.Rows.Count - 1
                'Creamos un objeto para agregar despues en la coleccion
                Dim objProducto As New Producto
                'Asi en cada propiedad el objeto los datos obtenidos de la tabla temporal
                With objProducto
                    .pActivo = dt.Rows(f).Item("Activo")
                    .pCategoriaID = dt.Rows(f).Item("CategoriaID")
                    .pCodigo = dt.Rows(f).Item("Codigo")
                    .pCosto = dt.Rows(f).Item("Costo")
                    .pExistencia = dt.Rows(f).Item("Existencia")
                    .pNombre = dt.Rows(f).Item("Nombre")
                    .pPrecioVenta = dt.Rows(f).Item("PrecioVenta")
                    .pPreparacion = dt.Rows(f).Item("Preparacion")
                    .pPresentacion = dt.Rows(f).Item("Presentacion")
                    .pUnidadMedidaID = dt.Rows(f).Item("UnidadMedidaID")
                    .pProductoID = dt.Rows(f).Item("ProductoID")
                End With
                'Aqui agregamos el objeto a la coleccion
                ListProductos.Add(objProducto)
                'Despues eliminamos el objeto creado
                objProducto = Nothing
            Next
        Else
            'Si no se encuentra ninguna fila
            Return Nothing
        End If

        'Convertimos a una lista el resultado y retornamos el objeto de l coleccion
        Return ListProductos.ToList

    End Function
End Class
