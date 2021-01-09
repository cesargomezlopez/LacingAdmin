(function (lacing) {

    lacing.LaboratorioView = {

        RefreshLista: function () {
            lacing.helpers.CloseModal('CrearLaboratorioPopup');
            lacing.helpers.CloseModal('EditarLaboratorioPopup');
        }
    }

})(window.lacing = window.lacing || {});