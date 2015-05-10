
$(document).ready(function () {



    $('.dot:nth-child(1)').click(function () {
        $('.inside').animate({
            'width': '20%'
        }, 500);
    });
    $('.dot:nth-child(2)').click(function () {
        $('.inside').animate({
            'width': '40%'
        }, 500);
    });
    $('.dot:nth-child(3)').click(function () {
        $('.inside').animate({
            'width': '60%'
        }, 500);
    });
    $('.dot:nth-child(4)').click(function () {
        $('.inside').animate({
            'width': '80%'
        }, 500);
    });

    // modal
    $('.modal').wrap('<div class="mask"></div>')
    $('.mask').click(function () {
        $(this).fadeOut(300);
        $('.mask article').animate({
            'top': '-100%'
        }, 300)
    });

    $('.dot').click(function () {
        var modal = $(this).attr('id');
        $('.mask').has('article.' + modal).fadeIn(300);
        $('.mask article.' + modal).animate({
            'top': '10%'
        }, 300)
    });

});