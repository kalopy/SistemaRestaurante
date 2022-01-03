Imports System.Web.Mvc
Imports ClaseRestaurante
Namespace Controllers
    Public Class ProductoController
        Inherits Controller

        ' GET: Producto

        Function Index() As ActionResult
            'Creamos una tabla temporal p/ guardar la lista de productos
            Dim dtProductos As New DataTable
            'Llamamos al metodo de la clase Producto p/ recuperar la lista de productos
            dtProductos = Producto.RecuperarRegistrosProducto
            'Guardamos en un objeto viewdata
            ViewData("productos") = dtProductos.AsEnumerable

            Return View()
        End Function

        'Accion para llamar a la vista p/ ingresar nuevos productos
        Function Create() As ActionResult
            'Guardamos la lista de categorias en un objeto viewdata
            Dim dtCategorias As New DataTable
            'Dim vCategoria As New Categoria
            dtCategorias = Categoria.RecuperarRegistrosCategoria
            ViewData("categorias") = dtCategorias.AsEnumerable
            'Tambien necesitamos guardar las unidades de medida
            ViewData("unidades_medida") = UnidadMedida.RecuperarRegistrosUnidadMedida.AsEnumerable
            Return View()
        End Function

        'Accion para recibir los datos ingresados para nuevos productos
        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            'Creamos un objeto de la clase Producto
            Dim vProducto As New Producto
            'Asignamos en las propiedades de objeto los datos
            With vProducto
                '.pProductoID = form("productoid")
                .pActivo = form("estado")
                .pCategoriaID = form("categoriaid")
                .pCodigo = form("codigo")
                .pCosto = form("costo")
                .pExistencia = form("existencia")
                .pNombre = form("nombre")
                .pPrecioVenta = form("precio_venta")
                .pPreparacion = form("preparacion")
                .pPresentacion = form("presentacion")
                .pUnidadMedidaID = form("unidad_medidaid")
                .pUsaIngrediente = form("usa_ingrediente")
                .Insertar()
            End With
            'Retornamos a la accion Index del controlador
            Return RedirectToAction("Index")
        End Function

        'Accion para llamar a la vista p/ modificar un producto
        Function Edit(id As Integer) As ActionResult
            'Guardamos la lista de categorias en un objeto viewdata
            Dim dtCategorias As New DataTable
            'Dim vCategoria As New Categoria
            dtCategorias = Categoria.RecuperarRegistrosCategoria
            ViewData("categorias") = dtCategorias.AsEnumerable
            'Tambien necesitamos guardar las unidades de medida
            ViewData("unidades_medida") = UnidadMedida.RecuperarRegistrosUnidadMedida.AsEnumerable
            'Buscamos el producto por el codigo
            Dim vProducto As New Producto
            vProducto = vProducto.RecuperarRegistro(id)
            'Enviamos a la vista el objeto
            Return View(vProducto)
        End Function

        'Accion para recibir los datos enviados desde la Vista Edit
        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            'Creamos un objeto de la clase Producto
            Dim vProducto As New Producto
            'Asignamos en las propiedades de objeto los datos
            With vProducto
                .pProductoID = form("productoid")
                .pActivo = form("estado")
                .pCategoriaID = form("categoriaid")
                .pCodigo = form("codigo")
                .pCosto = form("costo")
                .pExistencia = form("existencia")
                .pNombre = form("nombre")
                .pPrecioVenta = form("precio_venta")
                .pPreparacion = form("preparacion")
                .pPresentacion = form("presentacion")
                .pUnidadMedidaID = form("unidad_medidaid")
                .pUsaIngrediente = form("usa_ingrediente")
                .Actualizar()
            End With
            'Retornamos a la accion Index del controlador
            Return RedirectToAction("Index")
        End Function



        'Accion para eliminar un producto
        Function Delete(id As Integer) As ActionResult
            Dim vProducto As New Producto
            vProducto.pProductoID = id
            vProducto.Eliminar()
            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace