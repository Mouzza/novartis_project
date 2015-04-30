
$(document).ready(function () {
   
  

    if (window.localStorage.getItem("hideMenu")=="hidden") {
        $("#homeIconMenu").css("display","none");
        $("#show").css('display', 'block');
        $("#hide").css('display', 'none');

    } else if (window.localStorage.getItem("hideMenu")=="visible") {
        $("#homeIconMenu").removeClass("verborgen");
        $("#hide").css('display', 'block');
        $("#show").css('display', 'none');
 
    } else {
        $("#homeIconMenu").removeClass("verborgen");
    }
    $('#to-top').hide();
  
    //Check to see if the window is top if not then display button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 200) {
            $('#to-top').fadeIn();
        } else {
            $('#to-top').fadeOut();
        }
   
      

    });
    window.onload = function () {

        
        var lastPart = window.location.href.split("/").pop();
        //var value = '#' + lastPart.toLowerCase() + 'Wrapper';

        if (lastPart == 'Register' || lastPart == 'ForgotPassword' || lastPart=="Login" || lastPart=="Diensten" || lastPart.substring(0, 12)=="ConfirmEmail") {
            $('html, body').animate({ scrollTop: $('#mainWrapper').offset().top -80});
        }

    

    };


    //Click event to scroll to top
    $('#to-top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });
    $('#centraleButton').click(function () {
        $('html, body').animate({ scrollTop: $("#mainWrapper").offset().top - 100 }, 800);
        return false;
    });
    $('#menuItem1').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });
    $('#menuItem3').click(function () {
        $('html, body').animate({ scrollTop: $("#wrapper4").offset().top }, 800);
        return false;
    });
    $('#menuItem4').click(function () {
        $('html, body').animate({ scrollTop: $("#extraWrapper").offset().top - 100 }, 800);
        return false;
    });


    $("#hide").click(function () {
        $('#paginaTitel').css('margin-bottom', '1%');
         
            $("#homeIconMenu").hide(1000);
            $("#show").css('display', 'block');
            $("#hide").css('display', 'none');
            window.localStorage.setItem("hideMenu", "hidden")
        });
    $("#show").click(function () {
        $('#paginaTitel').css('margin-bottom', '5%');

            $("#homeIconMenu").show(1000);
            $("#hide").css('display', 'block');
            $("#show").css('display', 'none');
            window.localStorage.setItem("hideMenu", "visible")
        });


});