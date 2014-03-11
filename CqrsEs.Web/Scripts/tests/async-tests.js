$.ajaxSetup({
    async: false
});

it("Success should succeed", function () {

    var resultText = "test call succeeded";

    $.mockjax({
        url: "/Home/Success",
        status: 200,
        statusText: resultText
    });

    doSuccess();

    expect(asyncResult).toBe(resultText);
});

it("Failure should fail", function () {

    var resultText = "test call failed";

    $.mockjax({
        url: "/Home/Failure",
        status: 400,
        statusText: resultText
    });

    doFailure();

    expect(asyncResult).toBe(resultText);
});
