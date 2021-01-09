(function (lacing) {

    lacing.CarreraView = {

        RefreshLista: function () {
            lacing.helpers.CloseModal('CrearCarreraPopup');
            lacing.helpers.CloseModal('EditarCarreraPopup');
        }
    }

})(window.lacing = window.lacing || {});