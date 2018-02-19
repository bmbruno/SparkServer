$(function () {

    let relatedLinkTemplate = "<div class='new-related-link related-link-row cf'>" +
                              "    <div class='title'><label for='NewRelatedLinks_##INDEX##_Title'>Title</label><input type='text' name='NewRelatedLinks[##INDEX##].Title' id='NewRelatedLinks_##INDEX##_Title' class='new-related-links' /></div>" +
                              "    <div class='href'><label for='NewRelatedLink_##INDEX##_HREF'>Link HREF</label><input type='text' name='NewRelatedLinks[##INDEX##].HREF' id='NewRelatedLink_##INDEX##_HREF' /></div>" +
                              "    <div class='sortorder'><label for='NewRelatedLinks_##INDEX##__SortOrder'>Sort Order</label><input type='text' name='NewRelatedLinks[##INDEX##].SortOrder' id='NewRelatedLinks_##INDEX##__SortOrder' /></div>" +
                              "</div>";

    $("#DateTimeToday").on("click", function setDateToToday() {

        var currentDateTime = new Date();
        var output = currentDateTime.toLocaleDateString();

        $("#PublishDate").val(output);

    });

    $(".delete-related-link").on("click", function (e) {

        if (!confirm("Are you sure you want to delete this?")) {
            e.preventDefault();
            return false;
        }

        var iteration = $(this).data("iteration");
        var deletedField = $("#RelatedLinks_" + iteration + "__Deleted");
        deletedField.val("true");

        $(".related-link-" + iteration).slideUp(250);

    });

    $("#AddRelatedLink").on("click", function () {

        var count = $(".new-related-link").length;

        var newHTML = relatedLinkTemplate.replace(new RegExp("##INDEX##", "g"), count);

        $("#NewRelatedLink").append(newHTML);

    });

});