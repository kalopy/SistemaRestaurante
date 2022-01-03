
@modeltype ClaseRestaurante.Categoria

@Code
    Layout = "~/Views/Plantillas/Plantilla.vbhtml"
End Code


    
        <h2>Modificando Categoria</h2>
        <form action="create" method="post" class="form-horizontal">

            <input type="hidden" name="categoriaid" value="@Model.pCategoriaID" />

            <div class="form-group">
                <label class="control-label col-xs-3">Descripcion</label>
                <div class="col-xs-9 col-sm-4 col-md-9 col-lg-4">
                    <input type="text" class="form-control" placeholder="Descripcion" name="Descripcion" value="@Model.pDescripcion" />
                </div>
            </div>
            
            <div class="form-group">
                <label class="control-label col-xs-3">Activo?</label>
                <div class="col-xs-9 radio">

                    <label>
                        <input type="radio" class="radio" @IIf(Model.pActivo = "S", "checked", "") name="Estado" value="S" />si
                    </label>

                    <label>
                        <input type="radio" class="radio" checked name="Estado" @IIf(Model.pActivo = "N", "checked", "") value="N" />no
                    </label>

                </div>
            </div>

            <div class="form-group">

                <div class="col-xs-offset-3 col-sm-4 col-md-9 col-lg-4">
                    <button type="submit" class="btn btn-primary">Guardar</button>
                    <button type="reset" class="btn btn-default">Limpiar</button>
                </div>
            </div>

        </form>
   





