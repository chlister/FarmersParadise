var Barns = {};
var Sensors = {};
var Bigs = {};
var Farm = {};

function Farmview_init(object) {
    Farm = object;
    $("#FarmHeader").text("Farm: " + Farm.FarmName);
    Farmview_GetBarns();
}

function Farmview_Update() {
    $("#FarmHeader").text("Farm: " + Farm.FarmName);
    Farmview_GetBarns();
}

var createType = "";
function CreateView_init(type) {
    createType = type;
    $("#CreateView_Header").text("Create " + type);

    if (type === "Barn") {
        $("#CreateView_ExtraInput").hide();
        $("#CreateView_SelectInput").hide();
    }
    else if (type === "Sensor") {
        $("#CreateExtraName").text("MAC:");
        $("#CreateView_SelectInput").hide();
    }
    else if (type === "Pig") {
        $("#CreateExtraName").text("CHR:");
        $("#CreateView_SelectInput").show();
    }
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
        htmlString += "<ul>";
        for (i = 0; i < data.length; i++) {
            htmlString += '<li><button class="listbutton">' + data[i].BarnName + ".</button></li>";
        }
        htmlString += "</ul>";
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
        htmlString += "<ul>";
        for (i = 0; i < data.length; i++) {
            htmlString += '<li><button class="listbutton">' + data[i].PigId + ":" + data[i].CHRTag + ".</button></li>";
        }
        htmlString += "</ul>";
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
        htmlString += "<ul>";
        for (i = 0; i < data.length; i++) {
            htmlString += '<li><button class="listbutton" onclick="Farmview_ReadSensors(' + data[i].SensorId + ')" >' + data[i].SensorName + " (" + data[i].MacAddress + ")" + ".</button></li>";
        }
        htmlString += "</ul>";
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

function Farmview_AddBarn() {
    // todo: Call Create view

    Farmview_GetBarns();
}