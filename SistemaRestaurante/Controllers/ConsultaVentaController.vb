Imports System.Web.Mvc
Imports ClaseRestaurante
Namespace Controllers
    Public Class ConsultaVentaController
        Inherits Controller

        ' GET: ConsultaVenta
        Function Index() As ActionResult
            Return View()
        End Function

        'Vamos a crear una accion para llamar a la vista para consultar los productos
        'por categoria 
        Function VentaxFecha() As ActionResult
            Dim objFecha As New Transaccion
            'En un objeto ViewData vamos a cargar todas las categorias
            'ViewData("fechas") = objFecha.RecuperarFechas.AsEnumerable
            Return View()
        End Function

    End Class
End Namespace