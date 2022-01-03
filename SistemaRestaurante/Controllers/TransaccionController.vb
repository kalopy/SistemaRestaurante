Imports System.Web.Mvc
Imports ClaseRestaurante
Namespace Controllers
    Public Class TransaccionController
        Inherits Controller

        ' GET: Transaccion

        'Function Index() As ActionResult
        '    Return View()
        'End Function

        Function Compra() As ActionResult
            'Vamos a guardar en un objeto ViewData las compras y dp mostrar en la vista
            ViewData("compras") = Transaccion.RecuperarCompras.AsEnumerable
            Return View()
        End Function

        Function NuevaCompra() As ActionResult
            'Vamos a cargar la lista de productos en un ViewData
            ViewData("productos") = Producto.RecuperarRegistrosProducto.AsEnumerable
            Return View()
        End Function

        'Accion p/ recibir los datos de la nueva compra
        <HttpPost()>
        Function NuevaCompra(form As FormCollection) As ActionResult
            Dim vTotal As Integer = 0
            'Vamos a obtener los datos del detalle y guardamos en array
            Dim productos() As String = form("idarticulo").Split(",").ToArray
            Dim cantidad() As String = form("cantidad").Split(",").ToArray
            Dim precio() As String = form("precio").Split(",").ToArray
            'Insertamos primero la cabecera de la compra
            Dim vTransaccion As New Transaccion
            With vTransaccion
                .pAnulado = "N"
                .pFecha = form("fecha")
                .pTipoOperacionID = 1 'Compra
                .pUsuarioID = 1
                .pMonto = form("monto")
                .pNroComprobante = form("nro_comprobante")
                .Insertar()
            End With
            'Insertamos el detalle de la compra
            'Recorremos el array de productos
            For f As Integer = 0 To productos.Length - 1
                Dim vDetalle As New DetalleTransaccion
                With vDetalle
                    .pCantidad = cantidad(f)
                    .pPrecio = precio(f)
                    .pProductoID = productos(f) 'Advertencia
                    .pTransaccionID = vTransaccion.pTransaccionID
                    .Insertar()
                End With

                ''
                ''Despues de insertar el detalle de la venta, actualizamos la existencia del producto
                ''
                Producto.ActualizarExistencia(1, productos(f), cantidad(f))

                ''Acumular el total de venta
                vTotal = vTotal + (precio(f) * cantidad(f))

            Next


            'Actualizar el monto total de le venta
            Transaccion.ActualizarMontoTransaccion(vTransaccion.pTransaccionID, vTotal)

            Return RedirectToAction("Compra")
        End Function

        ''
        ''Aciones para venta
        ''
        Function Venta() As ActionResult
            'Vamos a guardar en un objeto ViewData las compras y dp mostrar en la vista
            ViewData("ventas") = Transaccion.RecuperarVentas.AsEnumerable
            Return View()
        End Function

        Function NuevaVenta() As ActionResult
            'Vamos a cargar la lista de productos en un ViewData
            ViewData("productos") = Producto.RecuperarRegistrosProducto.AsEnumerable
            Return View()
        End Function

        'Accion p/ recibir los datos de la nueva compra
        <HttpPost()>
        Function NuevaVenta(form As FormCollection) As ActionResult

            'Acumulador de total de venta
            Dim vTotal As Integer = 0

            'Vamos a obtener los datos del detalle y guardamos en array
            Dim productos() As String = form("idarticulo").Split(",").ToArray
            Dim cantidad() As String = form("cantidad").Split(",").ToArray
            Dim precio() As String = form("precio").Split(",").ToArray
            'Insertamos primero la cabecera de la compra
            Dim vTransaccion As New Transaccion
            With vTransaccion
                .pAnulado = "N"
                .pFecha = form("fecha")
                .pTipoOperacionID = 2 'Venta
                .pUsuarioID = 1
                .pMonto = form("monto")
                .pNroComprobante = form("nro_comprobante")
                .Insertar()
            End With
            'Insertamos el detalle de la compra
            'Recorremos el array de productos
            For f As Integer = 0 To productos.Length - 1
                Dim vDetalle As New DetalleTransaccion
                With vDetalle
                    .pCantidad = cantidad(f)
                    .pPrecio = precio(f)
                    .pProductoID = productos(f) 'Advertencia
                    .pTransaccionID = vTransaccion.pTransaccionID
                    .Insertar()
                End With
                ''
                ''Despues de insertar el detalle de la venta, actualizamos la existencia del producto
                ''
                Producto.ActualizarExistencia(2, productos(f), cantidad(f))

                ''Acumular el total de venta
                vTotal = vTotal + (precio(f) * cantidad(f))
            Next

            'Actualizar el monto total de le venta
            Transaccion.ActualizarMontoTransaccion(vTransaccion.pTransaccionID, vTotal)

            Return RedirectToAction("Venta")
        End Function

    End Class
End Namespace