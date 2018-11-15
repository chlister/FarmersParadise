var SelectedBarn = {};

function Barnview_init(object) {
    SelectedBarn = object;
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);
        SelectedBarn = data;
        nav_updateNavigationView(true, true, false, false);
        $("#BarnHeader").text("BarnView : " + SelectedBarn.BarnName);
        Barnview_GetBoxes();
    };
    callWebservice('GET', 'Barn/', object);
}

function Barnview_Update() {
    $("#BarnHeader").text("BarnView : " + SelectedBarn.BarnName);
    nav_updateNavigationView(true, true, false, false);
    Barnview_GetBoxes();
}

function Barnview_Create(type) {
    $("#js-page").load("Page/CreateView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            CreateView_init(type);
        }
    });
}

function BarnView_loadBoxView(object) {
    $("#js-page").load("Page/BoxView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            Boxview_init(object);
        }
    });
}

function Barnview_GetBoxes() {
    boxContainer = document.getElementById("js-boxContainer");

    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        for (i = 0; i < data.length; i++) {
            htmlString += '<tr><td colspan="2" onclick="BarnView_loadBoxView(' + data[i].BoxId + ')">' + data[i].BoxName + "</td></tr>";
        }
        // Adds the strings to the html page
        boxContainer.insertAdjacentHTML("beforeend", htmlString);
    };
    callWebservice('POST', 'Box/BoxFromBarn', -1, JSON.stringify(SelectedBarn));

}