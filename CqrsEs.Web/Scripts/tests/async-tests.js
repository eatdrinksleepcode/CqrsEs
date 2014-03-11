$.ajaxSetup({
    async: false
});

var successUrl = "/test/success";
var failureUrl = "/test/failure";

var data;

beforeEach(function() {
    data = new Data(successUrl, failureUrl);
});

it("Success should succeed", function () {

    var resultText = "test call succeeded";

    $.mockjax({
        url: successUrl,
        status: 200,
        statusText: resultText
    });

    data.doSuccess();

    expect(asyncResult).toBe(resultText);
});

it("Failure should fail", function () {

    var resultText = "test call failed";

    $.mockjax({
        url: failureUrl,
        status: 400,
        statusText: resultText
    });

    data.doFailure();

    expect(asyncResult).toBe(resultText);
});
