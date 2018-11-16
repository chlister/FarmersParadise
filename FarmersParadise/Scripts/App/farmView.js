var Barns = {};
var Sensors = {};
var Bigs = {};
var Farm = {};
var movelist = [];

function Farmview_init(object) {
    Farm = object;
    nav_updateNavigationView(false, false, false, false);
    $("#FarmHeader").text("FarmView : " + Farm.FarmName);
    Farmview_GetBarns();
}

function Farmview_Update() {
    nav_updateNavigationView(false, false, false, false);
    $("#FarmHeader").text("FarmView : " + Farm.FarmName);
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

function farmView_loadBarnView(object) {
    $("#js-page").load("Page/BarnView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            Barnview_init(object);
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
            htmlString += '<tr><td colspan="2" onclick="farmView_loadBarnView('+ data[i].BarnId +')">' + data[i].BarnName + "</td></tr>";
        }
        // Adds the strings to the html page
        barnsContainer.insertAdjacentHTML("beforeend", htmlString);
        Farmview_GetPigs() 
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
            htmlString += '<tr><td tabindex="' + data[i].PigId + '" data-long-press-delay="1000" colspan="2" > CHR: ' + data[i].CHRTag  + '</td><td><input type="checkbox" onclick="AddRemoveToMoveList(' + data[i].PigId +')" /></td></tr>';
        }
        // Adds the strings to the html page
        pigsContainer.insertAdjacentHTML("beforeend", htmlString);
        Farmview_GetSensors();
    };
    callWebservice('GET', 'Pigs/PigsWithoutBox');

}

function Farmview_GetSensors() {
    sensorsContainer = document.getElementById("js-sensorsContainer");

    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        for (i = 0; i < data.length; i++) {
            htmlString += '<tr><td colspan="2" tabindex="' + data[i].SensorId + '" data-long-press-delay="1000" onclick="Farmview_ReadSensors(' + data[i].SensorId + ')" >' + data[i].SensorName + " (" + data[i].MacAddress + ")" + "</td></tr>";
        }
        // Adds the strings to the html page
        sensorsContainer.insertAdjacentHTML("beforeend", htmlString);
    };
    callWebservice('GET', 'TemperatureSensor');

}

function Farmview_ReadSensors(sensorid) {
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);
        alert(data);
    };
    callWebservice('GET', 'TemperatureSensor/' + sensorid);

}

function AddRemoveToMoveList(val) {
    var i = $.inArray(val, movelist);
    if (i >= 0)
        movelist.splice(i, 1)
    else
        movelist.push(val);
    
}

function Farmview_Move(type) {
    if (movelist === undefined || movelist.length == 0) {
        alert("Please select some pigs");
        return;
    }

    $("#js-page").load("Page/MovePage.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            ("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            MovePage_init(type);
        }
    });
}