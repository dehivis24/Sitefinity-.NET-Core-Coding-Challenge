(function () {

    document.addEventListener('DOMContentLoaded', function () {
        var map;
        var initialZoom = 16;
        var currentPositionLat;
        var currentPositionLng;
        var mapLocation = document.getElementById('map-locator');
        var site = document.getElementById('site-model');
        var myLocation = document.getElementById('my-location');
        var vaccinationSiteModel = JSON.parse(site.dataset['siteSearchModel']);
        var sites = document.getElementById('sites');

        var filter25 = document.getElementById('filter-25');
        var filter50 = document.getElementById('filter-50');
        var filter75 = document.getElementById('filter-75');
        var filter100 = document.getElementById('filter-100');
        var inputSearch = document.getElementById('input-search');  
        var detailPage = vaccinationSiteModel.DetailPage;
        var filterValue = 25;      
        //var bounds;

        function initMap() {
            map = new google.maps.Map(mapLocation, {
                center: { lat: parseFloat(vaccinationSiteModel.Latitude), lng: parseFloat(vaccinationSiteModel.Longitude) },
                zoom: initialZoom,
            });

            new google.maps.Marker({
                position: { lat: parseFloat(vaccinationSiteModel.Latitude), lng: parseFloat(vaccinationSiteModel.Longitude) },
                map,
                title: vaccinationSiteModel.SiteName,
            });

            currentPositionLat = parseFloat(vaccinationSiteModel.Latitude);
            currentPositionLng = parseFloat(vaccinationSiteModel.Longitude);
   
            filter(filterValue);      
        }

        function initSearchBox() {
            var searchBox = new google.maps.places.SearchBox(inputSearch);

            map.addListener('bounds_changed', function () {
                searchBox.setBounds(map.getBounds());
            });

            // Listen for the event fired when the user selects a prediction and retrieve
            // more details for that place.
            searchBox.addListener('places_changed', function () {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }

                bounds = new google.maps.LatLngBounds();

                places.forEach(function (place) {
                    if (!place.geometry) {
                        console.log("Returned place contains no geometry");
                        return;
                    }

                    var pos = new google.maps.LatLng(place.geometry.location.lat(), place.geometry.location.lng());
                    map.setCenter(pos);
                    currentPositionLat = place.geometry.location.lat();
                    currentPositionLng = place.geometry.location.lng();

                    filter(filterValue); 

                    new google.maps.Marker({
                        position: { lat: currentPositionLat, lng: currentPositionLng },
                        map        
                    });
                });
            });
        }

        function useMyLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    function (position) {
                        //Center map using current position
                        bounds = new google.maps.LatLngBounds();
                        var pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                        map.setCenter(pos);

                        currentPositionLat = position.coords.latitude;
                        currentPositionLng = position.coords.longitude;

                        inputSearch.value = "";   
                        filter(filterValue);   

                        new google.maps.Marker({
                            position: { lat: position.coords.latitude, lng: position.coords.longitude },
                            map,
                            title: vaccinationSiteModel.SiteName,
                        });
                    }
                )
            }
        }

        initMap();
        initSearchBox();

        myLocation.addEventListener('click', function () {
            useMyLocation();
        });

        filter25.addEventListener('click', function () {
            filterValue = 25;
            filter(filterValue);
            filter25.classList.add('badge-primary');
            filter25.classList.remove('badge-light');

            filter50.classList.remove('badge-primary');
            filter50.classList.add('badge-light');

            filter75.classList.remove('badge-primary');
            filter75.classList.add('badge-light');

            filter100.classList.remove('badge-primary');
            filter100.classList.add('badge-light');
        });

        filter50.addEventListener('click', function () {
            filterValue = 50;
            filter(filterValue);
            filter50.classList.add('badge-primary');
            filter50.classList.remove('badge-light');

            filter25.classList.remove('badge-primary');
            filter25.classList.add('badge-light');

            filter75.classList.remove('badge-primary');
            filter75.classList.add('badge-light');

            filter100.classList.remove('badge-primary');
            filter100.classList.add('badge-light');
        });

        filter75.addEventListener('click', function () {
            filterValue = 75;
            filter(filterValue);
            filter75.classList.add('badge-primary');
            filter75.classList.remove('badge-light');

            filter25.classList.remove('badge-primary');
            filter25.classList.add('badge-light');

            filter50.classList.remove('badge-primary');
            filter50.classList.add('badge-light');

            filter100.classList.remove('badge-primary');
            filter100.classList.add('badge-light');
        });

        filter100.addEventListener('click', function () {
            filterValue = 100;
            filter(filterValue);          
            filter100.classList.add('badge-primary');
            filter100.classList.remove('badge-light');

            filter25.classList.remove('badge-primary');
            filter25.classList.add('badge-light');

            filter75.classList.remove('badge-primary');
            filter75.classList.add('badge-light');

            filter50.classList.remove('badge-primary');
            filter50.classList.add('badge-light');
        });

        function filter(value) {        
            const uri = 'api/VaccinationSite/FilterSite?distance=' + value + '&positionLat=' + currentPositionLat + '&positionLng=' + currentPositionLng;

            fetch(uri)
                .then(response => response.json())
                .then(data => {
                    if (typeof data !== 'undefined') {
                        displaySiteList(data);
                    }
                })
                .catch(error => console.error('Unable to get items.', error));
        }


        function displaySiteList(list) {
            if (typeof list !== 'undefined') {
                sites.innerHTML = "";             

                list.forEach(function (item, index) {    
                    var cardSite = document.createElement("div");
                    cardSite.classList.add("d-flex");
                    cardSite.classList.add("mt-3");

                    var iconLocation = document.createElement("div");
                    iconLocation.classList.add('mx-3');

                    var iconMarker = document.createElement("i");
                    iconMarker.classList.add('fas');
                    iconMarker.classList.add('fa-map-marker-alt');
                    iconMarker.classList.add('fa-2x');
                    iconLocation.appendChild(iconMarker);

                    var addressInfo = document.createElement("div");

                    var name = document.createElement("div");
                    name.innerHTML += item.name;

                    var address = document.createElement("div");
                    address.innerHTML += item.region + ", " + item.city + " " + item.country;

                    var distance = document.createElement("small");
                    distance.innerHTML += "(" + item.distance + " Km)  ";

                    var siteDetail = document.createElement("a");                         

                    var iconLink = document.createElement("i");
                    iconLink.classList.add('fas');
                    iconLink.classList.add('fa-external-link-square-alt');
                    siteDetail.appendChild(iconLink);
                    siteDetail.href = detailPage + "?Name=" + encodeURI(item.name.replace(" ", "+"));                                              
                    siteDetail.innerHTML += " Site Detail";

                    addressInfo.appendChild(name);
                    addressInfo.appendChild(address);
                    addressInfo.appendChild(distance);
                    addressInfo.appendChild(siteDetail);

                    cardSite.appendChild(iconLocation);
                    cardSite.appendChild(addressInfo);
                    sites.appendChild(cardSite);
                });
            }
        }
    });
})();
