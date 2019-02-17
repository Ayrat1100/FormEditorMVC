"use strict";
/*globals $:false */
var counter = 1;

$().ready(function () {

    // add/remove block(s)

    $(".delete").click(RemoveBlock);
    $("#addField").click(AddBlock);
    $(".custom-select").click(SetSelectChanged);
});

function SetSelectChanged() {
    ChangeHundler(this);
}

function FindParent(el, cl) {
    var elem = el;

    while (elem.className !== cl) {
        if (elem.tagName.toLowerCase() === 'html') return false;
        elem = elem.parentNode;
    }
    return elem;
}

function RemoveBlock() {
    FindParent(this, "row form-group block").remove();
    RecalculateIndexes();
}

function AddBlock() {
    $('.formContainer').append(
        '<div class="row form-group block">' +
        '<div class="card card-body border-dark">' +
        '<div class="row form-group text-dark">' +
        '<div class="col-md-5">' +
        '<input type="text" class="form-control headerInput" placeholder="Заголовок поля">' +
        '</div>' +
        '<div class="col-md-5">' +
        '<select class="custom-select" data-val="true" name="Blocks[' + counter + '].FieldType">' +
        '<option value="1">Текст - строка</option>' +
        '<option value="2">Текст - абзац</option>' +
        '<option selected  value="3">Один из списка</option>' +
        '<option value="4">Несколько из списка</option>' +
        '<option value="5">Раскрывающийся список</option>' +
        '</select>' +
        '</div>' +
        '<div class="col">' +
        '<div class="d-flex justify-content-end">' +
        '<a class="delete" href="#"><img src="/Content/images/icons8-delete-filled.svg"></a>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '<div class="row form-group text-dark">' +
        '<div class="col questEl">' +
        '<textarea name="Blocks[' + counter + '].TextField" id="Blocks_' + counter + '__TextField" class="form-control blockArea"  rows="2"></textarea>' +
        '</div>' +
        '</div>' +
        '<div class="row check-style justify-content-end">' +
        '<div class="custom-control custom-checkbox ">' +
        '<label>' +
        '<input type="checkbox" class="checkboxMand" checked = "checked" value="true">' +
        '<input name="Blocks[' + counter + '].Mandatory" type="hidden" value="false">'+
        'Обязательный вопрос</label>' +
        '</div>' +
        '</div>' +
        '</div> ' +
        '</div>'
    );
    counter++;
    $(".delete").click(RemoveBlock);
    $(".custom-select").click(SetSelectChanged);
    window.scrollTo(0, document.body.scrollHeight);
    RecalculateIndexes();
    //RecalculateIndexes();
}


function ChangeHundler(thisEl) {
    var textareaIndex = new Set([3, 4, 5]);
    var placeholderIndex = new Set([1, 2]);
    var findOldEl = FindParent(thisEl, "row form-group block").getElementsByClassName("col questEl")[0];


    if (textareaIndex.has(+thisEl.value)) {
        findOldEl.replaceChild(CreateTextarea(), findOldEl.children[0]);
        RecalculateIndexes();
        return;
    }

    if (placeholderIndex.has(+thisEl.value)) {
        findOldEl.replaceChild(CreateInput(), findOldEl.children[0]);
        RecalculateIndexes();
        return;
    }
}
function CreateInput() {
    var element = document.createElement("input");
    element.setAttribute("class", "form-control blockArea");
    element.setAttribute("rows", "2");
    return element;
}

function CreateTextarea() {
    var element = document.createElement("textarea");
    element.setAttribute("class", "form-control blockArea");
    element.setAttribute("rows", "2");
    return element;
}


function RecalculateIndexes() {
    var blocks = document.getElementsByClassName("formContainer")[0].getElementsByClassName("row form-group block");

    for (var i = blocks.length - 1; i >= 0; i--) {
        blocks[i].getElementsByClassName("form-control headerInput")[0].setAttribute("name", "Blocks[" + i + "].Header");

        blocks[i].getElementsByClassName("custom-select")[0].setAttribute("name", "Blocks[" + i + "].FieldType");
        blocks[i].getElementsByClassName("form-control blockArea")[0].setAttribute("name", "Blocks[" + i + "].TextField");
        blocks[i].getElementsByClassName("checkboxMand")[0].setAttribute("name", "Blocks[" + i + "].Mandatory");

    }
}