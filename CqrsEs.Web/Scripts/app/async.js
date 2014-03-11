function Data(successUrl, failureUrl) {

    this.successUrl = successUrl;
    this.failureUrl = failureUrl;
    this.asyncResult = "";

    this.doSuccess = this.doSuccess.bind(this);
    this.doFailure = this.doFailure.bind(this);
};

Data.prototype.show = function (message) {
    this.asyncResult = message;
    $("#displayResult").html(asyncResult);
};

Data.prototype.exec = function(url) {
    var show = this.show;
    $.ajax({ url: url })
        .done(function (data, textStatus, jqXhr) { show(jqXhr.statusText); })
        .fail(function (jqXhr) { show(jqXhr.statusText); });
};

Data.prototype.doSuccess = function () {
    this.exec(this.successUrl);
};

Data.prototype.doFailure = function () {
    this.exec(this.failureUrl);
};
