(function (lacing) {

    lacing.FacultadView = {

        RefreshLista: function () {
            lacing.helpers.CloseModal('CrearFacultadPopup');
            lacing.helpers.CloseModal('EditarFacultadPopup');
        }
    }

})(window.lacing = window.lacing || {});