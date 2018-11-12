var Barns = {};
var Sensors = {};
var Bigs = {};
var Farm = {};

function Farmview_init(object) {
    Farm = object;
    $("#FarmHeader").text("Farm: " + Farm.FarmName);
    Farmview_GetBarns();
}

function Farmview_Create(type) {
    
    $("#js-page").load("Page/CreateView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            CreateView_init(type);
        }
    });
}

function Farmview_GetBarns() {
    barnsContainer = document.getElementById("js-barnsContainer");

    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        for (i = 0; i < data.length; i++) {
            htmlString += "<button>" + data[i].BarnName + ".</button>";
        }
        // Adds the strings to the html page
        barnsContainer.insertAdjacentHTML("beforeend", htmlString);
    };
    callWebservice('GET', 'Barn');

}

function Farmview_GetPigs() {
    pigsContainer = document.getElementById("js-pigsContainer");

    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        for (i = 0; i < data.length; i++) {
            htmlString += "<button>" + data[i].PigId + ".</button>";
        }
        // Adds the strings to the html page
        pigsContainer.insertAdjacentHTML("beforeend", htmlString);
    };
    callWebservice('GET', 'Pigs');

}

function Farmview_AddBarn() {
    // todo: Call Create view

    Farmview_GetBarns();
}