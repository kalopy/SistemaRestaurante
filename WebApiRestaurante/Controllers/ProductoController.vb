Imports System.Net
Imports System.Web.Http
Imports ClaseRestaurante
Namespace Controllers
    Public Class ProductoController
        Inherits ApiController
        'Funcion del servicio para retornar los productos por categoria
        'Esta funcion va a recibir el id de la categoria y se va a llamar mediante el metodo GET(url)
        Public Function GetProductos(id As Integer) As IHttpActionResult
            'Aqui creamos un objeto de la clase ProductoReposotory p/ llamar despues al metodo que retorna los productos x categoria
            Dim RepoProducto As New ProductoRepository
            Dim resul = RepoProducto.getProductos(id)
            'Verificamos si retorna algun valor
            If resul Is Nothing Then
                'Retornamos error 404 si no encuentra ningun producto
                Return NotFound()
            Else
                Return Ok(resul)
            End If
        End Function

    End Class
End Namespace