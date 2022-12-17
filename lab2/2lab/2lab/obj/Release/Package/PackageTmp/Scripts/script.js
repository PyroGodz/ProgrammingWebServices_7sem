$("#getBtn").click(function () {
    $.ajax({
        url: "http://localhost:62724/api/values",
        success: function (data) {
           $("#output").text(JSON.stringify(data));
        }
    });
});

$("#postBtn").click(function () {
    let param = $("#input").val();
    $.ajax({
        url: `http://localhost:62724/api/values?result=${param}`,
        method: "POST"
    });
});

$("#putBtn").click(function () {
    let param = $("#input").val();
    $.ajax({
        url: `http://localhost:62724/api/values?add=${param}`,
        method: "PUT"
    });
});

$("#deleteBtn").click(function () {
    $.ajax({
        url: "http://localhost:62724/api/values",
        method: "DELETE"
    });
});