(function (lacing) {

    lacing.AdministradorView = {

        RefreshLista: function () {
            lacing.helpers.CloseModal('CrearAdministradorPopup');
            lacing.helpers.CloseModal('EditarAdministradorPopup');
        }
    }

})(window.lacing = window.lacing || {});