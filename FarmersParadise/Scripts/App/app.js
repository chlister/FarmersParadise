

// this is needed because the .js file will load before the DOM
window.onload = function () {
    if (callWebservice("GET", "farm") !== "") {
        var jsPage = $("#js-page");
        jsPage.load("Page/initPageView.html");
    }
    else {
        console.log("Found a farm");
        $("#js-farmContainer").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "error")
                alert("Error: " + xhr.status + ": " + xhr.statusText);
            if (statusTxt == "success") {
                Farmview_init();
            }
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

$(document).ready(function () {
    console.info("Ready");
});