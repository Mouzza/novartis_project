$(document).ready(function () {
   
  

    $("#eersteMenuItem").click(function () {
        window.location = $(this).find("#eersteMenuLink").attr("href");
        return false;
    });

});