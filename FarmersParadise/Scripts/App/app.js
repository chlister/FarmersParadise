var httpRequest = new XMLHttpRequest();

// this is needed because the .js file will load before the DOM
window.onload = function () {
    if (callWebservice("GET", "farm") !== "") {
        var jsPage = $("#js-page");
        jsPage.load("Page/initPageView.html");
    }
    else {
        console.log("Found a farm");
    }
};

function btnCreateFarm() {
    if ($("#farmName").val() === "") {
        alert("Udfyld et navn til gården");
    }
    else {
        createFarm();
    }
}

function createFarm() {
    // TODO Webservice call
    var currentFarm = {};
    currentFarm.FarmName = $("#farmName").val();


    // Subscribes to an event wich returns the JSON data
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);
        if (data.length !== 0) {
            console.log(data[0].FarmName);
            renderHTML(data);
        }
    };
    callWebservice('GET', 'Farm');
    //httpRequest.send();

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

// Calls the specified APItarget with the method request.
function callWebservice(method, APItarget, index = -1) {
    var url = "";
    if (index < 0)
        url = 'http://localhost:53880/api/' + APItarget;

    else
        url = 'http://localhost:53880/api/' + APItarget + '/' + index;

    httpRequest.open(method, url);
    httpRequest.send();
    return httpRequest;
}

$(document).ready(function () {
    console.info("Ready");
});