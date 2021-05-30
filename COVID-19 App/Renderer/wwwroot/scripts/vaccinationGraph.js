(function () {
    var options = {
        series: [{
            name: 'Dosis',
            data: []
        }],
        annotations: {},
        chart: {
            height: 350,
            type: 'bar',
            toolbar: {
                show: true,
                offsetX: 0,
                offsetY: 0,
                tools: {
                    download: true,
                    selection: true,
                    zoom: false,
                    zoomin: false,
                    zoomout: false,
                    pan: false,
                    reset: false | '<img src="/static/icons/reset.png" width="20">',
                    customIcons: []
                }
            }
        },
        plotOptions: {
            bar: {
                borderRadius: 10,
                columnWidth: '30%',
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            width: 2
        },
        grid: {
            row: {
                colors: ['#fff', '#F4CFD0']
            }
        },
        xaxis: {
            labels: {
                rotate: -45
            },
            categories: [],
            tickPlacement: 'on'
        },
        yaxis: {
            title: {
                text: 'Dosis',
            },
        },
        theme: {
            monochrome: {
                enabled: true,
                color: '#292E3F',
                shadeTo: 'dark',
                shadeIntensity: 1
            }
        },
        fill: {
            type: "solid",
            opacity: 1,
            colors: ['#292E3F']
        }
    };

    document.addEventListener('DOMContentLoaded', function () {
        var graph = document.getElementById('chart');
        var dropdown = document.getElementById('countryList');
        var graphModel = JSON.parse(graph.dataset['graphModel']);

        dropdown.value = graphModel.SelectedCountry;

        var monthList = graphModel.MonthList;
        options.xaxis.categories = monthList.map(m => m.Value);
        options.series[0].data = graphModel.DosisPerMonth;

        calculateTotalAmount(graphModel.DosisPerMonth);

        if (graphModel.GraphType == 'Lines') {
            options.stroke.curve = 'smooth';
            options.stroke.width = 5;
            options.chart.type = 'line';
            options.markers = {
                size: 6,
                colors: ["#DF6B6F"],
                strokeColors: "#fff",
                strokeWidth: 1,
                hover: {
                    size: 7,
                }
            };
        }

        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();

        dropdown.addEventListener('change', function () {
            var value = dropdown.value;
            const uri = 'api/VaccinationGraph?countryCode=' + value;

            fetch(uri)
                .then(response => response.json())
                .then(data => {
                    chart.updateOptions({
                        series: [{
                            name: 'Dosis',
                            data: data
                        }]
                    });

                    calculateTotalAmount(data);
                })
                .catch(error => console.error('Unable to get items.', error));
        });
    });

    function calculateTotalAmount(data) {
        if (data.length > 0)
        {
            var totalAmount = data.reduce((a, b) => a + b, 0);
            var $spanAmount = document.getElementsByClassName('total-amount');
            $spanAmount[0].innerHTML = totalAmount;
        }
    }
})();
