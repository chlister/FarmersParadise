// this is needed because the .js file will load before the DOM
$(document).ready(function () {

    httpRequest.onload = function () {
        // Looks at the respons from API.
        if (httpRequest.status === 200 || httpRequest.status === 201) {
            var data = JSON.parse(httpRequest.responseText);
            if (data.length !== 0) {
                console.log(data);
                // If a farm is found the object is send to the next view
                loadFarmView(data[0]);
            }
            else {
                // if no object is found we start the create farm site
                var jsPage = $("#js-page");
                jsPage.load("Page/initPageView.html");
            }
        }
    };
    // Calling API for a farm
    callWebservice("GET", "farm");

    // Loads the farm view on the page
    // param object is the given Farm object from the API
    function loadFarmView(object) {
        $("#js-page").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
            if (statusTxt === "error")
                alert("Error: " + xhr.status + ": " + xhr.statusText);
            if (statusTxt === "success") {
                Farmview_init(object);
            }
        });
    }

    // Used to create a new farm
    function btnCreateFarm() {
        if ($("#farmName").val() === "") {
            alert("Udfyld et navn til gården");
        }
        else {
            createFarm();
        }
    }

    function createFarm() {
        //Initialize a Farm object 
        var currentFarm = {};
        currentFarm.FarmId = 0;
        currentFarm.FarmName = $("#farmName").val();
        currentFarm.Barns = null;
        // Subscribes to an event wich returns the JSON data
        httpRequest.onload = function () {
            // if object is created or OK show the object
            if (httpRequest.status === 200 || httpRequest.status === 201) {
                var data = JSON.parse(httpRequest.responseText);
                if (data.length !== 0) {
                    console.log(data); // Testing purpose
                    loadFarmView(data);
                }
            }
        };
        // Post the newly created Farm object - which is converted to an JSON object
        callWebservice('POST', 'Farm', object = JSON.stringify(currentFarm));
    }

    // Test code
    //function renderHTML(data) {
    //    var htmlString = "";

    //    // Concatinates the information to a string
    //    for (i = 0; i < data.length; i++) {
    //        htmlString += "<p>" + data[i].FarmName + ".</p>";
    //    }
    //    // Adds the strings to the html page
    //    farmContainer.insertAdjacentHTML("beforeend", htmlString);
    //}

    //console.info("Ready");
});