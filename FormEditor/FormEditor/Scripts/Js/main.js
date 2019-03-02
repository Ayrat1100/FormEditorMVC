"use strict";
/*globals $:false */
var parentElement = document.getElementsByClassName("formContainer")[0].getElementsByClassName("row form-group")[0];

function SetSelectHundler() {
    var currentCloseBtn = document.querySelectorAll('.custom-select');

    for (var i = currentCloseBtn.length - 1; i >= 0; i--) {
        currentCloseBtn[i].addEventListener("change", ChangeHundler);
    }
}
$().ready(function () {
    // add/remove block(s)
    $(".delete").click(RemoveBlock);
    $("#addField").click(AddBlock);
    SetSelectHundler();
});

RecalculateIndexes();
function SetSelectChanged() {
    ChangeHundler();
}

function FindParent(el, cl) {
    var elem = el;

    while (elem.className !== cl) {
        if (elem.tagName.toLowerCase() === 'html') return false;
        elem = elem.parentNode;
    }
    return elem;
}

function RemoveBlock()
{
    if (document.getElementsByClassName("row form-group block").length === 1)
    {
        return;
    }
    else
    {
        FindParent(this, "row form-group block").remove();
        RecalculateIndexes();
    }
}

function AddBlock() {
    var copyElement = parentElement.cloneNode(true);
    copyElement.getElementsByClassName("form-control headerInput")[0].value = "";
    copyElement.getElementsByClassName("form-control blockArea")[0].value = "";
    copyElement.getElementsByClassName("checkboxMand")[0].checked = false;
    $('.formContainer').append(copyElement);
    $(".delete").click(RemoveBlock);
    SetSelectHundler();
    RecalculateIndexes();
    window.scrollTo(0, document.body.scrollHeight);
    return false;
}


function ChangeHundler() {
    var textareaIndex = new Set([3, 4, 5]);
    var placeholderIndex = new Set([1, 2]);
    var findOldEl = FindParent(this, "row form-group block").getElementsByClassName("col questEl")[0];
    var inputText = findOldEl.getElementsByClassName("form-control blockArea")[0].value;

    if (textareaIndex.has(+this.value)) {
        findOldEl.replaceChild(CreateTextarea(inputText), findOldEl.children[0]);
        RecalculateIndexes();
        return;
    }

    if (placeholderIndex.has(+this.value)) {
        findOldEl.replaceChild(CreateInput(inputText), findOldEl.children[0]);
        RecalculateIndexes();
        return;
    }
}
function CreateInput(inputText) {
    var element = document.createElement("input");
    element.setAttribute("class", "form-control blockArea");
    element.setAttribute("name", "Blocks[0].TextField");
    element.setAttribute("rows", "2");
    element.value = inputText;
    return element;
}

function CreateTextarea(inputText) {
    var element = document.createElement("textarea");
    element.setAttribute("class", "form-control blockArea");
    element.setAttribute("name", "Blocks[0].TextField");
    element.setAttribute("rows", "2");
    element.value = inputText;
    return element;
}

function RecalculateIndexes() {
    var blocks = document.getElementsByClassName("formContainer")[0].getElementsByClassName("row form-group block");

    for (var i = blocks.length - 1; i >= 0; i--) {
        blocks[i].getElementsByClassName("form-control headerInput")[0].setAttribute("name", "Blocks[" + i +"].Header");
        blocks[i].getElementsByClassName("custom-select")[0].setAttribute("name", "Blocks[" + i + "].FieldsType");
        blocks[i].getElementsByClassName("form-control blockArea")[0].setAttribute("name", "Blocks[" + i + "].TextField");
        blocks[i].getElementsByClassName("checkboxMand")[0].setAttribute("name", "Blocks[" + i +"].Mandatory");
    }
}
