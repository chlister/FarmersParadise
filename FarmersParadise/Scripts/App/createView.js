function CreateBarn() {
    if ($("#CreateName").val() === "") {
        alert("Please Enter Name");
    }
    else {
        // TODO Webservice call
        var currentBarn = {};
        currentBarn.BarnId = 0;
        currentBarn.BarnName = $("#CreateName").val();
        currentBarn.Farm = Farm;
        currentBarn.Barns = null;
        // Subscribes to an event wich returns the JSON data
        httpRequest.onload = function () {
            // if object is created or OK show the object
            if (httpRequest.status === 200 || httpRequest.status === 201) {
                var data = JSON.parse(httpRequest.responseText);
                if (data.length !== 0) {
                    console.log(data);
                    alert("Barn was created!");
                    Farmview_Update();
                }
            }
        };
        callWebservice('POST', 'Barn', -1, JSON.stringify(currentBarn));
    }
}

function CreateSensor() {
    // TODO Webservice call
    var currentSensor = {};
    currentSensor.SensorId = 0;
    currentSensor.MacAddress = $("#CreateExtraValue").val();
    currentSensor.SensorName = $("#CreateName").val();
    currentSensor.Barn = null;
    // Subscribes to an event wich returns the JSON data
    httpRequest.onload = function () {
        // if object is created or OK show the object
        if (httpRequest.status === 200 || httpRequest.status === 201) {
            var data = JSON.parse(httpRequest.responseText);
            if (data.length !== 0) {
                console.log(data);
                alert("Sensor was created!");
                Farmview_Update();
            }
        }
    };
    callWebservice('POST', 'TemperatureSensor', -1, JSON.stringify(currentSensor));
}

function CreatePig() {
        // TODO Webservice call
        var currentPig = {};
        currentPig.PigId = 0;
        currentPig.CHRTag = $("#CreateExtraValue").val();
        currentPig.PigType = $("#CreateSelectValue").val();
        //currentPig.PigType = 1;
        currentPig.Box = null;
        // Subscribes to an event wich returns the JSON data
        httpRequest.onload = function () {
            // if object is created or OK show the object
            if (httpRequest.status === 200 || httpRequest.status === 201) {
                var data = JSON.parse(httpRequest.responseText);
                if (data.length !== 0) {
                    console.log(data);
                    alert("Pig was created!");
                    Farmview_Update();
                }
            }
        };
        callWebservice('POST', 'Pig', -1, JSON.stringify(currentPig));
    
}

function CreatView_Create() {
    if (createType === "Barn") {
        if ($("#CreateName").val() === "") {
            alert("Please Enter Name");
            return;
        }
        CreateBarn();
    }
    else if (createType === "Sensor") {
        if ($("#CreateName").val() === "") {
            alert("Please Enter Name");
            return;
        }
        if ($("#CreateExtraValue").val() === "") {
            alert("Please Enter MAC");
            return;
        }
        CreateSensor();
    }
    else if (createType === "Pig") {
        if ($("#CreateExtraValue").val() === "") {
            alert("Please Enter CHRTag");
            return;
        }
        CreatePig();
    }


    $("#js-page").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            
        }
    });
}