function nav_backbuttonclick() {
    var movelist = [];
    if (createType === "Box") {
        nav_barnbuttonclick();
    }
    else if (createType === "pigmove") {
        nav_boxbuttonclick();
    }
    else {
        nav_farmbuttonclick();
    }

}

function nav_farmbuttonclick() {
    $("#js-page").load("Page/FarmView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            Farmview_init(Farm);
        }
    });
}

function nav_barnbuttonclick() {
    $("#js-page").load("Page/BarnView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            Barnview_init(SelectedBarn.BarnId);
        }
    });
}

function nav_boxbuttonclick() {
    $("#js-page").load("Page/BoxView.html", function (responseTxt, statusTxt, xhr) {
        if (statusTxt === "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
        if (statusTxt === "success") {
            Boxview_Update();
        }
    });
}

function nav_updateNavigationView(showNav, showFarm, showBarn, showBack) {
    if (showNav)
        $("#topnavigation").show();
    else
        $("#topnavigation").hide();
    if (showFarm)
        $("#nav_farmbutton").show();
    else 
        $("#nav_farmbutton").hide();
    if (showBarn)
        $("#nav_barnbutton").show();
    else
        $("#nav_barnbutton").hide();
    if (showBack)
        $("#nav_backbutton").show();
    else
        $("#nav_backbutton").hide();
}
