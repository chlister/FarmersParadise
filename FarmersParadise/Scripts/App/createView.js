var createType = "";
function CreateView_init(type) {
    createType = type;
    $("#CreateView_Header").text("Create " + type);

    if (type === "Barn") {
        $("#CreateView_ExtraInput").hide();
    }
    else if (type === "Sensor") {
        $("#CreateExtraName").text("MAC:");
    }
    else if (type === "Pig") {
        $("#CreateExtraName").text("CHR:");
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
        currentBarn.FarmId = Farm.FarmId;
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
                }
            }
        };
        callWebservice('POST', 'Barn', -1, JSON.stringify(currentBarn));
    }
}

function CreateSensor() {
    alert("Create Sensor not implemented! ");
}

function CreatePig() {
    alert("Create Pig not implemented! ");
}

function CreatView_Create() {
    if (createType === "Barn") {
        CreateBarn();
    }
    else if (createType === "Sensor") {
        CreateSensor();
    }
    else if (createType === "Pig") {
        CreatePig();
    }


    $("#js-page").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {

        }
    });
}