
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Sistema Restaurante | www.uaa.edu.py</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="~/script/css/bootstrap.min.css">

    <!-- Font Awesome -->
    <link rel="stylesheet" href="~/script/css/font-awesome.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="~/script/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="~/script/css/_all-skins.min.css">
    <link rel="apple-touch-icon" href="~/script/img/apple-touch-icon.png">
    <link rel="shortcut icon" href="~/script/img/favicon.ico">

    @*Agregamos el archivo css del jquery datatables*@
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" />

</head>
<body class="hold-transition skin-blue sidebar-mini">
    <div class="wrapper">

        <header class="main-header">

            <!-- Logo -->
            <a href="index2.html" class="logo">
                <!-- mini logo for sidebar mini 50x50 pixels -->
                <span class="logo-mini"><b>RE</b>S</span>
                <!-- logo for regular state and mobile devices -->
                <span class="logo-lg"><b>Restaurante</b></span>
            </a>

            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar navbar-static-top" role="navigation">
                <!-- Sidebar toggle button-->
                <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                    <span class="sr-only">Navegación</span>
                </a>
                <!-- Navbar Right Menu -->
                <div class="navbar-custom-menu">
                    <ul class="nav navbar-nav">
                        <!-- Messages: style can be found in dropdown.less-->
                        <!-- User Account: style can be found in dropdown.less -->
                        <li class="dropdown user user-menu">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <small class="bg-red">Online</small>
                                <span class="hidden-xs">Carlos Ozuna</span>
                            </a>
                            <ul class="dropdown-menu">
                                <!-- User image -->
                                <li class="user-header">

                                    <p>
                                        Sistema Restaurante
                                        <small>https://www.youtube.com/channel/UCyoh__vvc7WKqZYIt-OgjLA</small>
                                    </p>
                                </li>

                                <!-- Menu Footer-->
                                <li class="user-footer">

                                    <div class="pull-right">
                                        <a href="#" class="btn btn-default btn-flat">Cerrar</a>
                                    </div>
                                </li>
                            </ul>
                        </li>

                    </ul>
                </div>

            </nav>
        </header>
        <!-- Left side column. contains the logo and sidebar -->
        <aside class="main-sidebar">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <!-- Sidebar user panel -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu">
                    <li class="header"></li>

                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-laptop"></i>
                            <span>Mantenimiento</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="Categoria"><i class="fa fa-circle-o"></i> Categorias</a></li>
                            <li><a href="Producto"><i class="fa fa-circle-o"></i> Productos</a></li>
                        </ul>
                    </li>

                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-th"></i>
                            <span>Compras</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="~/Transaccion/Compra"><i class="fa fa-circle-o"></i> Ingresos</a></li>

                        </ul>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-shopping-cart"></i>
                            <span>Ventas</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="~/Transaccion/Venta"><i class="fa fa-circle-o"></i> Ventas</a></li>

                        </ul>
                    </li>

                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-folder"></i> <span>Acceso</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="#"><i class="fa fa-circle-o"></i> Usuarios</a></li>

                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-plus-square"></i> <span>Ayuda</span>
                            <small class="label pull-right bg-red">PDF</small>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-info-circle"></i> <span>Acerca De...</span>
                            <small class="label pull-right bg-yellow">IT</small>
                        </a>
                    </li>

                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>





        <!--Contenido-->
        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper">

            <!-- Main content -->
            <section class="content">

                <div class="row">
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header with-border">
                                <h3 class="box-title">Sistema de Administración de Restaurante</h3>
                                <div class="box-tools pull-right">
                                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>

                                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <!--Contenido-->
                                        <div>
                                            @RenderBody
                                        </div>
                                        <!--Fin Contenido-->
                                    </div>
                                </div>

                            </div>
                        </div><!-- /.row -->
                    </div><!-- /.box-body -->
                </div><!-- /.box -->
        </div><!-- /.col -->
    </div><!-- /.row -->
    </section><!-- /.content -->
    </div><!-- /.content-wrapper -->
    <!--Fin-Contenido-->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">
            <b>Version</b> 2.3.0
        </div>
        <strong>Copyright &copy; 2017-2020 <a href="http://www.uaa.edu.py">UAA</a>.</strong> All rights reserved.
    </footer>


    <!-- jQuery 2.1.4 -->
    <script src="~/script/js/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="~/script/js/bootstrap.min.js"></script>
    <!-- AdminLTE App -->
    <script src="~/script/js/app.min.js"></script>

    @*Agregamos las referencias a los archivos js del jquery dataTables*@
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#mi_tabla').DataTable();
        });
    </script>

</body>
</html>

