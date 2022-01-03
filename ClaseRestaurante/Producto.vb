Imports ClaseRestaurante.Util
Public class Producto

   #Region "Atributos"
   private ProductoID as Integer
   private Codigo as String
   private Nombre as String
   private Preparacion as String
   private Costo as Decimal
   private PrecioVenta as Decimal
   private UnidadMedidaID as Integer
   private Presentacion as String
   private UsaIngrediente as String
   private Activo as String
   private CategoriaID as Integer
   private Existencia as Integer
   #End Region

   #Region "Propiedades"
   public property pProductoID() as Integer
       get
           return ProductoID
       end get

       set(byval value as Integer)
           ProductoID = value
       end set
   end property

   public property pCodigo() as String
       get
           return Codigo
       end get

       set(byval value as String)
           Codigo = value
       end set
   end property

   public property pNombre() as String
       get
           return Nombre
       end get

       set(byval value as String)
           Nombre = value
       end set
   end property

   public property pPreparacion() as String
       get
           return Preparacion
       end get

       set(byval value as String)
           Preparacion = value
       end set
   end property

   public property pCosto() as Decimal
       get
           return Costo
       end get

       set(byval value as Decimal)
           Costo = value
       end set
   end property

   public property pPrecioVenta() as Decimal
       get
           return PrecioVenta
       end get

       set(byval value as Decimal)
           PrecioVenta = value
       end set
   end property

   public property pUnidadMedidaID() as Integer
       get
           return UnidadMedidaID
       end get

       set(byval value as Integer)
           UnidadMedidaID = value
       end set
   end property

   public property pPresentacion() as String
       get
           return Presentacion
       end get

       set(byval value as String)
           Presentacion = value
       end set
   end property

   public property pUsaIngrediente() as String
       get
           return UsaIngrediente
       end get

       set(byval value as String)
           UsaIngrediente = value
       end set
   end property

   public property pActivo() as String
       get
           return Activo
       end get

       set(byval value as String)
           Activo = value
       end set
   end property

   public property pCategoriaID() as Integer
       get
           return CategoriaID
       end get

       set(byval value as Integer)
           CategoriaID = value
       end set
   end property

   public property pExistencia() as Integer
       get
           return Existencia
       end get

       set(byval value as Integer)
           Existencia = value
       end set
   end property

   #End Region

   #Region "Metodos"
   Public Sub Insertar()
       Try
       If validaObjeto() Then
                gDatos.Ejecutar("spInsertarProducto", Me.Codigo, Me.Nombre, Me.Preparacion, Me.Costo, Me.PrecioVenta, Me.UnidadMedidaID, Me.Presentacion, Me.UsaIngrediente, Me.Activo, Me.CategoriaID, Me.Existencia)
            End If
       Catch ex As Exception
       Throw ex
       End Try
   End Sub

   Public Sub Actualizar()
       Try
       If validaObjeto() Then
                gDatos.Ejecutar("spActualizarProducto", Me.ProductoID, Me.Codigo, Me.Nombre, Me.Preparacion, Me.Costo, Me.PrecioVenta, Me.UnidadMedidaID, Me.Presentacion, Me.UsaIngrediente, Me.Activo, Me.CategoriaID, Me.Existencia)
            End If
       Catch ex As Exception
       Throw ex
       End Try
   End Sub

   Public Sub Eliminar()
       Try
       If validaObjeto() Then
                gDatos.Ejecutar("spEliminarProducto", Me.ProductoID)
            End If
       Catch ex As Exception
       Throw ex
       End Try
   End Sub

    Public Function RecuperarRegistro(ByVal vCodigo As Integer) As Producto
        Try
            Dim dtProducto As New Data.DataTable("Producto")
            dtProducto = gDatos.TraerDataTable("spConsultarProducto", vCodigo)
            If dtProducto.Rows.Count > 0 Then
                Dim vProducto As New Producto
                vProducto.pProductoID = dtProducto.Rows(0).Item("ProductoID")
                vProducto.pCodigo = dtProducto.Rows(0).Item("Codigo")
                vProducto.pNombre = dtProducto.Rows(0).Item("Nombre")
                vProducto.pPreparacion = dtProducto.Rows(0).Item("Preparacion")
                vProducto.pCosto = dtProducto.Rows(0).Item("Costo")
                vProducto.pPrecioVenta = dtProducto.Rows(0).Item("PrecioVenta")
                vProducto.pUnidadMedidaID = dtProducto.Rows(0).Item("UnidadMedidaID")
                vProducto.pPresentacion = dtProducto.Rows(0).Item("Presentacion")
                vProducto.pUsaIngrediente = dtProducto.Rows(0).Item("UsaIngrediente")
                vProducto.pActivo = dtProducto.Rows(0).Item("Activo")
                vProducto.pCategoriaID = dtProducto.Rows(0).Item("CategoriaID")
                vProducto.pExistencia = dtProducto.Rows(0).Item("Existencia")
                Return vProducto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecuperarRegistrosProducto() As DataTable
        Try
            Dim dtProducto As New Data.DataTable("Producto")
            dtProducto = gDatos.TraerDataTable("spConsultarProducto", 0)
            Return dtProducto
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''
    ''Metodo para actualizar la existencia del producto
    ''
    Shared Sub ActualizarExistencia(vTipoOperacionID As Integer, vProductoID As Integer, vCantidad As Integer)
        gDatos.Ejecutar("spActualizarExistencia", vTipoOperacionID, vProductoID, vCantidad)
    End Sub

    Private Function validaObjeto() As Boolean

        Return True

    End Function

    '---------------------------------------------------------------------------------------------------------------
    Public Shared Function RecuperarRegistrosPorCategoria() As DataTable
        Try
            Dim dtProducto As New Data.DataTable("Producto")
            dtProducto = gDatos.TraerDataTable("spConsultarProducto", 0)
            Return dtProducto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function RecuperarRegistrosPorCategoria(vCodCategoria As Integer) As DataTable
        Return gDatos.TraerDataTable("spProductoxCategoria", vCodCategoria)
    End Function

#End Region
End class
