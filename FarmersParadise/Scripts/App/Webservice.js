var httpRequest = new XMLHttpRequest();

// Calls the specified APItarget with the method request.
function callWebservice(method, APItarget) {
    var url = 'http://localhost:53880/api/' + APItarget;
    httpRequest.open(method, url);
    httpRequest.send();
}