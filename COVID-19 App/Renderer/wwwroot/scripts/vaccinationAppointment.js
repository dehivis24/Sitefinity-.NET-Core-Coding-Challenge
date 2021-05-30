(function () {

    document.addEventListener('DOMContentLoaded', function () {

        var regionsSelector = document.getElementById('regionSelector');
        var citiesSelector = document.getElementById('citySelector');
        var siteSelector = document.getElementById('siteSelector');

        var appointmentForm = document.getElementById('appointment-form');


        appointmentForm.addEventListener('submit', function (event) {

            event.preventDefault();    //stop form from submitting

            var $form = $(this);
            $form.validate();

            if ($form.valid() === true) {

                var dataForm = new FormData(event.target);

                var object = {};
                dataForm.forEach((value, key) => object[key] = value);

                var dateAppointment = new Date(object['AppointmentDate'] + ' ' + object['AppointmentTime']);
                object['AppointmentTime'] = dateAppointment.toISOString();
                object['AppointmentDate'] = dateAppointment.toISOString();

                var objectRegions = [{
                    text: object['regions'],
                    value: object['regions']
                }];
                object['regions'] = objectRegions;


                var objectCities = [{
                    text: object['cities'],
                    value: object['cities']
                }];
                object['cities'] = objectCities;

                var name = object['FirstName'] + ' ' + object['LastName'];


                var json = JSON.stringify(object);

                uri = 'api/VaccinationAppointment/SendResponse';
                fetch(uri, {
                    method: 'POST',
                    body: json,
                    headers: { 'content-type': 'application/json' }
                }).then(response => response.json())
                    .then(data => {
                        if (typeof data !== 'undefined') {


                            $('#appointmentResult').modal('show');

                            var date = dateAppointment.toDateString();
                            var time = dateAppointment.toLocaleTimeString();
                            
                            document.getElementById("appointmentName").textContent += name + ", ";

                            document.getElementById("appointmentDate").textContent += date + " at " + time;
                            $form[0].reset();
                        }
                    })
                    .catch(error => console.error('Unable to get items.', error));
            }
        }, false);

        /*Change the regions, the process refresh the City and site*/
        regionsSelector.addEventListener('change', function () {
            var value = regionsSelector.value;
            const uri = 'api/VaccinationAppointment/UpdateData?region=' + value;

            fetch(uri)
                .then(response => response.json())
                .then(data => {
                    if (typeof data !== 'undefined') {
                        citiesSelector.options.length = 0;
                        if (typeof data.cities !== 'undefined') {

                            for (index in data.cities) {
                                citiesSelector.options[index] = new Option(data.cities[index].text, data.cities[index].value);
                            }
                        }

                        siteSelector.options.length = 0;
                        if (typeof data.sites !== 'undefined') {

                            for (index in data.sites) {
                                siteSelector.options[index] = new Option(data.sites[index].text, data.sites[index].value);
                            }
                        }
                    }
                })
                .catch(error => console.error('Unable to get items.', error));
        });

        /*Change the city, the process refresh the site*/
        citiesSelector.addEventListener('change', function () {
            var value = citiesSelector.value;
            const uri = 'api/VaccinationAppointment/UpdateData?city=' + value + '&region=' + regionsSelector.value;
            fetch(uri)
                .then(response => response.json())
                .then(data => {
                    if (typeof data !== 'undefined') {
                        siteSelector.options.length = 0;
                        if (typeof data.sites !== 'undefined') {
                            for (index in data.sites) {
                                siteSelector.options[index] = new Option(data.sites[index].text, data.sites[index].value);
                            }
                        }
                    }
                })
                .catch(error => console.error('Unable to get items.', error));
        });
    });

})();