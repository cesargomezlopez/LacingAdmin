(function (lacing) {
    lacing.helpers = {

        ShowModal: function (idModal, url) {
            $.get(url, function (html) {

                $('#' + idModal + " .modal-body").html(html);

                $('#' + idModal).modal("show");
            });

        },
        CloseModal: function (idModal) {
            $('#' + idModal).modal("hide");
        },

        ShowMessageSucces: function (message) {

            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "4000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            },
                toastr["success"](message);
        },

        ShowMessageWarning: function (message) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            },
                toastr["warning"](message);
        },

        RemoveValidationFocus: function (txtContainer, spanValidator) {
            $("#" + txtContainer + "").removeAttr("style");
            $("#" + spanValidator + "").attr("hidden", "");
        },

        ValidationFocus: function (txtContainer, spanValidator, messageValidator) {
            $("#" + txtContainer + "").focus();
            $("#" + txtContainer + "").attr("style", "border-color: red");
            $("#" + spanValidator + "").html(messageValidator);
            $("#" + spanValidator + "").removeAttr("hidden");
        },

        RegexTest: function (varInspect, textRegex, txtContainer, spanValidator, messageValidator) {
            var re = new RegExp(textRegex);
            if (!re.test(varInspect)) {
                this.ValidationFocus(txtContainer, spanValidator, messageValidator);
                return true;
            }
            else {
                this.RemoveValidationFocus(txtContainer, spanValidator);
                return false;
            }
        },

        UpdateDataTable: function (idDataTable) {
            $('#' + idDataTable).DataTable(
                {
                    aoColumns: [null, null, null, {
                        "bSortable": false
                    }],
                    language: {
                        "sSearchPlaceholder": "Buscar...",
                        "sProcessing": "Procesando...",
                        "sLengthMenu": "Mostrar _MENU_ registros",
                        "sZeroRecords": "No se encontraron resultados",
                        "sEmptyTable": "Ningún dato disponible en esta tabla",
                        "sInfo": "Mostrando del _START_ al _END_ de un total de _TOTAL_ registros",
                        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sSearch": "",
                        "sUrl": "",
                        "sInfoThousands": ",",
                        "sLoadingRecords": "Cargando...",
                        "oPaginate": {
                            "sFirst": "Primero",
                            "sLast": "Último",
                            "sNext": "Siguiente",
                            "sPrevious": "Anterior"
                        },
                        "oAria": {
                            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                        }
                    }
                }
            );
        }
    }
})(window.lacing = window.lacing || {})