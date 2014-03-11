var asyncResult;

var exec = function (url) {
    $.ajax({ url: url })
        .done(function() { asyncResult = "Success!"; })
        .fail(function() { asyncResult = "Failure!"; });
};

var doSuccess = function() {
    exec("/Home/Success");
};

var doFailure = function() {
    exec("/Home/Failure");
};

$("#cmdSuccess").on("click", doSuccess);
$("#cmdFailure").on("click", doFailure);
