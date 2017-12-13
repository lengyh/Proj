function showMask() { var height = $(document).height(); $("#mask").css("height", height); $("#mask").css("width", $(document).width()); $("#divLoading").css("margin-top", height / 2 - 32); $("#mask").show(); } function hidMask() { $("#mask").hide(); }

$(document).ready(function () {
    $(document.body).append("<div id='mask' class='mask'><div id='divLoading'><img src='../../Images/Loading.gif' alt='' /></div></div>");
    $("#mask").hide();
});