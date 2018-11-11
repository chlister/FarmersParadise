var currentFarm = {};
var httpRequest = new XMLHttpRequest();

function createFarm() {
    // TODO Webservice call
    currentFarm.FarmName = $("#farmName").val();

    httpRequest.open('GET', 'http://localhost:53880/api/Farm');
    httpRequest.onload = function () {
        console.log(httpRequest.responseText);
    };
    httpRequest.send();

}

function callWebservice() {
    
}

$(document).ready(function () {
    console.info("Ready");
    createFarm();
});