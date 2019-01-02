function removeButtonClicked(clickedId) {
    $.ajax({
        url: "Action/RemoveNode",
        type: 'GET',
        data: { id: clickedId },
        success: function () {
            location.reload();
        }
    });
}
function hideButtonClicked(clickedId) {
    parentDiv = $("div#" + clickedId);
    if (parentDiv.children("div").is(':visible')) {
        parentDiv.children("div").hide();
        parentDiv.children("#hideBtn").text("show");
    }
    else {
        parentDiv.children("div").show();
        parentDiv.children("#hideBtn").text("hide");
    }
}