Imports ClaseRestaurante
Public Class VentaRepository
    'Vamos a crear una funcion para recuperar todos los productos por catagoria
    'Esta funcion va a ser utilizado por el controlador del servicio web, vamos a programar a continuacion...
    Public Function getVentas(fecha1 As Date, fecha2 As Date) As List(Of Transaccion)
        'Inicializamos la cadena de conexion a la BD mediante la clase Util
        Util.inicializaSesion("MSI", "RESTAURANTEXX", "Kalo", "1234")
        'Creamos un objeto de coleccion para guardar los productos
        Dim ListVentas As New List(Of Transaccion)
        'Creamos una tabla temporal para guardar el resultado del metodo de la clase
        Dim dt As New DataTable
        'Llamamos al metodo
        dt = Transaccion.RecuperarVentasPorRangoFecha(fecha1, fecha2)
        'Aqui verificamos si tiene filas la tabla
        If dt.Rows.Count > 0 Then
            'Recorremos toda la tabla temporal para crear el objeto de coleccion
            For f As Integer = 0 To dt.Rows.Count - 1
                'Creamos un objeto para agregar despues en la coleccion
                Dim objVenta As New Transaccion
                'Asi en cada propiedad el objeto los datos obtenidos de la tabla temporal
                With objVenta
                    '.pActivo = dt.Rows(f).Item("Activo")
                    .pTransaccionID = dt.Rows(f).Item("TransaccionID")
                    .pTipoOperacionID = dt.Rows(f).Item("TipoOperacionID")
                    .pFecha = dt.Rows(f).Item("Fecha")
                    .pUsuarioID = dt.Rows(f).Item("UsuarioID")
                    .pAnulado = dt.Rows(f).Item("Anulado")
                    .pMonto = dt.Rows(f).Item("Monto")
                    .pNroComprobante = dt.Rows(f).Item("NroComprobante")
                End With
                'Aqui agregamos el objeto a la coleccion
                ListVentas.Add(objVenta)
                'Despues eliminamos el objeto creado
                objVenta = Nothing
            Next
        Else
            'Si no se encuentra ninguna fila
            Return Nothing
        End If

        'Convertimos a una lista el resultado y retornamos el objeto de l coleccion
        Return ListVentas.ToList
    End Function

End Class
