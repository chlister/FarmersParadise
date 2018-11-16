var SelectedBox = {};

function Boxview_init(object) {
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);
        SelectedBox = data;
        nav_updateNavigationView(true, true, true, false);
        $("#BoxHeader").text("BoxView : " + SelectedBox.BoxName);
        Boxview_GetPigs();
    };
    callWebservice('GET', 'Box/', object);
}

function Boxview_Update() {
    nav_updateNavigationView(true, true, true, false);
    $("#BoxHeader").text("Boxview : " + SelectedBox.BoxName);
    Boxview_GetPigs();
}

function Boxview_GetPigs() {
    pigContainer = document.getElementById("js-pigContainer");

    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        for (i = 0; i < data.length; i++) {
            htmlString += '<tr><td tabindex="' + data[i].PigId + '" data-long-press-delay="1000"> CHR: ' + data[i].CHRTag + '</td><td><input type="checkbox" onclick="AddRemoveToMoveList(' + data[i].PigId + ')" /></td></tr>';
        }
        // Adds the strings to the html page
        pigContainer.insertAdjacentHTML("beforeend", htmlString);
    };
    callWebservice('POST', 'Pig/PigsFromBox', -1, JSON.stringify(SelectedBox));

}


