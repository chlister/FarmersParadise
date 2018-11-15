var tobeMoved = [];
var moveToBox = {};
function MovePage_init(type) {
    createType = type;
    nav_updateNavigationView(true, false, false, true);
    movePage_GetPig()
}

function movePage_GetPig() {
    movepigContainer = document.getElementById("js-movepigContainer");
    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        if (data !== null) {
            htmlString += '<tr><td > CHR: ' + data.CHRTag + '</td></tr>';
        }
        tobeMoved.push(data);
        // Adds the strings to the html page
        movepigContainer.insertAdjacentHTML("beforeend", htmlString);
        if (movelist.length != 0) {
            movePage_GetPig()
        }
        else {
            getBoxes();
        }
      
    };
    callWebservice('GET', 'Pig/' + movelist.pop());
}

function getBoxes() {
    moveboxesContainer = document.getElementById("CreateSelectValue");
    var htmlString = "";

    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        for (i = 0; i < data.length; i++) {
            htmlString += '<option value="' + data[i].BoxId + '">' + data[i].BoxName + '</option>';
        };
        // Adds the strings to the html page
        moveboxesContainer.insertAdjacentHTML("beforeend", htmlString);

    };
    callWebservice('GET', 'Box/BoxWithBarn');
}

function MovePigs() {
    if ($("#CreateSelectValue").val() === "") {
        alert("Please select a Box");
        return;
    }
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        // Concatinates the information to a string
        if (data !== null) {
            moveToBox = data;
            StartMovePigs();
        }

    };
    callWebservice('GET', 'Box/' + $("#CreateSelectValue").val());

}

function StartMovePigs() {
    httpRequest.onload = function () {
        var data = JSON.parse(httpRequest.responseText);

        if (data === null) {
            alert("Error doing update ");
            return;
        }
        if (tobeMoved.length > 0) {
            StartMovePigs()
        }
        else {
            alert("Pigs has been moved");
            nav_backbuttonclick();
        }


    };
    var pig = tobeMoved.pop();
    callWebservice('PUT', '/Pig/' + pig.PigId, -1, JSON.stringify(moveToBox));
}