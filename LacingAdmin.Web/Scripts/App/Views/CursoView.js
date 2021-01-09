(function (lacing) {

    lacing.CursoView = {

        RefreshLista: function () {
            lacing.helpers.CloseModal('CrearCursoPopup');
            lacing.helpers.CloseModal('EditarCursoPopup');
        }
    }

})(window.lacing = window.lacing || {});