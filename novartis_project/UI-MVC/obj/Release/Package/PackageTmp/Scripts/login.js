$(function () {
    var button = $('#loginButton');
    var box = $('#loginBox');
    var form = $('#loginForm');
    var icon = $('.icon-user');
    button.removeAttr('href');
    button.mouseup(function (login) {
        box.toggle();
        button.toggleClass('active');
        //icon.css('background-position', '0 -100px');
       /* if (icon.css('background-position') == '0 -50px') {

            icon.css('background-position', '0 -100px');
        } else {
            icon.css('background-position', '0 -50px');

        }*/

    });
    form.mouseup(function () {
        return false;
    });
    $(document).mouseup(function (e) {

        if (!button.is(e.target)  // if the target of the click isn't the container...
        && button.has(e.target).length === 0 && !box.is(e.target) && box.has(e.target).length === 0)
            // ... nor a descendant of the container
        {
            button.removeClass('active');
            box.hide();
        } 
       
    });

});

