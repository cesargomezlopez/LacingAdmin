(function (lacing) {

    lacing.DocenteView = {

        RefreshLista: function () {
            lacing.helpers.CloseModal('CrearDocentePopup');
            lacing.helpers.CloseModal('EditarDocentePopup');
        }
    }

})(window.lacing = window.lacing || {});