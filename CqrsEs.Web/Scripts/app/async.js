var asyncResult;

var show = function(message) {
    asyncResult = message;
    $("#displayResult").html(asyncResult);
};

var exec = function (url) {
    $.ajax({ url: url })
        .done(function(data, textStatus, jqXhr) { show(jqXhr.statusText); })
        .fail(function (jqXhr) { show(jqXhr.statusText); });
};

var doSuccess = function() {
    exec("/Home/Success");
};

var doFailure = function() {
    exec("/Home/Failure");
};

$("#cmdSuccess").on("click", doSuccess);
$("#cmdFailure").on("click", doFailure);
