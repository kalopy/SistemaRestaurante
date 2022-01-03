Imports ClaseRestaurante.Util
Public Class DetalleTransaccion
    Private DetalleTransaccionID As Integer
    Private TransaccionID As Integer
    Private ProductoID As Integer
    Private Cantidad As Integer
    Private Precio As Decimal

    Public Property pDetalleTransaccionID As Integer
        Get
            Return DetalleTransaccionID
        End Get
        Set(value As Integer)
            DetalleTransaccionID = value
        End Set
    End Property

    Public Property pTransaccionID As Integer
        Get
            Return TransaccionID
        End Get
        Set(value As Integer)
            TransaccionID = value
        End Set
    End Property

    Public Property pProductoID As Integer
        Get
            Return ProductoID
        End Get
        Set(value As Integer)
            ProductoID = value
        End Set
    End Property

    Public Property pCantidad As Integer
        Get
            Return Cantidad
        End Get
        Set(value As Integer)
            Cantidad = value
        End Set
    End Property

    Public Property pPrecio As Decimal
        Get
            Return Precio
        End Get
        Set(value As Decimal)
            Precio = value
        End Set
    End Property

    'Metodos de la clase DetalleTransaccion para insertar
    Sub Insertar()
        gDatos.Ejecutar("spInsertarDetalleTransaccion", Me.TransaccionID, Me.ProductoID, Me.Cantidad, Me.Precio)
    End Sub

End Class

