(function (lacing) {
    lacing.regexHelper = {

        RegexDNI: "^\\d{8}(?:[-\\s]\\d{4})?$",
        RegexSoloLetras: "^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]*$",
        RegexCodigoURP: "^\\d{9}(?:[-\\s]\\d{4})?$"
    }
})(window.lacing = window.lacing || {})