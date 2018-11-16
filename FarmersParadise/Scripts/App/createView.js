var createType = "";
function CreateView_init(type) {
    createType = type;
    nav_updateNavigationView(true, false, false, true);
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
    else if (type === "Box") {
        $("#CreateView_ExtraInput").hide();
        $("#CreateView_SelectInput").hide();
    }
}

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
                    Farmview_Update();
                }
            }
        };
        callWebservice('POST', 'Pig', -1, JSON.stringify(currentPig));
    
}

function CreateBox() {
    // TODO Webservice call
    var currentBox = {};
    currentBox.BoxId = 0;
    currentBox.BoxName = $("#CreateName").val();
    currentBox.BoxType = $("#CreateSelectValue").val();
    //currentPig.PigType = 1;
    currentBox.Barn = SelectedBarn;
    currentBox.Pigs = null;
    // Subscribes to an event wich returns the JSON data
    httpRequest.onload = function () {
        // if object is created or OK show the object
        if (httpRequest.status === 200 || httpRequest.status === 201) {
            var data = JSON.parse(httpRequest.responseText);
            if (data.length !== 0) {
                console.log(data);
                Barnview_Update();
            }
        }
    };
    callWebservice('POST', 'Box', -1, JSON.stringify(currentBox));

}

function CreateView_loadFarmView() {
    $("#js-page").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {

        }
    });
}
function CreateView_loadBarnView() {
    $("#js-page").load("Page/BarnView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {

        }
    });
}

function CreatView_Create() {
    if (createType === "Barn") {
        if ($("#CreateName").val() === "") {
            alert("Please Enter Name");
            return;
        }
        CreateBarn();
        CreateView_loadFarmView();
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
        CreateView_loadFarmView();
    }
    else if (createType === "Pig") {
        if ($("#CreateExtraValue").val() === "") {
            alert("Please Enter CHRTag");
            return;
        }
        CreatePig();
        CreateView_loadFarmView();
    }
    else if (createType === "Box") {
        if ($("#CreateName").val() === "") {
            alert("Please Enter Name");
            return;
        }
        CreateBox();
        CreateView_loadBarnView()
    }


    
}

