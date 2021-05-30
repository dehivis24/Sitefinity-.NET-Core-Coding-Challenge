$(function () {
   $(document).ready(function () {
        $('.gallery').not('.slick-initialized').slick({
            slidesToShow: 6,
            autoplay: true,
            autoplaySpeed: 2000,
            infinite: true,
            responsive: [
                {
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 4
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        arrows: false,
                        slidesToShow: 2
                    }
                }
            ]
        });

    });
})


