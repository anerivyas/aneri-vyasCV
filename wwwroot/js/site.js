// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {

    $("#links_One").css("color", " #4282bd");

    $("#Two").hide();
    $("#Three").hide();
    $("#Four").hide();
    $("#Five").hide();
});

function showContent(e) {

    console.log(e);

    var area = e.getAttribute("value");
    console.log(area);

    $(".content").hide();
    $("#" + area).fadeIn();


    if (document.getElementById('modeSwitch').checked == false) {
        console.log("false")
        $(".navigationLinks").css("color", "lightgrey");
    } else {
        console.log("true");
        $(".navigationLinks").css("color", "black");
    }
    
    $("#links_" + area).css("color", " #4282bd");


}

function changeMode() {

    

        var element = document.body;
        element.classList.toggle("lightmode");
   
}