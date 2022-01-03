Imports ClaseRestaurante.Util
Public Class Categoria

#Region "Atributos"
    Private CategoriaID As Integer
    Private Descripcion As String
    Private Activo As String
#End Region

#Region "Propiedades"
    Public Property pCategoriaID() As Integer
        Get
            Return CategoriaID
        End Get

        Set(ByVal value As Integer)
            CategoriaID = value
        End Set
    End Property

    Public Property pDescripcion() As String
        Get
            Return Descripcion
        End Get

        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property

    Public Property pActivo() As String
        Get
            Return Activo
        End Get

        Set(ByVal value As String)
            Activo = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Sub Insertar()
        Try
            gDatos.Ejecutar("spInsertarCategoria", Me.Descripcion, Me.Activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Actualizar()
        Try
            gDatos.Ejecutar("spActualizarCategoria", Me.CategoriaID, Me.Descripcion, Me.Activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarCategoria", Me.CategoriaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RecuperarRegistro(ByVal vCodigo As Integer) As Categoria
        Try
            Dim dtCategoria As New Data.DataTable("Categoria")
            dtCategoria = gDatos.TraerDataTable("spConsultarCategoria", vCodigo)
            If dtCategoria.Rows.Count > 0 Then
                Dim vCategoria As New Categoria
                vCategoria.pCategoriaID = dtCategoria.Rows(0).Item("CategoriaID")
                vCategoria.pDescripcion = dtCategoria.Rows(0).Item("Descripcion")
                vCategoria.pActivo = dtCategoria.Rows(0).Item("Activo")
                Return vCategoria
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecuperarRegistrosCategoria() As DataTable
        Try
            Dim dtCategoria As New Data.DataTable("Categoria")
            dtCategoria = gDatos.TraerDataTable("spListarCategorias")
            Return dtCategoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' Metodo para recuperar registro de la tabla utilizando el procedimiento almacenado
    Public Function RecuperarCategorias() As DataTable
        'Llamamos al metodo de la clase gDatos para ejecutar el procedimiento almacenado
        Return gDatos.TraerDataTable("spListarCategorias")
    End Function
#End Region

End Class
