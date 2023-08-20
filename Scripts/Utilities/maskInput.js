
var listMask = [];
$(function () {
    $("input").each(function (index) {
        var mask = "";
        var atributos = $(this)[0].attributes;

        $.each(atributos, function (index, value) {
            if (value.name == "mask") {

                mask = value.nodeValue;
            }
        });

        if (mask != "") {
            if (mask == "num") {

                var e = this;
                AddMaskNumber(e)
            } else {
                var input = { index, mask }
                listMask.push(input);
            }
        }
    });
    AddMaskInputs(listMask);
})

function AddMaskNumber(element) {
    var maskOptions =
    {
        mask: Number,
        //Cantidad de decimales
        scale: 2,
        //Permitir negativos
        signed: false,
        //Separador
        thousandsSeparator: ',',
        //Agregar decimales
        padFractionalZeros: true,
        normalizeZeros: true,
        //Si ingresa coma agregar punto
        radix: '.',
        mapToRadix: [','],
        //Minimo y maximo
        min: 0,
        max: 999999999
    };
    var mask = IMask(element, maskOptions);
    console.log('se añidio la mas')
}

function AddMaskInputs(list) {
    var listInput = $('input');
    for (let i = 0; i < list.length; i++) {
        var element = listInput[list[i].index];
        var maskOptions =
        {
            mask: list[i].mask
        };
        var mask = IMask(element, maskOptions);
    }

}