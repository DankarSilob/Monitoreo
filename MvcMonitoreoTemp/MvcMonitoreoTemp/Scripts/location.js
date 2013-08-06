//JS con las funciones

var map;
var markers = [];

function initialize()
{
    var latlng = new google.maps.LatLng(23.644524, -101.652833);
    var options = {
        zoom: 5, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById
    ("map_canvas"), options);
}

function setMarkers(latitud, longitud, nombre) {
    var contentString = '<h3>' +nombre + '</h3>'
    var latLng = new google.maps.LatLng(latitud, longitud);
    var marker = new google.maps.Marker({
        position: latLng,
        map: map
    });
    marker.metadata = { type: "point", id: nombre }
    var infoWindow = new google.maps.InfoWindow();
    google.maps.event.addListener(marker, 'click', function () {
        infoWindow.setContent(contentString);
        infoWindow.open(map, marker);
    });
    markers.push(marker);
}

function zoomGPS(latitud, longitud) {
    var latlngPos = new google.maps.LatLng(latitud, longitud);
    map.setCenter(latlngPos);
    map.setZoom(18);
}

function realoadPositions() {
    deleteOverlays();
    $.getJSON("http://localhost/sattrackapi/api/Posiciones",
    function (data) {
        $.each(data, function (index, value) {
            setMarkers(value.latitud, value.longitud, value.nombre);
        });
        setAllMap(map);
    });
    timer = setTimeout('realoadPositions()', 300000);    
}

function removeMarker(id) {
    markers[id].setMap(null);
}

function setMarker(id)
{
    markers[id].setMap(map);
}


function deleteOverlays() {
    clearOverlays();
    markers = [];
}


function clearOverlays() {
    setAllMap(null);
}

// Sets the map on all markers in the array.
function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}


function removeAllMarkersCheckbox() {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
}

function setAllMarkersCheckbox() {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}