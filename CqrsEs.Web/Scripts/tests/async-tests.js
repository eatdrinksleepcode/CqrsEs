$.ajaxSetup({
    async: false
});

it("Success should succeed", function () {
    $.mockjax({
        url: "/Home/Success",
        status: 200
    });

    doSuccess();

    expect(asyncResult).toBe("Success!");
});

it("Failure should fail", function () {
    $.mockjax({
        url: "/Home/Failure",
        status: 400
    });

    doFailure();

    expect(asyncResult).toBe("Failure!");
});
