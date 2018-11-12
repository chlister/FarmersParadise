// this is needed because the .js file will load before the DOM
window.onload = function () {

    httpRequest.onload = function () {
        // if object is created or OK show the object
        if (httpRequest.status === 200 || httpRequest.status === 201) {
            var data = JSON.parse(httpRequest.responseText);
            if (data.length !== 0) {
                console.log(data);
                loadFarmView(data[0]);
            }
            else {
                var jsPage = $("#js-page");
                jsPage.load("Page/initPageView.html");
            }
        }
    };
    callWebservice("GET", "farm");
};

function loadFarmView(object) {
    $("#js-page").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            Farmview_init(object);
        }
    });
}

function btnCreateFarm() {
    if ($("#farmName").val() === "") {
        alert("Udfyld et navn til gården");
    }
    else {
        createFarm();
        //loadFarmView();
    }
}

function createFarm() {
    // TODO Webservice call
    var currentFarm = {};
    currentFarm.FarmId = 0;
    currentFarm.FarmName = $("#farmName").val();
    currentFarm.Barns = null;
    // Subscribes to an event wich returns the JSON data
    httpRequest.onload = function () {
        // if object is created or OK show the object
        if (httpRequest.status === 200 || httpRequest.status === 201) {
            var data = JSON.parse(httpRequest.responseText);
            if (data.length !== 0) {
                console.log(data);
                loadFarmView(data);
            }
        }
    };
    callWebservice('POST', 'Farm', -1, JSON.stringify(currentFarm));
}

function renderHTML(data) {
    var htmlString = "";

    // Concatinates the information to a string
    for (i = 0; i < data.length; i++) {
        htmlString += "<p>" + data[i].FarmName + ".</p>";
    }
    // Adds the strings to the html page
    farmContainer.insertAdjacentHTML("beforeend", htmlString);

}

$(document).ready(function () {
    console.info("Ready");
});