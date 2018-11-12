var currentFarm = {};
var httpRequest = new XMLHttpRequest();
var farmCreateBtn;
var farmContainer;

// this is needed because the .js file will load before the DOM
window.onload = function () {
    farmContainer = document.getElementById("js-farmContainer");
    farmCreateBtn = document.getElementById("js-farmCreate");
    farmCreateBtn.addEventListener("click", function () {
        if ($("#farmName").val() === "") {
            alert("Udfyld et navn til gården");
        }
        else {
            //createFarm();
            //$("#js-farmContainer").empty();
            $("#js-farmContainer").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
                if (statusTxt == "error")
                    alert("Error: " + xhr.status + ": " + xhr.statusText);
            });
        }
    });
};

function createFarm() {
    // TODO Webservice call
    currentFarm.FarmName = $("#farmName").val();

    // Subscribes to an event wich returns the JSON data
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);
        console.log(data[0].FarmName);
        renderHTML(data);
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
function callWebservice(method, APItarget) {
    var url = 'http://localhost:53880/api/' + APItarget;
    httpRequest.open(method, url);
    httpRequest.send();
}


$(document).ready(function () {
    console.info("Ready");
});