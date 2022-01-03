Imports ClaseRestaurante.Util
Public class UnidadMedida

   #Region "Atributos"
   private UnidadMedidaID as Integer
   private Descripcion as String
   #End Region

   #Region "Propiedades"
   public property pUnidadMedidaID() as Integer
       get
           return UnidadMedidaID
       end get

       set(byval value as Integer)
           UnidadMedidaID = value
       end set
   end property

   public property pDescripcion() as String
       get
           return Descripcion
       end get

       set(byval value as String)
           Descripcion = value
       end set
   end property

   #End Region

   #Region "Metodos"
   Public Sub Insertar()
       Try
       If validaObjeto() Then
                gDatos.Ejecutar("spInsertarUnidadMedida", Me.UnidadMedidaID, Me.Descripcion)
            End If
       Catch ex As Exception
       Throw ex
       End Try
   End Sub

   Public Sub Actualizar()
       Try
       If validaObjeto() Then
                gDatos.Ejecutar("spActualizarUnidadMedida", Me.UnidadMedidaID, Me.Descripcion)
            End If
       Catch ex As Exception
       Throw ex
       End Try
   End Sub

   Public Sub Eliminar()
       Try
       If validaObjeto() Then
                gDatos.Ejecutar("spEliminarUnidadMedida", Me.UnidadMedidaID)
            End If
       Catch ex As Exception
       Throw ex
       End Try
   End Sub

    Public Function RecuperarRegistro(ByVal vCodigo As Integer) As UnidadMedida
        Try
            Dim dtUnidadMedida As New Data.DataTable("UnidadMedida")
            dtUnidadMedida = gDatos.TraerDataTable("spConsultarUnidadMedida", vCodigo)
            If dtUnidadMedida.Rows.Count > 0 Then
                Dim vUnidadMedida As New UnidadMedida
                vUnidadMedida.pUnidadMedidaID = dtUnidadMedida.Rows(0).Item("UnidadMedidaID")
                vUnidadMedida.pDescripcion = dtUnidadMedida.Rows(0).Item("Descripcion")
                Return vUnidadMedida
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecuperarRegistrosUnidadMedida() As DataTable
       Try
       Dim dtUnidadMedida As New Data.DataTable("UnidadMedida")
            dtUnidadMedida = gDatos.TraerDataTable("spConsultarUnidadMedida", 0)
            'dtUnidadMedida = gDatos.TraerDataTable("spConsultarUnidadMedida")
            Return dtUnidadMedida
       Catch ex As Exception
       Throw ex
       End Try
   End Function

   Private Function validaObjeto() As Boolean

        Return True

    End Function

   #End Region
end class
