Imports System.Web.Mvc
Imports ClaseRestaurante
Namespace Controllers
    Public Class CategoriaController
        Inherits Controller

        ' GET: Categoria
        Function Index() As ActionResult

            Dim dtCategorias As New DataTable

            dtCategorias = Categoria.RecuperarRegistrosCategoria

            ViewData("Categorias") = dtCategorias.AsEnumerable
            Return View()
        End Function

        '---------------------------------------------------------------------------------------------------------
        'Accion para llamar a la vista Create
        Function Create() As ActionResult

            Dim dtCategoria As New DataTable


            dtCategoria = Categoria.RecuperarRegistrosCategoria

            ViewData("categoria") = dtCategoria.AsEnumerable
            Return View()
        End Function
        '---------------------------------------------------------------------------------------------------------

        'Vamos a crear la Accion para recibir los datos de la vista y procesar para guardar
        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult

            Dim vCategoria As New Categoria

            With vCategoria

                .pDescripcion = form("Descripcion")
                .pActivo = form("Estado")

                .Insertar() 'Aqui llamamos al metodo para insertar el registro
            End With
            'Llamamos a la accion del controlador para volver a la lista
            Return RedirectToAction("Index")
        End Function

        '-------------------------------------------------------------------------------------------
        'Ahora vamos a crear la accion Edit para llamar a la vista Modificar
        Function Edit(id As Integer) As ActionResult

            Dim vCategoria As New Categoria

            Dim dtCategoria As New DataTable
            dtCategoria = Categoria.RecuperarRegistrosCategoria
            'Guardamos la tabla en un viewdata
            ViewData("categoria") = dtCategoria.AsEnumerable
            'Buscamos el registro para modificar
            vCategoria = vCategoria.RecuperarRegistro(id)
            'El metodo de la clase retorna un objeto y enviamos a la vista
            Return View(vCategoria)

        End Function
        '-------------------------------------------------------------------------------------------

        'Creamos la accion para recibir del formulario los datos modificado
        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult

            Dim vCategoria As New Categoria
            'Asignamos en las propiedades de los objetos los datos del formulario
            With vCategoria
                .pCategoriaID = form("categoriaid")
                .pDescripcion = form("Descripcion")
                .pActivo = form("Estado")

                .Actualizar() 'Aqui llamamos al metodo para actualizar el registro
            End With
            'Llamamos a la accion del controlador para volver a la lista
            Return RedirectToAction("Index")
        End Function

        'Creamos la accion para eliminar
        Function Eliminar(id As Integer) As ActionResult
            Dim vCategoria As New Categoria
            vCategoria.pCategoriaID = id
            vCategoria.Eliminar()
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace