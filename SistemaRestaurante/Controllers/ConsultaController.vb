Imports System.Web.Mvc
Imports ClaseRestaurante
Namespace Controllers
    Public Class ConsultaController
        Inherits Controller

        ' GET: Consulta
        Function Index() As ActionResult
            Return View()
        End Function

        'Vamos a crear una accion para llamar a la vista para consultar los productos
        'por categoria 
        Function ProductosPorCategoria() As ActionResult
            Dim objCategoria As New Categoria
            'En un objeto ViewData vamos a cargar todas las categorias
            ViewData("categorias") = objCategoria.RecuperarCategorias.AsEnumerable
            Return View()
        End Function

    End Class
End Namespace