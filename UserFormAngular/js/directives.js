
formApp.directive("radiostringtoArray", function () {
    return function (scope, element, attrs) {

        var data = scope.dat.TextField.split(' ');

        for (var i = 0; i < data.length; i++) {
            var ulElemConteiner = angular.element("<div>");
            var ulElem = angular.element("<input>");
            ulElem.attr('ng-model','form.radioBtn['+i+']');
            var label = angular.element("<label>");
            label.addClass('Label-class');
            ulElem.attr('type', 'radio')
            if (i == 0) { ulElem.attr('checked', '') }
            ulElem.attr('id', 'radio' + data[i])
            ulElem.attr('name', 'radio' + data[0])
            ulElemConteiner.append(ulElem);
            label.attr('for', 'radio' + data[i])
            label.append(data[i]);
            ulElemConteiner.append(label);
            element.append(ulElemConteiner);
        }
    }
});

formApp.directive("chboxstringtoArray", function () {
    return function (scope, element, attrs) {

        var data = scope.dat.TextField.split(' ');

        for (var i = 0; i < data.length; i++) {
            var ulElemConteiner = angular.element("<div>");
            var ulElem = angular.element("<input>");
            ulElem.attr('ng-model','form.chbox['+i+']');
            var label = angular.element("<label>");
            label.addClass('Label-class');
            ulElem.attr('type', 'checkbox')
            ulElem.attr('id', 'check' + data[i])
            ulElem.attr('name', 'check' + data[0])
            ulElemConteiner.append(ulElem);
            label.attr('for', 'check' + data[i])
            label.append(data[i]);
            ulElemConteiner.append(label);
            element.append(ulElemConteiner);
        }
    }
});

formApp.directive("selectCategory", function () {
    return function (scope, element, attrs) {
        var data = scope.dat.TextField.split(' ');

        for (var i = 0; i < data.length; i++) {
            var ulElemConteiner = angular.element("<option>");
            ulElemConteiner.attr('value', data[i]);
            if(i===0){ulElemConteiner.attr('selected', '');}
            element.append(ulElemConteiner);
        }
        alert(data.length)
    }
});

formApp.directive("validationData", function () {
    return function (scope, element, attrs) {
        if (scope.dat.Mandatory) {
            element.attr('required', '');
        }
    }
});