$(document).ready(function () {
    $('.card').addClass("hidden").viewportChecker({
        classToAdd: 'visible animated fadeInDown',
        classToRemove: 'hidden',
        offset: 100,
        repeat: true
    });
});


// masonry 
var $blog = $('.gallery-wrapper').masonry({
    itemSelector: '.grid-item',
    columnWidth: '.grid-sizer',
    percentPosition: true,
    transitionDuration: 0,
});

$blog.imagesLoaded().progress(function () {
    $blog.masonry();
});




$('#datepicker').datepicker(
    {
        autoclose: true,
        todayBtn: true
    }).on('show', function(e) {
        var popup = $(this).offset();
            var popupTop = popup.top + 45;
            $('.datepicker-dropdown').css({
                'top': popupTop + 'px'
            });
    });;




