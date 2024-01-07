$(function() {
    "use strict";

    //------- Top Btn Link-------//

    $(".btn-scroll-top").on('click', function(event) {
        if (this.hash !== "") {
            event.preventDefault();
            var hash = this.hash;
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 900, function() {});
        }
    });


    $(window).scroll(function() {
        var GotoTop = $(window).scrollTop();
        if (GotoTop >= 400) {
            $(".btn-scroll-top").slideDown(500);
        } else {
            $(".btn-scroll-top").slideUp(500);
        }

    });



    //------- Parallax -------//
    skrollr.init({
        forceHeight: false
    });

    //------- Active Nice Select --------//
    $('select').niceSelect();

    //------- hero carousel -------//
    $(".hero-carousel").owlCarousel({
        items: 3,
        margin: 10,
        autoplay: false,
        autoplayTimeout: 5000,
        loop: true,
        nav: false,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            810: {
                items: 3
            }
        }
    });

    //------- Best Seller Carousel -------//
    if ($('.owl-carousel').length > 0) {
        $('#bestSellerCarousel').owlCarousel({
            loop: true,
            margin: 30,
            nav: true,
            navText: ["<i class='ti-arrow-left'></i>", "<i class='ti-arrow-right'></i>"],
            dots: false,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                900: {
                    items: 3
                },
                1130: {
                    items: 4
                }
            }
        })
    }

    //------- single product area carousel -------//
    $(".s_Product_carousel").owlCarousel({
        items: 1,
        autoplay: false,
        autoplayTimeout: 5000,
        loop: true,
        nav: false,
        dots: false
    });

    //------- mailchimp --------//  
    function mailChimp() {
        $('#mc_embed_signup').find('form').ajaxChimp();
    }
    mailChimp();

    //------- fixed navbar --------//  
    $(window).scroll(function() {
        var sticky = $('.header_area'),
            scroll = $(window).scrollTop();

        if (scroll >= 100) sticky.addClass('fixed');
        else sticky.removeClass('fixed');
    });

    //------- Price Range slider -------//
    if (document.getElementById("price-range")) {

        var nonLinearSlider = document.getElementById('price-range');

        noUiSlider.create(nonLinearSlider, {
            connect: true,
            behaviour: 'tap',
            start: [500, 4000],
            range: {
                // Starting at 500, step the value by 500,
                // until 4000 is reached. From there, step by 1000.
                'min': [0],
                '10%': [500, 500],
                '50%': [4000, 1000],
                'max': [10000]
            }
        });


        var nodes = [
            document.getElementById('lower-value'), // 0
            document.getElementById('upper-value') // 1
        ];

        // Display the slider value and how far the handle moved
        // from the left edge of the slider.
        nonLinearSlider.noUiSlider.on('update', function(values, handle, unencoded, isTap, positions) {
            nodes[handle].innerHTML = values[handle];
        });

    }



    if (document.getElementById("map")) {

        var cord = [51.6131, 32.6556];
        var map = new ol.Map({
            target: 'map',
            layers: [
                new ol.layer.Tile({
                    source: new ol.source.OSM()
                })
            ],
            view: new ol.View({
                center: ol.proj.fromLonLat(cord),
                zoom: 10
            })
        });

        var styleMarker = new ol.style.Style({
            image: new ol.style.Icon({
                scale: .2,
                anchor: [0.5, 1],
                src: 'assets/img/map-marker-icon.png'
            })
        });

        var marker = new ol.geom.Point(ol.proj.fromLonLat(cord));
        var featureMarker = new ol.Feature(marker);

        var vector = new ol.layer.Vector({
            source: new ol.source.Vector({
                features: [featureMarker]
            }),
            style: [styleMarker]
        });


        map.addLayer(vector);


        var translate = new ol.interaction.Translate({
            features: new ol.Collection([featureMarker])
        });

        map.addInteraction(translate);
    }


});