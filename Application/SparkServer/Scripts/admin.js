$(function () {

    $("#DateTimeToday").on("click", function setDateToToday() {

        var currentDateTime = new Date();
        var output = currentDateTime.toLocaleDateString();

        $("#PublishDate").val(output);

    });

});