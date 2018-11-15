var httpRequest = new XMLHttpRequest();

// Calls the specified APItarget with the method request.
function callWebservice(method, APItarget, index = -1, object = null) {
    var url = "";
    if (index < 0)
        url = 'http://localhost:53880/api/' + APItarget;

    else
        url = 'http://localhost:53880/api/' + APItarget + '/' + index;

    httpRequest.open(method, url);
    httpRequest.setRequestHeader("Content-Type", "application/json");
    if (object !== null)
        httpRequest.send(object);

    else
        httpRequest.send();

    return httpRequest;
}