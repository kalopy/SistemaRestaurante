Imports ClaseRestaurante.Util
Public Class Transaccion
    Private TransaccionID As Integer
    Private TipoOperacionID As Integer
    Private Fecha As Date
    Private UsuarioID As Integer
    Private Anulado As String
    Private Monto As Decimal
    Private NroComprobante As String

    Public Property pTransaccionID() As Integer
        Get
            Return TransaccionID
        End Get
        Set(value As Integer)
            TransaccionID = value
        End Set
    End Property

    Public Property pTipoOperacionID() As Integer
        Get
            Return TipoOperacionID
        End Get
        Set(value As Integer)
            TipoOperacionID = value
        End Set
    End Property

    Public Property pFecha As Date
        Get
            Return Fecha
        End Get
        Set(value As Date)
            Fecha = value
        End Set
    End Property

    Public Property pUsuarioID As Integer
        Get
            Return UsuarioID
        End Get
        Set(value As Integer)
            UsuarioID = value
        End Set
    End Property

    Public Property pAnulado As String
        Get
            Return Anulado
        End Get
        Set(value As String)
            Anulado = value
        End Set
    End Property

    Public Property pMonto As Decimal
        Get
            Return Monto
        End Get
        Set(value As Decimal)
            Monto = value
        End Set
    End Property

    Public Property pNroComprobante As String
        Get
            Return NroComprobante
        End Get
        Set(value As String)
            NroComprobante = value
        End Set
    End Property

    'Metodos de la clase transaccion

    'Vamos a crear un metodo para recuperar la lista de compras utilizando el procedimiento almacenado
    Shared Function RecuperarCompras() As DataTable
        Return gDatos.TraerDataTable("spListarCompras")
    End Function

    ''
    ''Metodo p/ listar las ventas
    ''
    Shared Function RecuperarVentas() As DataTable
        Return gDatos.TraerDataTable("spListarVentas")
    End Function

    ''
    ''Listar ventas x rango de fecha
    ''
    Shared Function RecuperarVentasPorRangoFecha(vFecha1 As Date, vFecha2 As Date) As DataTable
        Return gDatos.TraerDataTable("spConsultarCompraxFecha", vFecha1, vFecha2)
    End Function

    'Metodo para insertar un registro en la tabla Transaccion
    Sub Insertar()
        'Guardamos en el atributo de la clase en ultimo valor insertado de la columna TransaccionID, que 
        'devuelve el procedimiento almcenado. 
        'El metodo TraerValor de la clase gDatos ejecuta el procedimiento alamcenado y recuperar valor

        'Me.TransaccionID = gDatos.TraerValor("spInsertarTransaccion", Me.TransaccionID, Me.TipoOperacionID,
        '                                     Me.Fecha, Me.UsuarioID, Me.Anulado, Me.Monto, Me.NroComprobante)

        Me.TransaccionID = gDatos.TraerValor("spInsertarTransaccion", Me.TransaccionID, Me.TipoOperacionID,
                                             Me.Fecha, Me.UsuarioID, Me.Anulado, Me.Monto, Me.NroComprobante)
    End Sub

    ''
    ''Metodo de la clase Trnsaccion p/ actualizar el monto de la transaccion
    ''
    Shared Sub ActualizarMontoTransaccion(vTransaccionID As Integer, vMonto As Integer)
        gDatos.Ejecutar("spActualizarMontoTransaccion", vTransaccionID, vMonto)
    End Sub

    'Listar fechas
    Public Function RecuperarFechas() As DataTable
        'Llamamos al metodo de la clase gDatos para ejecutar el procedimiento almacenado
        Return gDatos.TraerDataTable("spistarFechas")
    End Function
End Class

