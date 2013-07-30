//JS con las funciones

var map;
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
    var infoWindow = new google.maps.InfoWindow();
    google.maps.event.addListener(marker, 'click', function () {
        infoWindow.setContent(contentString);
        infoWindow.open(map, marker);
    });
}

function zoomGPS(latitud, longitud) {
    var latlngPos = new google.maps.LatLng(latitud, longitud);
    map.setCenter(latlngPos);
    map.setZoom(18);
}