$(document).ready(function () {

  

    $("#eersteMenuItem").click(function () {
        window.location = $(this).find("#eersteMenuLink").attr("href");
        return false;
    });

    $("#tweedeMenuItem").click(function () {
        window.location = $(this).find("#tweedeMenuLink").attr("href");
        return false;
    });

    $("#derdeMenuItem").click(function () {
        window.location = $(this).find("#derdeMenuLink").attr("href");
        return false;
    });




 

});