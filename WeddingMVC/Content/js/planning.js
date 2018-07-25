

var $grid = $('.grid').isotope({
    itemSelector: '.grid-item'
  });

// change is-checked class on buttons
var $buttonGroup = $('.button-group');
$buttonGroup.on( 'click', 'button', function( event ) {
$buttonGroup.find('.is-checked').removeClass('is-checked');
var $button = $( event.currentTarget );
$button.addClass('is-checked');
var filterValue = $button.attr('data-filter');
$grid.isotope({ filter: filterValue });
});

$('button[data-filter=".ads"]').click();
// masterslide

var slider = new MasterSlider();

slider.control('arrows', {
autohide: true,
overVideo: true
});
slider.control('slideinfo', {
autohide: false,
overVideo: true,
dir: 'h',
align: 'bottom',
inset: false,
margin: 10
});
slider.setup("masterslider", {
width: 240,
height: 240,
minHeight: 0,
space: 35,
start: 1,
grabCursor: true,
swipe: true,
mouse: true,
keyboard: false,
layout: "partialview",
wheel: false,
autoplay: false,
instantStartLayers: false,
loop: true,
shuffle: false,
preload: 4,
heightLimit: true,
autoHeight: false,
smoothHeight: true,
endPause: false,
overPause: true,
fillMode: "fill",
centerControls: true,
startOnAppear: false,
layersMode: "center",
autofillTarget: "",
hideLayers: false,
fullscreenMargin: 0,
speed: 20,
dir: "h",
viewOption: {centerSpace: 1.6},
parallaxMode: 'swipe',
view: "focus"
});

// masterslide


//slick-slider 

$(document).ready(function(){
    $('.slider').slick({
      //  centerMode: true,
        centerPadding: '0',
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
         arrows: false,
         responsive: [
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
        infinite: true,
        dots: true,
        arrows: false,
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
        dots: false,
        arrows: true,
      }
    },
    {
      breakpoint: 550,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        dots: false,
        arrows: true,
      }
    }
  ]
    });
});

//slick