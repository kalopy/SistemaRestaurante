Imports System.Web.Mvc
'Importamos la biblioteca de clases restaurante
Imports ClaseRestaurante
Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        'En la accion Index vamos a definir la cadena de conexion de la BD
        Function Index() As ActionResult
            'Vamos a llamar al metodo inicializaSesion de la clase Util

            'Util.inicializaSesion("SQL5050.site4now.net", "DB_A6B797_RESTAURANTEXX", "DB_A6B797_RESTAURANTEXX_admin", "diosesamor1995")
            Util.inicializaSesion("MSI", "RESTAURANTEXX", "Kalo", "1234")

            'Definimos el nombre del Servidor, el nombre de la BD, el Usuario de la BD y la Contraseña

            Return View()
        End Function
    End Class
End Namespace