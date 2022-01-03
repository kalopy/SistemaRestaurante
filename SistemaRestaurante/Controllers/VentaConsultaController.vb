Imports System.Web.Mvc

Namespace Controllers
    Public Class VentaConsultaController
        Inherits Controller

        ' GET: VentaConsulta
        Function Index() As ActionResult
            Return View()
        End Function

        Function VentasPorRangoFecha() As ActionResult
            'Dim objCategoria As New Categoria
            'En un objeto ViewData vamos a cargar todas las categorias
            'ViewData("categorias") = objCategoria.RecuperarCategorias.AsEnumerable
            Return View()
        End Function

    End Class
End Namespace